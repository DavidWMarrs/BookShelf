function BookViewModel(id, title, author, onLoan) {
    // Track 'this' for use in ToggleLoanStatus
    var self = this;

    this.Id = id;
    this.Title = ko.observable(title);
    this.Author = ko.observable(author);

    if (typeof (onLoan) == 'undefined')
        onLoan = false;

    this.OnLoan = ko.observable(onLoan);

    this.ToggleLoanStatus = function () {
        var onLoan = !this.OnLoan();

        $.ajax({
            url: '/api/books/' + this.Id,
            method: 'PUT',
            data: {
                onLoan: onLoan
            },
            success: function () {
                self.OnLoan(onLoan);
            }
        });
    }
}

function AddBookViewModel() {
    this.Title = ko.observable();
    this.Author = ko.observable();
    this.Enabled = ko.observable(true);

    this.Reset = function () {
        this.Title('');
        this.Author('');
    }
}

function AddAuthorViewModel() {
    this.Name = ko.observable();
    this.Enabled = ko.observable(true);

    this.Reset = function () {
        this.Name('');
    }
}


function StackViewModel(books, authors) {
    // Track 'this' for use in some methods
    var self = this;

    this.Books = ko.observableArray(books);
    this.Authors = ko.observableArray(authors);

    this.AddBookForm = new AddBookViewModel();
    this.AddAuthorForm = new AddAuthorViewModel();

    this.In = ko.computed(function () {
        return ko.utils.arrayFilter(this.Books(), function (item) {
            return !item.OnLoan();
        });
    }, this);

    this.Out = ko.computed(function () {
        return ko.utils.arrayFilter(this.Books(), function (item) {
            return item.OnLoan();
        });
    }, this);

    this.AddBook = function () {
        $.ajax({
            url: '/api/books/',
            method: 'POST',
            data: {
                Title: this.AddBookForm.Title(),
                AuthorId: this.AddBookForm.Author().id
            },
            success: function (data) {
                self.Books.push(new BookViewModel(data, self.AddBookForm.Title(), self.AddBookForm.Author()));
                self.AddBookForm.Reset();
                self.AddBookForm.Enabled(true);
            },
            error: function () {
                self.AddBookForm.Enabled(true);
            }
        });

        this.AddBookForm.Enabled(false)
    }

    this.AddAuthor = function () {
        $.ajax({
            url: '/api/authors/',
            method: 'POST',
            data: {
                Name: this.AddAuthorForm.Name()
            },
            success: function (data) {
                self.Authors.push({ id: data, name: self.AddAuthorForm.Name() });
                self.AddAuthorForm.Reset();
                self.AddAuthorForm.Enabled(true);
            },
            error: function () {
                self.AddAuthorForm.Enabled(true);
            }
        });

        this.AddAuthorForm.Enabled(false);
    }

    this.Delete = function (book) {
        $.ajax({
            url: '/api/books/' + book.Id,
            method: 'DELETE',
            success: function () {
                self.Books.remove(book);
            }
        });
    }
}
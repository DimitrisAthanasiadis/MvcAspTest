function AuthorIndexViewModel(authors) {
    this.authors = authors;

    this.showDeleteModal = function (data, event) {
        this.sending = ko.observable(false);

        $.get($(event.target).attr('href'), function (d) {
            $('.body-content').prepend(d);
            $('#deleteModal').modal('show');

            ko.applyBindings(this, document.getElementById('deleteModal'));
        });
    };

    this.deleteAuthor = function (form) {
        this.sending(true);
        return true;
    };
}
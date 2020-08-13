function AuthorFormViewModel() {
    this.saveCompleted = ko.observable(false);
    this.sending = ko.observable(false);

    this.author = {
        id: author.id,
        firstName: ko.observable(),
        lastName: ko.observable(),
        biography: ko.observable()
    };

    this.validateAndSave = function (form) {
        if (!$(form).valid()){
            return false;
        }

        this.sending(true);

        // anti-forgery token
        this.author.__RequestVerificationTOken = form[0].value;

        $.ajax({
            url: (this.isCreating) ? 'Create' : 'Edit',
            type: 'post',
            contentType: 'application/x-www-form-urlencoded',
            data: ko.toJS(this.author)
        })
            .success(this.successfulSave)
            .error(this.errorSave)
            .complete(function () { this.sending(false) });
    };

    this.successfulSave = function () {
        this.saveCompleted(true);

        $(".body-content").prepend(
            `
                <div class='alert alert-success'>
                    <strong>Success!</string> The new author has been saved.
                </div>
            `
        );

        setTimeout(function () {
            if (this.isCreating) {
                location.href = './';
            } else {
                location.href = "../";
            }
        }, 1000);
    }

    this.errorSave = function () {
        $(".body-content").prepend(
            `
                <div class="alert alert-danger">
                    <strong>Error!</strong> There was an error saving the author.
                </div>
            `
        );
    }
}
$(document).ready(function () {
    // When Add EBook button is clicked
    $(document).on("click", "#addEbookBtn", function (e) {
        e.preventDefault();

        // Optionally, show a loading indicator
        $("#contentArea").html('<div class="text-center my-5"><span class="spinner-border text-primary"></span> Loading...</div>');

        $.ajax({
            url: '/Ebooks/AddEbooks',
            type: 'GET',
            success: function (result) {
                // Inject the returned HTML into contentArea
                $("#contentArea").html(result);
            },
            error: function (xhr, status, error) {
                $("#contentArea").html('<div class="alert alert-danger">Failed to load Add EBook page. Please try again.</div>');
                console.error(error);
            }
        });
    });
});



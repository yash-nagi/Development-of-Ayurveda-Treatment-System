$(document).ready(function () {
    // When Add EBook button is clicked
    $(document).on("click", "#addEbookBtn", function (e) {
        e.preventDefault();

        // Optionally, show a loading indicator
        $("#contentArea").html('<div class="text-center my-5"><span class="spinner-border text-primary"></span> Loading...</div>');

        $.ajax({
            url: '/EBooks/AddEbooks',
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
// $(document).ready(function () {
//     $('#ImageUrl').on('input', function () {
//         var url = $(this).val().trim();
//         var $preview = $('#ebookPreview');
//         if (url) {
//             // Check if image can load
//             var img = new Image();
//             img.onload = function () {
//                 $preview.attr('src', url);
//             };
//             img.onerror = function () {
//                 $preview.attr('src', 'https://via.placeholder.com/180x180?text=Preview');
//             };
//             img.src = url;
//         } else {
//             $preview.attr('src', 'https://via.placeholder.com/180x180?text=Preview');
//         }
//     });
// });

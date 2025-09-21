function loadSection(section) {
    $.ajax({
        url: window.baseUrl,
        type: 'GET',
        data: { section: section }, // sends ?section=Medicine
        success: function (html) {
          $('#contentArea').html(html);   // NOTE: contentArea, not "content"
        },
        error: function () {
            onsole.error("AJAX Error:", status, error);
            console.error("Response:", xhr.responseText);
            $('#contentArea').html('<p>Error ' + xhr.status + ': ' + xhr.responseText + '</p>');
        }
    });
}
$(document).ready(function () {
    // When profile button is clicked
    $("#userProfile").on("click", function (e) {
        e.preventDefault(); // stop default link action
        $.ajax({
            url: '/Users/UserProfile',   // Controller action
            type: 'GET',
            success: function (result) {
                $("#contentArea").html(result); // Inject HTML into contentArea
            },
            error: function (xhr, status, error) {
                console.error("Error loading profile:", error);
                $("#contentArea").html("<p class='text-danger'>⚠ Unable to load profile.</p>");
            }
        });
    });
});

$(document).ready(function () {

    // delegated binding, works even if element is rendered later
    $(document).on("click", "#editUserProfile", function (e) {
        e.preventDefault();
        $.ajax({
            url: '/Users/EditUserProfile',
            type: 'GET',
            data: { 
                userId: $(this).data("userid")
            },
            success: function (result) {
                $("#contentArea").html(result);
                setupEditProfileStepper();
            },
            error: function (xhr, status, error) {
                console.error("Error loading profile:", error);
                $("#contentArea").html("<p class='text-danger'>⚠ Unable to load profile.</p>");
            }
        });
    });
});
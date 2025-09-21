
// When Details button is clicked
$(document).on("click", ".details-btn", function () {
    var courseId = $(this).data("courseid");
    if (!courseId) return;
    // Optional: show loading spinner
    $("#contentArea").html('<div class="text-center my-5"><span class="spinner-border text-primary"></span> Loading...</div>');
    // AJAX GET request to load course details
    $.ajax({
        url: '/Course/CourseDetails', // Controller/Action
        type: 'GET',
        data: { id: courseId },
        success: function (response) {
            // Replace main content with the returned HTML
            $("#contentArea").html(response);
        },
        error: function (xhr, status, error) {
            console.error("Error loading course details:", error);
            $("#contentArea").html('<div class="alert alert-danger">Failed to load course details. Please try again.</div>');
        }
    });
});

$(document).on("click", "#backToCourses", function () {
        // Optional: show loading spinner
        $("#contentArea").html('<div class="text-center my-5"><span class="spinner-border text-primary"></span> Loading courses...</div>');

        // AJAX GET request to load the courses page
        $.ajax({
            url: '/Course/Course', // Controller/Action
            type: 'GET',
            success: function (response) {
                // Replace main content with the returned HTML
                $("#contentArea").html(response);
            },
            error: function (xhr, status, error) {
                console.error("Error loading courses:", error);
                $("#contentArea").html('<div class="alert alert-danger">Failed to load courses. Please try again.</div>');
            }
        });
    });
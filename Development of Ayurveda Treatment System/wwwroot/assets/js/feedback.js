
$(document).on("submit", "#feedbackForm", function (e) {
    e.preventDefault();
    console.log("Feedback form submitted..."); 
    var form = $(this);
    var isValid = true;
    var name = $("input[name='Name']").val().trim();
    var email = $("input[name='Email']").val().trim();
    var message = $("textarea[name='Message']").val().trim();
    // Reset validation messages
    $(".text-danger").text("");
    // Simple validation
    if (name === "") {
        $("span[data-valmsg-for='Name']").text("Name is required.");
        isValid = false;
    }
    if (email === "") {
        $("span[data-valmsg-for='Email']").text("Email is required.");
        isValid = false;
    } else {
        // Basic email pattern check
        var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailPattern.test(email)) {
            $("span[data-valmsg-for='Email']").text("Enter a valid email.");
            isValid = false;
        }
    }
    if (message === "") {
        $("span[data-valmsg-for='Message']").text("Message is required.");
        isValid = false;
    }
    if (!isValid) {
        return; // Stop submission
    }
    // If validation passes → Send AJAX request
    $.ajax({
        url: '/Feedback/Feedback',
        type: 'POST',
        data: form.serialize(),
        headers: {
            "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val()
        },
        success: function (response) {
            if (response.success) {
                $("#feedbackMessage").html('<div class="alert alert-success">' + response.message + '</div>');
                form[0].reset();
            } else {
                $("#feedbackMessage").html('<div class="alert alert-danger">' + response.message + '</div>');
            }
        },
        error: function () {
            $("#feedbackMessage").html('<div class="alert alert-danger">Error submitting feedback. Please try again.</div>');
        }
    });
});
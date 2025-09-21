
$(document).on("click", ".book-appointment-btn", function (e) {
    e.preventDefault();
    var doctorId = $(this).data("doctorid");
    var doctorName = $(this).data("doctorname");
    var consultationFee = $(this).data("consultationfee");
    $.ajax({
        url: '/Appointment/Appointment',
        type: 'GET',
        data: {
            doctorId: doctorId,
            DoctorName: doctorName,
            consultationFee: consultationFee
        },
        success: function (response) {
            $("#contentArea").html(response); // loads appointment page inside content area
        },
        error: function () {
            $("#contentArea").html('<div class="alert alert-danger">Failed to load appointment page. Please try again.</div>');
        }
    });
});
$(document).on("click", "#cancelAppointmentBtn", function () {
    $("#contentArea").html('<div class="text-center my-5">' +
        '<span class="spinner-border text-primary"></span> Loading Experts...</div>');

    $.ajax({
        url: '/Doctors/Doctors', // Your action that returns the experts list partial view
        type: 'GET',
        success: function (response) {
            $("#contentArea").html(response);
        },
        error: function () {
            $("#contentArea").html('<div class="alert alert-danger">Failed to load experts. Please try again.</div>');
        }
    });
});
$(document).on("submit", "#appointmentForm", function (e) {
    e.preventDefault();

    // Get appointment date and time values
    var appointmentDate = $("#AppointmentDate").val();
    var appointmentTime = $("#AppointmentTime").val();

    var now = new Date();
    var selectedDate = new Date(appointmentDate + "T" + appointmentTime);

    // Validation: cannot select past date/time
    if (!appointmentDate) {
        $("#appointmentMessage").html('<div class="alert alert-danger">Please select appointment date.</div>');
        return;
    }

    if (!appointmentTime) {
        $("#appointmentMessage").html('<div class="alert alert-danger">Please select appointment time.</div>');
        return;
    }

    if (selectedDate < now) {
        $("#appointmentMessage").html('<div class="alert alert-danger">Appointment cannot be in the past.</div>');
        return;
    }
    // Show loading spinner/message
    $("#appointmentMessage").html('<div class="text-center my-3"><span class="spinner-border text-primary"></span> Booking appointment...</div>');
    var form = $(this);
    $.ajax({
        url: '/Appointment/Appointment',
        type: "POST",
        data: form.serialize(),
        success: function (response) {
            if (response.success) {
                $("#appointmentMessage").html('<div class="alert alert-success">' + response.message + '</div>');
                // Optionally reset form
                form[0].reset();
            } else {
                $("#appointmentMessage").html('<div class="alert alert-danger">' + response.message + '</div>');
            }
        },
        error: function () {
            $("#appointmentMessage").html('<div class="alert alert-danger">Failed to book appointment. Please try again.</div>');
        }
    });
});
$(document).ready(function() {
    var today = new Date();
    var yyyy = today.getFullYear();
    var mm = String(today.getMonth() + 1).padStart(2, '0'); // Months start at 0!
    var dd = String(today.getDate()).padStart(2, '0');

    var currentDate = yyyy + '-' + mm + '-' + dd;
    $("#AppointmentDate").val(currentDate);

    // Optional: limit past dates
    $("#AppointmentDate").attr('min', currentDate);
});

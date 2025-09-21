$(document).ready(function () {
    // When Book button is clicked
    $(document).on("click", ".buy-medicine-btn", function (e) {
        e.preventDefault();
        
        var medicineId = $(this).data("id");
        var quantity = $(this).siblings(".quantity-input").val() || 1;

        if (!medicineId) return;

        // Optional: show loading spinner
        $("#contentArea").html('<div class="text-center my-5"><span class="spinner-border text-primary"></span> Loading booking form...</div>');

        // AJAX GET request to load BookMedicine page
        $.ajax({
            url: '/Medicine/BookMedicine', // Controller/Action
            type: 'GET',
            data: { id: medicineId, quantity: quantity },
            success: function (response) {
                // Replace main content with returned HTML
                $("#contentArea").html(response);
            },
            error: function (xhr, status, error) {
                console.error("Error loading book medicine page:", error);
                $("#contentArea").html('<div class="alert alert-danger">Failed to load booking form. Please try again.</div>');
            }
        });
    });
});

$(document).ready(function () {
    // Cancel Button Click
    $(document).on("click", "#cancelBooking", function () {
        $.ajax({
            url: '/Medicine/Index', // your medicines listing page action
            type: 'GET',
            success: function (result) {
                $("#contentArea").html(result); // Load into content area
            },
            error: function () {
                alert("Failed to load Medicines page.");
            }
        });
    });

    $(document).on("submit", "#medicineBookingForm", function (e) {
        e.preventDefault(); // Prevent normal form submission
        var form = $(this);
        var userId = $("input[name='Booking.UserId']").val();
        var vendorId = $("select[name='Booking.VendorId']").val();
        var medicineNo = $("input[name='Booking.MedicineNo']").val();
        var quantity = $("input[name='Booking.Quantity']").val();
        var paymentMode = $("select[name='Booking.PaymentMode']").val();
        var medicineId = $("input[name='Booking.MedicineId']").val();
        // Basic validation
        if (!vendorId || !quantity || !paymentMode) {
            $("#bookingMessage").html('<div class="alert alert-danger">Please select Vendor, Payment Mode, and Quantity.</div>');
            return;
        }
        // Optional: Show loading spinner
        $("#bookingMessage").html('<div class="text-center my-3"><span class="spinner-border text-primary"></span> Loading Payment Page...</div>');
        // AJAX call to Payment page
        $.ajax({
            url: '/Payment/Payment', // Your Payment controller action
            type: 'GET',
            data: {
                userId: userId,
                vendorId: vendorId,
                medicineNo: medicineNo,
                quantity: quantity,
                paymentMode: paymentMode,
                medicineId: medicineId
            },
            success: function (response) {
                // Replace main content with Payment page
                $("#contentArea").html(response);
            },
            error: function (xhr, status, error) {
                console.error("Error loading payment page:", error);
                $("#bookingMessage").html('<div class="alert alert-danger">Failed to load Payment Page. Please try again.</div>');
            }
        });
    });
    // Optional: Cancel button to return to Medicines page
    //$("#cancelBooking").click(function () {
    //    $.ajax({
    //        url: '/Medicine/UserMedicines',
    //        type: 'GET',
    //        success: function (response) {
    //            $("#mainContent").html(response);
    //        }
    //    });
    //});
});
$(document).on("click", "#backToBookMedicine", function (e) {
    e.preventDefault(); // Prevent normal form submission
        var form = $(this);
        var medicineId = $("input[name='MedicineId']").val();
        var quantity = $("input[name='Quantity']").val();
    $.ajax({
        url: '/Medicine/BookMedicine',
        type: 'GET',
        data: {
            id: medicineId,
            quantity: quantity,
        },
        success: function (result) {
            $("#contentArea").html(result);
        },
        error: function () {
            $("#bookingMessage").html('<div class="alert alert-danger">Failed to load Book Medicine page. Please try again.</div>');
        }
    });
});

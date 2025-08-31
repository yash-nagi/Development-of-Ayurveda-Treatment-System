function loadSection(section) {
    $.ajax({
        url: window.baseUrl,
        type: 'GET',
        data: { section: section }, // sends ?section=Medicine
        success: function (html) {
          $('#contentArea').html(html);   // NOTE: contentArea, not "content"
        },
        error: function () {
            console.error("AJAX Error:", status, error);
            console.error("Response:", xhr.responseText);
            $('#contentArea').html('<p>Error ' + xhr.status + ': ' + xhr.responseText + '</p>');
        }
    });
}
$(document).ready(function () {
    // Delegated event for all dynamically added .load-section-btn
    $(document).on('click', '.load-section-btn', function (e) {
        e.preventDefault();
        var section = $(this).data('section');
        if (section) {
            loadSection(section); // Calls your AJAX function
        }
    });
    $(document).on('submit', '#addMedicineForm', function (e) {
        e.preventDefault();

        $.ajax({
            url: '/Admin/AddMedicine',
            type: 'POST',
            data: new FormData(this),
            processData: false,
            contentType: false,
            success: function () {
                // Reuse your function
                loadSection("MedicineManage"); 
            },
            error: function (xhr, status, error) {
                console.error("AJAX Error:", status, error);
                console.error("Response:", xhr.responseText);
                $('#contentArea').html('<p>Error ' + xhr.status + ': ' + xhr.responseText + '</p>');
            }
        });
    });

    $(document).on('click', '.deleteMedicine', function (e) {
        e.preventDefault();

            let url = $(this).attr("href");  // will hold /Admin/DeleteMedicine/ID

            if (confirm("Are you sure you want to delete this medicine?")) {
                $.ajax({
                    url: url,
                    type: 'POST', // or 'DELETE' if your controller supports it
                    success: function () {
                        // Reload ManageMedicine partial after delete
                        loadSection("MedicineManage");
                    },
                    error: function (xhr, status, error) {
                        console.error("AJAX Error:", status, error);
                        console.error("Response:", xhr.responseText);
                        $('#contentArea').html('<p>Error ' + xhr.status + ': ' + xhr.responseText + '</p>');
                    }
                });
            }
        });

        $(document).on('submit', '#editMedicineForm', function (e) {
        e.preventDefault();

        $.ajax({
            url: '/Admin/EditMedicine',
            type: 'POST',
            data: new FormData(this),
            processData: false,
            contentType: false,
            success: function (html) {
                $('#contentArea').html(html); // Reload updated MedicineManage partial
            },
            error: function (xhr, status, error) {
                console.error("AJAX Error:", status, error);
                $('#contentArea').html('<p class="text-danger">Error loading edit medicine form</p>');
            }
        });
    });

    // Handle Cancel button -> return to MedicineManage
    $(document).on('click', '#cancelEdit', function () {
        loadSection("MedicineManage");
    });

    $(document).on('click', '.editMedicineBtn', function (e) {
        e.preventDefault();

        let url = $(this).attr("href"); // /Admin/EditMedicine/123

        $.ajax({
            url: url,
            type: 'GET',
            success: function (html) {
                $('#contentArea').html(html); // Load Edit form partial into content area
            },
            error: function (xhr, status, error) {
                console.error("AJAX Error:", status, error);
                $('#contentArea').html('<p class="text-danger">Error loading edit form</p>');
            }
        });
    });

    $(document).on("click", ".viewMedicineBtn", function () {
        var id = $(this).data("id"); // grabs the medicine ID   

        $.ajax({
            url: '/Admin/GetMedicine',    
            type: "GET",
            data: { id: id },
            success: function (html) {
                $("#medicineDetailContainer").html(html);
            },
            error: function (xhr, status, error) {
                console.error("AJAX Error:", status, error);
                console.error("Response:", xhr.responseText);
                alert("Error loading medicine details");
            }
        });
    });
    $(document).on("click", ".closeMedicineCard", function () {
        $("#medicineDetailContainer").empty(); // remove card
    });

    $(document).on('submit', '#addVendorForm', function (e) {
        e.preventDefault();

        $.ajax({
            url: '/Admin/AddVendor',
            type: 'POST',
            data: new FormData(this),
            processData: false,
            contentType: false,
            success: function () {
                // Reuse your function
                loadSection("Vendors"); 
            },
            error: function (xhr, status, error) {
                console.error("AJAX Error:", status, error);
                console.error("Response:", xhr.responseText);
                $('#contentArea').html('<p>Error ' + xhr.status + ': ' + xhr.responseText + '</p>');
            }
        });
    });
    $(document).on('click', '.editVendorBtn', function (e) {
        e.preventDefault();

        let url = $(this).attr("href"); // /Admin/EditVendor/123

        $.ajax({
            url: url,
            type: 'GET',
            success: function (html) {
                $('#contentArea').html(html); // Load Edit form partial into content area
            },
            error: function (xhr, status, error) {
                console.error("AJAX Error:", status, error);
                $('#contentArea').html('<p class="text-danger">Error loading edit form</p>');
            }
        });
    });
    $(document).on('submit', '#editVendorForm', function (e) {
        e.preventDefault();

        $.ajax({
            url: '/Admin/AddVendor',
            type: 'POST',
            data: new FormData(this),
            processData: false,
            contentType: false,
            success: function () {
                // Reuse your function
                loadSection("Vendors"); 
            },
            error: function (xhr, status, error) {
                console.error("AJAX Error:", status, error);
                console.error("Response:", xhr.responseText);
                $('#contentArea').html('<p>Error ' + xhr.status + ': ' + xhr.responseText + '</p>');
            }
        });
    });
    $(document).on('click', '.deleteVendor', function (e) {
        e.preventDefault();

        let url = $(this).attr("href");  // will hold /Admin/DeleteMedicine/ID
        if (confirm("Are you sure you want to delete this Vendor?")) {
            $.ajax({
                url: url,
                type: 'POST', // or 'DELETE' if your controller supports it
                success: function () {
                    // Reload ManageMedicine partial after delete
                    loadSection("Vendors");
                },
                error: function (xhr, status, error) {
                    console.error("AJAX Error:", status, error);
                    console.error("Response:", xhr.responseText);
                    $('#contentArea').html('<p>Error ' + xhr.status + ': ' + xhr.responseText + '</p>');
                }
            });
        }
    });
    // Course management Add, Update, delete, list
    let resetBtn = document.getElementById("resetCourseForm");
    if (resetBtn) {
        resetBtn.addEventListener("click", function () {
            const form = document.getElementById("addCourseForm");
            if (form) {
                form.reset();
                form.querySelectorAll(".text-danger").forEach(span => span.innerText = "");
                if (typeof ($) !== "undefined") {
                    $(form).validate().resetForm();
                    $(form).find(".input-validation-error").removeClass("input-validation-error");
                }
            }
        });
    }
    $(document).on('submit', '#addCourseForm', function (e) {
        e.preventDefault();

        $.ajax({
            url: '/Course/AddCourse',
            type: 'POST',
            data: new FormData(this),
            processData: false,
            contentType: false,
            success: function (response, status, xhr) {
                const contentType = xhr.getResponseHeader("content-type");

                if (contentType && contentType.indexOf("application/json") >= 0) {
                    // JSON case (error)
                    if (response.success === false) {
                        alert("Error: " + response.message);
                    }
                } else {
                    // HTML case (partial view returned)
                    $('#contentArea').html(response);
                }
            },
            error: function (xhr, status, error) {
                console.error("AJAX Error:", status, error);
                console.error("Response:", xhr.responseText);
                $('#contentArea').html('<p>Error ' + xhr.status + ': ' + xhr.responseText + '</p>');
            }
        });
    });
    $(document).on("click", ".btnDeleteCourse", function () {
        //alert("Delete button clicked!");
        //console.log("Delete button clicked"); 
        var id = $(this).data("id");
        if (!confirm("Are you sure you want to delete this Course?")) return;
        $.ajax({
            url: '/Course/DeleteCourse',   // POST endpoint
            type: 'POST',
            data: { id: id },
            success: function (response) {
                if (response.success) {
                    loadSection("Courses"); // reload list
                } else {
                    alert("Delete failed");
                }
            },
            error: function () {
                alert("Error contacting server");
            }
        });
    });
    $(document).on("click", ".btnEditCourse", function () {
        //alert("Edit button clicked!");
        var id = $(this).data("id");
        $.ajax({
            url: '/Course/EditCourse',   // POST endpoint
            type: 'GET',
            data: { id: id },
            success: function (html) {
                $('#contentArea').html(html);
            },
            error: function () {
                alert("Error contacting server");
            }
        });
    });
    $(document).on("submit", "#editCourseForm", function (e) {
        e.preventDefault(); // STOP the default form submission

        if (!confirm("Are you sure you want to edit this Course?")) return;

        $.ajax({
            url: '/Course/EditCourse',   // POST endpoint
            type: 'POST',
            data: new FormData(this),
            processData: false,
            contentType: false,
            success: function (html) {
                $('#contentArea').html(html); // load partial into content area
            },
            error: function (xhr, status, error) {
                console.error("AJAX Error:", status, error);
                console.error("Response:", xhr.responseText);
                alert("Error contacting server");
            }
        });
    });
    $(document).ready(function () {
        // When profile button is clicked
        $("#adminProfile").on("click", function (e) {
            e.preventDefault(); // stop default link action

            $.ajax({
                url: '/Admin/AdminProfile',   // Controller action
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
        $(document).on("click", "#editAdminProfile", function (e) {
            e.preventDefault();

            $.ajax({
                url: '/Admin/EditAdminProfile',
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
    $(document).on("click", "#backToDashboardBtn", function(e) {
        e.preventDefault();

        // Optional: show loading indicator
        $("#contentArea").html('<div class="text-center my-5"><span class="spinner-border text-primary"></span> Loading...</div>');

        $.ajax({
            url: '/Ebooks/AddEbooks', // Your Admin Dashboard action
            type: 'GET',
            success: function() {
                loadSection("EBooks"); 
            },
            error: function(xhr, status, error) {
                $("#contentArea").html('<div class="alert alert-danger">Failed to load Ebooks Manage. Please try again.</div>');
                console.error(error);
            }
        });
    });
    
});
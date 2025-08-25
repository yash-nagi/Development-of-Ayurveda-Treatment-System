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
            url: "/Admin/GetMedicineAsync",   // ✅ corrected controller
            type: "GET",
            data: { id: id },
            success: function (html) {
                $("#contentArea").html(html); // load partial into contentArea
            },
            error: function (xhr, status, error) {
                console.error("AJAX Error:", status, error);
                console.error("Response:", xhr.responseText);
                alert("Error loading medicine details");
            }
        });
    });

});
document.getElementById("addCourseForm").addEventListener("submit", function (e) {
            let isValid = true;

            // Clear old errors
            document.querySelectorAll(".text-danger").forEach(span => span.innerText = "");

            const courseId = document.getElementById("CourseId").value.trim();
            const courseName = document.getElementById("CourseName").value.trim();
            const courseDuration = document.getElementById("CourseDuration").value.trim();
            const feeStruc = document.getElementById("CourseFeeStruc").value.trim();
            const benefits = document.getElementById("Benefits").value.trim();
            const instName = document.getElementById("InstituteName").value.trim();
            const contactNo = document.getElementById("InstituteContactNo").value.trim();
            const instAddress = document.getElementById("InstituteAddress").value.trim();

            // Required field validation
            if (!courseId) { document.getElementById("CourseIdError").innerText = "Course ID is required."; isValid = false; }
            if (!courseName) { document.getElementById("CourseNameError").innerText = "Course Name is required."; isValid = false; }
            if (!courseDuration) { document.getElementById("CourseDurationError").innerText = "Course Duration is required."; isValid = false; }
            if (!feeStruc) { document.getElementById("CourseFeeStrucError").innerText = "Fee Structure is required."; isValid = false; }
            if (!benefits) { document.getElementById("BenefitsError").innerText = "Benefits are required."; isValid = false; }
            if (!instName) { document.getElementById("InstituteNameError").innerText = "Institute Name is required."; isValid = false; }
            if (!instAddress) { document.getElementById("InstituteAddressError").innerText = "Institute Address is required."; isValid = false; }

            // Contact number validation
            if (!contactNo) {
                document.getElementById("InstituteContactNoError").innerText = "Contact number is required.";
                isValid = false;
            } else if (!/^[0-9]{10}$/.test(contactNo)) {
                document.getElementById("InstituteContactNoError").innerText = "Contact number must be exactly 10 digits.";
                isValid = false;
            }

            // Stop form submit if invalid
            if (!isValid) e.preventDefault();
        });

        // Reset form handler
        document.getElementById("resetCourseForm").addEventListener("click", function () {
            document.querySelectorAll(".text-danger").forEach(span => span.innerText = "");
        });
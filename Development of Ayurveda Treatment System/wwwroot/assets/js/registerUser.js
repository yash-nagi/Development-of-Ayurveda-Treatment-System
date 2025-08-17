
    document.addEventListener("DOMContentLoaded", function () {
        const form = document.getElementById("multiStepForm");
        const steps = document.querySelectorAll(".form-step");
        const progressBar = document.getElementById("progressBar");
        const progressText = document.getElementById("progressText");
        const nextBtn = document.getElementById("nextBtn");
        const prevBtn = document.getElementById("prevBtn");
        const submitBtn = document.getElementById("submitBtn");

        let currentStep = 0;

        // Show step
        function showStep(index) {
            steps.forEach((step, i) => {
                step.classList.toggle("active", i === index);
            });

            // progress update
            progressBar.style.width = ((index + 1) / steps.length) * 100 + "%";
            progressText.innerText = `Step ${index + 1} of ${steps.length}`;

            // button toggle
            prevBtn.style.display = index === 0 ? "none" : "inline-block";
            nextBtn.style.display = index === steps.length - 1 ? "none" : "inline-block";
            submitBtn.classList.toggle("d-none", index !== steps.length - 1);
        }

        // Validation function
        function validateStep(stepIndex) {
            let valid = true;
            const inputs = steps[stepIndex].querySelectorAll("input, select");

            inputs.forEach(input => {
                const errorId = input.id + "-error";
                let error = document.getElementById(errorId);

                if (!error) {
                    error = document.createElement("span");
                    error.id = errorId;
                    error.classList.add("text-danger");
                    input.insertAdjacentElement("afterend", error);
                }

                error.innerText = "";
                input.classList.remove("is-invalid");

                // Required validation
                if (input.name !== "MiddleName" && input.type !== "file" && input.value.trim() === "") {
                    error.innerText = "This field is required.";
                    input.classList.add("is-invalid");
                    valid = false;
                    return;
                }

                // Gender validation
                if (input.name === "Gender") {
                    if (input.value === "") {
                        error.innerText = "Please select your gender.";
                        input.classList.add("is-invalid");
                        valid = false;
                    }
                }

                // UserType (role) validation
                if (input.name === "UserType" && input.value === "") {
                    error.innerText = "Please select your role.";
                    input.classList.add("is-invalid");
                    valid = false;
                }

                // Email validation
                if (input.name === "Email") {
                    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
                    if (!regex.test(input.value)) {
                        error.innerText = "Enter a valid email address.";
                        input.classList.add("is-invalid");
                        valid = false;
                    }
                }

                // Mobile No validation (10 digits)
                if (input.name === "MobileNo") {
                    if (!/^\d{10}$/.test(input.value)) {
                        error.innerText = "Mobile No must be exactly 10 digits.";
                        input.classList.add("is-invalid");
                        valid = false;
                    }
                }

                // Phone No validation (11 digits)
                if (input.name === "PhoneNo") {
                    if (!/^\d{11}$/.test(input.value)) {
                        error.innerText = "Phone No must be exactly 11 digits.";
                        input.classList.add("is-invalid");
                        valid = false;
                    }
                }
                //  Password & Confirm Password validation
                if (input.name === "Password" || input.id === "ConfirmPassword") {
                    const password = form.querySelector("input[name='Password']").value;
                    const confirmPassword = form.querySelector("#ConfirmPassword").value;

                    if (password.trim() === "" || confirmPassword.trim() === "") {
                        error.innerText = "Password and Confirm Password are required.";
                        input.classList.add("is-invalid");
                        valid = false;
                    } else if (password !== confirmPassword) {
                        if (input.id === "ConfirmPassword") {
                            error.innerText = "Passwords do not match.";
                            input.classList.add("is-invalid");
                            valid = false;
                        }
                    }
                }
            });

            return valid;
        }

        // Next button
        nextBtn.addEventListener("click", function () {
            if (validateStep(currentStep)) {
                currentStep++;
                showStep(currentStep);
            }
        });

        // Previous button
        prevBtn.addEventListener("click", function () {
            currentStep--;
            showStep(currentStep);
        });

        // Final validation on submit
        form.addEventListener("submit", function (e) {
            if (!validateStep(currentStep)) {
                e.preventDefault();
            }
        });

        // Init
        showStep(currentStep);
    });


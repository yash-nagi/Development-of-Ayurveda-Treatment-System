/*$(function () {
    console.log("✅ register.js loaded");
    const form = document.getElementById("multiStepForm");
    const steps = document.querySelectorAll(".form-step");
    const nextBtn = document.getElementById("nextBtn");
    const prevBtn = document.getElementById("prevBtn");
    const submitBtn = document.getElementById("submitBtn");
    const progressBar = document.getElementById("progressBar");
    const progressText = document.getElementById("progressText");

    let currentStep = 0;

    // Initialize
    showStep(currentStep);

    nextBtn.addEventListener("click", () => {
        if (validateStep(currentStep)) {
            steps[currentStep].classList.remove("active");
            currentStep++;
            showStep(currentStep);
        }
    });

    prevBtn.addEventListener("click", () => {
        if (currentStep > 0) {
            steps[currentStep].classList.remove("active");
            currentStep--;
            showStep(currentStep);
        }
    });

    function showStep(step) {
        steps[step].classList.add("active");

        // Update buttons
        prevBtn.style.display = step === 0 ? "none" : "inline-block";
        nextBtn.classList.toggle("d-none", step === steps.length - 1);
        submitBtn.classList.toggle("d-none", step !== steps.length - 1);

        // Update progress bar and text
        const percent = ((step + 1) / steps.length) * 100;
        progressBar.style.width = percent + "%";
        progressText.innerText = `Step ${step + 1} of ${steps.length}`;
    }

    function validateStep(step) {
        const currentStepEl = steps[step];
        const inputs = currentStepEl.querySelectorAll("input, select, textarea");
        let isValid = true;

        // Trigger jQuery validation
        inputs.forEach(input => {
            $(input).removeClass("input-validation-error");
            $(input).valid();

            if (!input.checkValidity()) {
                $(input).addClass("input-validation-error");
                isValid = false;
            }
        });

        // Password match check on step 0
        if (step === 0) {
            const password = document.getElementById("Password").value;
            const confirmPassword = document.getElementById("ConfirmPassword").value;

            if (password !== confirmPassword) {
                alert("Password and Confirm Password must match.");
                document.getElementById("ConfirmPassword").classList.add("input-validation-error");
                isValid = false;
            }
        }

        return isValid;
    }
});*/
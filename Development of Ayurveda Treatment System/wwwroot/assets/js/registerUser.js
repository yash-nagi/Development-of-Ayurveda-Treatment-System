
let currentStep = 0;
const steps = document.querySelectorAll(".form-step");
const progressBar = document.getElementById("progressBar");
const progressText = document.getElementById("progressText");
const nextBtn = document.getElementById("nextBtn");
const prevBtn = document.getElementById("prevBtn");
const submitBtn = document.getElementById("submitBtn");

showStep(currentStep);

nextBtn.addEventListener("click", () => {
    if (currentStep < steps.length - 1) {
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

    prevBtn.style.display = step === 0 ? "none" : "inline-block";
    nextBtn.classList.toggle("d-none", step === steps.length - 1);
    submitBtn.classList.toggle("d-none", step !== steps.length - 1);

    const percent = ((step + 1) / steps.length) * 100;
    progressBar.style.width = percent + "%";
    progressText.innerText = `Step ${step + 1} of ${steps.length}`;
}

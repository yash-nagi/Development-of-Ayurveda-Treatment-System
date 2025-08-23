document.addEventListener("DOMContentLoaded", function() {
        var showBtn = document.getElementById("showForgotPassword");
        var cancelBtn = document.getElementById("cancelResetPassword");
        var loginForm = document.getElementById("loginForm");
        var resetForm = document.getElementById("resetPasswordForm");

        showBtn.addEventListener("click", function(e) {
            e.preventDefault();
            loginForm.style.display = "none";
            resetForm.style.display = "block";
        });

        cancelBtn.addEventListener("click", function() {
            resetForm.style.display = "none";
            loginForm.style.display = "block";
        });
    });
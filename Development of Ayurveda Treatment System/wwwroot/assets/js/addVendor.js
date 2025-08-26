document.addEventListener("DOMContentLoaded", function () {
    e.preventDefault();
    const form = document.getElementById("addVendorForm");

    form.addEventListener("submit", function (e) {
        let isValid = true;
        let messages = [];

        const vendorName = document.getElementById("VendorName").value.trim();
        const email = document.getElementById("Email").value.trim();
        const contactNo = document.getElementById("ContactNo").value.trim();
        const address = document.getElementById("Address").value.trim();
        const regNo = document.getElementById("RegistrationNo").value.trim();
        const faxNo = document.getElementById("FaxNo").value.trim();

        // Vendor name check
        if (!vendorName) {
            isValid = false;
            messages.push("Vendor Name is required.");
        }

        // Email regex check
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!email) {
            isValid = false;
            messages.push("Email is required.");
        } else if (!emailRegex.test(email)) {
            isValid = false;
            messages.push("Invalid email format.");
        }

        // Contact number check
        if (!contactNo) {
            isValid = false;
            messages.push("Contact number is required.");
        }

        if (!address) {
            isValid = false;
            messages.push("Address is required.");
        }

        if (!regNo) {
            isValid = false;
            messages.push("Registration number is required.");
        }

        if (!faxNo) {
            isValid = false;
            messages.push("Fax number is required.");
        }

        if (!isValid) {
            e.preventDefault();
            alert(messages.join("\n"));
        }
    });
});

$(document).ready(function () {

    function showError(message) {
        $("#paymentMessage").html('<div class="alert alert-danger">' + message + '</div>');
    }

    function validateCreditCard() {
        console.log("Validation message");
        var ccNumber = $("#CreditCard_CreditCardID").val().trim();
        var ccName = $("#CreditCard_CardHolderName").val().trim();
        var ccExp = $("#CreditCard_CardExpDate").val().trim();
        var ccAmount = $("#CreditCard_PaymentAmount").val().trim();

        if (!ccNumber) { showError("Credit Card Number is required."); return false; }
        if (!/^\d{16}$/.test(ccNumber)) { showError("Credit Card Number must be 16 digits."); return false; }
        if (!ccName) { showError("Card Holder Name is required."); return false; }
        if (!ccExp) { showError("Expiry Date is required."); return false; }
        if (!ccAmount) { showError("Payment Amount is missing."); return false; }

        return true;
    }

    function validateDebitCard() {
        var dcNumber = $("#DebitCard_DebitCardID").val().trim();
        var dcName = $("#DebitCard_CardHolderName").val().trim();
        var dcExp = $("#DebitCard_CardExpDate").val().trim();
        var dcAmount = $("#DebitCard_PaymentAmount").val().trim();

        if (!dcNumber) { showError("Debit Card Number is required."); return false; }
        if (!/^\d{16}$/.test(dcNumber)) { showError("Debit Card Number must be 16 digits."); return false; }
        if (!dcName) { showError("Card Holder Name is required."); return false; }
        if (!dcExp) { showError("Expiry Date is required."); return false; }
        if (!dcAmount) { showError("Payment Amount is missing."); return false; }

        return true;
    }

    function validateInternetBanking() {
        var accNo = $("#InternetBanking_AccountNo").val().trim();
        var bankName = $("#InternetBanking_BankName").val().trim();
        var branch = $("#InternetBanking_BankBranch").val().trim();
        var ifsc = $("#InternetBanking_IFSCCode").val().trim();

        if (!accNo) { showError("Account Number is required."); return false; }
        if (!/^\d{9,18}$/.test(accNo)) { showError("Account Number must be 9-18 digits."); return false; }
        if (!bankName) { showError("Bank Name is required."); return false; }
        if (!branch) { showError("Branch is required."); return false; }
        if (!ifsc) { showError("IFSC Code is required."); return false; }
        if (!/^[A-Z]{4}0[A-Z0-9]{6}$/.test(ifsc)) { showError("Invalid IFSC Code format."); return false; }

        return true;
    }

    // Credit Card Submission
    $(document).on("submit", "#creditCardForm form", function(e) {
        e.preventDefault();
        if (!validateCreditCard()) return;

        var form = $(this);
        $.ajax({
            url: '/Payment/Payment',
            type: 'POST',
            data: form.serialize(),
            success: function (response) {
                if (typeof response === "object" && response.Message) {
                    showError(response.Message);
                } else {
                    $("#paymentMessage").html('<div class="alert alert-success">' + response.message + '</div>');
                    $("#creditCardForm form")[0].reset();
                }
            },
            error: function () {
                showError("Payment failed. Please try again.");
            }
        });
    });

    // Debit Card Submission
    $(document).on("submit", "#debitCardForm form", function(e) {
        e.preventDefault();
        if (!validateDebitCard()) return;

        var form = $(this);
        $.ajax({
            url: '/Payment/Payment',
            type: 'POST',
            data: form.serialize(),
            success: function (response) {
                if (typeof response === "object" && response.Message) {
                    showError(response.Message);
                } else {
                    $("#paymentMessage").html('<div class="alert alert-success">' + response.message + '</div>');
                    $("#debitCardForm form")[0].reset();
                }
            },
            error: function () {
                showError("Payment failed. Please try again.");
            }
        });
    });

    // Internet Banking Submission
    $(document).on("submit", "#netBankingForm form", function(e) {
        e.preventDefault();
        if (!validateInternetBanking()) return;

        var form = $(this);
        $.ajax({
            url: '/Payment/Payment',
            type: 'POST',
            data: form.serialize(),
            success: function (response) {
                if (typeof response === "object" && response.Message) {
                    showError(response.Message);
                } else {
                    $("#paymentMessage").html('<div class="alert alert-success">' + response.message + '</div>');
                    $("#netBankingForm form")[0].reset();
                }
            },
            error: function () {
                showError("Payment failed. Please try again.");
            }
        });
    });

});

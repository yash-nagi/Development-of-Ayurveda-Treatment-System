using System.ComponentModel;
using System.Threading.Tasks;
using Development_of_Ayurveda_Treatment_System.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class PaymentController : Controller
    {
        private AyurgrowDBContext _db;
        public PaymentController(AyurgrowDBContext context)
        {
            _db = context;
        }
        // GET: PaymentController
        public ActionResult Payment(string userId, string vendorId, int medicineNo, int quantity, string paymentMode, string medicineId)
        {
            var medicine = _db.Medicines.FirstOrDefault(m => m.MedicineNo == medicineNo);
            if (medicine == null)
                return Content("Medicine not found");

            var amount = quantity * medicine.Price;

            var model = new PaymentViewModel
            {
                UserId = userId,
                VendorId = vendorId,
                Amount = Convert.ToInt64(amount),
                PaymentMode = paymentMode,
                CreditCard = new CredeitCard { PaymentAmount = Convert.ToInt64(amount) },
                DebitCard = new DebitCard { PaymentAmount = Convert.ToInt64(amount) },
                InternetBanking = new InternetBanking(),
                MedicineId = medicineId,
                Quantity = quantity,
                MedicineNo = medicineNo
            };

            ViewBag.PaymentMode = paymentMode; // Optional: to highlight selected payment mode

            return PartialView("~/Views/Payment/Payment.cshtml", model);
        }
        [HttpPost]
        public async Task<ActionResult> Payment(PaymentViewModel model)
        {
            if (model.Amount == null || model.MedicineId == null || model.MedicineNo == null || model.PaymentMode == null || model.Quantity == null)
            {
                return Json(new { success = false, message = "Payment can not be successful." });
            }
            bool PaymentModeResult;
            var medBookResult = await SaveMedicineBooking(model);
            var vendorBookResult = await SaveVendorBooking(model);
            if (model.PaymentMode == "Debit Card")
            {
                PaymentModeResult = await SaveDebitCard(model);
            }
            else if (model.PaymentMode == "Credit Card")
            {
                PaymentModeResult = await SaveCreditCard(model);
            }
            else
            {
                PaymentModeResult = await SaveInternetBanking(model);
            }
            bool paymentResult = await SavePayment(model);
            if (medBookResult == true && vendorBookResult == true && PaymentModeResult == true && paymentResult == true)
            {
                return Json(new { success = true, message = "Payment successful! Thank you for your purchase. You may return to dashboard for more exploration." });
            }
            else
            {
                return Json(new { success = false, Message = "Payment failed! Please try again later. Any query conatact to admin." });
            }
            // Vendor boking
        }
        public async Task<bool> SaveMedicineBooking(PaymentViewModel model)
        {
            try
            {
                MedicineBooking medicineBooking = new MedicineBooking();
                medicineBooking.ID = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                medicineBooking.BookingId = new Random().Next(10000000, 100000000);
                medicineBooking.MedicineNo = model.MedicineNo;
                medicineBooking.PaymentMode = model.PaymentMode;
                medicineBooking.UserId = model.UserId;
                medicineBooking.VendorId = model.VendorId;
                medicineBooking.Quantity = model.Quantity;
                medicineBooking.MedicineId = model.MedicineId;
                if (model.PaymentMode == "Debit Card")
                {
                    medicineBooking.BookingDate = model.DebitCard.DateOfPayment;
                }
                else if (model.PaymentMode == "Credit Card")
                {
                    medicineBooking.BookingDate = model.CreditCard.DateOfPayment;
                }
                else
                {
                    medicineBooking.BookingDate = DateTime.Now;
                }
                var medicineBook = _db.MedicineBooking.FirstOrDefault(m => m.ID == medicineBooking.ID);
                if (medicineBook == null)
                {
                    _db.MedicineBooking.Add(medicineBooking);
                    await _db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public async Task<bool> SaveVendorBooking(PaymentViewModel model)
        {
            try
            {
                VendorBooking vendorBooking = new VendorBooking();
                vendorBooking.ID = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                vendorBooking.MedicineNo = model.MedicineNo;
                vendorBooking.BookingID = _db.MedicineBooking.FirstOrDefault(x => x.MedicineId == model.MedicineId)?.BookingId.ToString();
                vendorBooking.BookingDate = (DateTime)_db.MedicineBooking.FirstOrDefault(x => x.MedicineId == model.MedicineId)?.BookingDate;
                vendorBooking.VendorD = model.VendorId;
                vendorBooking.PaymentMode = model.PaymentMode;
                var vendorBook = _db.VendorBookings.FirstOrDefault(m => m.ID == vendorBooking.ID);
                if (vendorBook == null)
                {
                    _db.VendorBookings.Add(vendorBooking);
                    await _db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public async Task<bool> SaveDebitCard(PaymentViewModel model)
        {
            try
            {
                DebitCard debitCard = new DebitCard();
                debitCard.ID = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                debitCard.UserId = model.UserId;
                debitCard.DebitCardID = model.DebitCard.DebitCardID;
                debitCard.PaymentAmount = model.Amount;
                debitCard.DateOfPayment = DateTime.Now;
                debitCard.CardHolderName = model.DebitCard.CardHolderName;
                debitCard.CardExpDate = model.DebitCard.CardExpDate;
                _db.DebitCards.Add(debitCard);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public async Task<bool> SaveCreditCard(PaymentViewModel model)
        {
            try
            {
                CredeitCard credeitCard = new CredeitCard();
                credeitCard.ID = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                credeitCard.UserId = model.UserId;
                credeitCard.PaymentAmount = model.Amount;
                credeitCard.DateOfPayment = DateTime.Now;
                credeitCard.CreditCardID = model.CreditCard.CreditCardID;
                credeitCard.CardHolderName = model.CreditCard.CardHolderName;
                credeitCard.CardExpDate = model.CreditCard.CardExpDate;
                _db.CredeitCards.Add(credeitCard);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public async Task<bool> SaveInternetBanking(PaymentViewModel model)
        {
            try
            {
                InternetBanking banking = new InternetBanking();
                banking.ID = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                banking.UserId = model.UserId;
                banking.AccountNo = model.InternetBanking.AccountNo;
                banking.BankName = model.InternetBanking.BankName;
                banking.BankBranch = model.InternetBanking.BankBranch;
                banking.IFSCCode = model.InternetBanking.IFSCCode;
                banking.IT_ID = model.InternetBanking.IT_ID;
                _db.InternetBankings.Add(banking);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public async Task<bool> SavePayment(PaymentViewModel model)
        {
            try
            {
                Payment payment = new Payment();
                payment.ID = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                payment.UserId = model.UserId;
                payment.PaymentMode = model.PaymentMode;
                payment.Amount = model.Amount;
                if (model.CreditCard != null)
                {
                    payment.CreditCardID = model.CreditCard.CreditCardID;
                }
                if (model.DebitCard != null)
                {
                    payment.DebitCardID = model.DebitCard.DebitCardID;
                }
                payment.PaymentDate = DateTime.Now;
                if (model.InternetBanking != null)
                {
                    payment.InternetBanking = model.InternetBanking.ID;
                }
                else
                {
                    payment.InternetBanking = string.Empty;
                }
                payment.ReceiptNo = new Random().Next(10000000, 100000000);
                _db.Payments.Add(payment);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}

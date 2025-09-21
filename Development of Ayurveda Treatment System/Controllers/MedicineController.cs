using System.Security.Claims;
using Development_of_Ayurveda_Treatment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class MedicineController : Controller
    {
        private AyurgrowDBContext _db;
        public MedicineController(AyurgrowDBContext context)
        {
            _db = context;
        }
        // GET: MedicineController
        public IActionResult Index()
        {
            var medicines = _db.Medicines.ToList();
            if (medicines != null)
            {
                return PartialView("~/Views/Medicine/Medicine.cshtml", medicines);
            }
            else
            {
                return Json(new { Message = "Somethis went wrong!" });
            }
        }
        [HttpGet]
        public IActionResult BookMedicine(string id, int quantity)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var medicine = _db.Medicines.FirstOrDefault(m => m.ID == id);
            if (medicine == null) return NotFound();
            var vendors = _db.Vendors.ToList(); // Load vendors list from DB
            var model = new MedicineBookingViewModel
            {
                Medicine = medicine,
                Booking = new MedicineBooking
                {
                    MedicineNo = medicine.MedicineNo,
                    Quantity = quantity,
                    BookingDate = DateTime.Now,
                    UserId = userId,
                    MedicineId = medicine.ID
                },
                Vendors = vendors
            };
            return PartialView("~/Views/Medicine/BookMedicine.cshtml", model); // Use partial view for AJAX
        }
    }
}

using System.Drawing;
using System.Threading.Tasks;
using Development_of_Ayurveda_Treatment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class AppointmentController : Controller
    {
        private AyurgrowDBContext _db;
        public AppointmentController(AyurgrowDBContext context)
        {
            _db = context;
        }
        // GET: AppointmentController
        public ActionResult Appointment(string doctorId, string doctorName, long consultationFee)
        {
            Appointment appointment = new Appointment
            {
                DoctorId = doctorId,
                UserId = HttpContext.Session.GetString("UserId"),
                ConsultationFee = consultationFee,
                DoctorName = doctorName
            };
            return PartialView("~/Views/Appointment/Appointment.cshtml", appointment);
        }
        [HttpPost]
        public async Task<ActionResult> Appointment(Appointment model)
        {
            try
            {
                Appointment appointment = new Appointment
                {
                    ID = Guid.NewGuid().ToString().ToUpper().Replace("-", ""),
                    DoctorId = model.DoctorId,
                    UserId = model.UserId,
                    ConsultationFee = model.ConsultationFee,
                    DoctorName = model.DoctorName,
                    AppointmentDate = model.AppointmentDate,
                    AppointmentTime = model.AppointmentTime
                };
                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "Appointment successfully booked." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"{ex.Message}" });
            }
        }
    }
}

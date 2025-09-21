using Microsoft.AspNetCore.Mvc;
using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Services;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AyurgrowDBContext _db;
        private readonly DoctorsService _doctorsService;
        public DoctorsController(AyurgrowDBContext db, DoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
            _db = db;
        }
        // GET: DoctorsController
        [HttpGet]
        public ActionResult AddDoctor()
        {
            return PartialView("~/Views/Doctors/AddDoctors.cshtml", new Doctor());
        }
        [HttpPost]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            try
            {
                ModelState.Remove(nameof(doctor.AppointmentID));
                ModelState.Remove(nameof(doctor.DoctorId));
                if (ModelState.IsValid)
                {
                    doctor.DoctorId = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                    doctor.AppointmentID = string.Empty;
                    var doctorAddResult = await _doctorsService.AddDoctor(doctor);
                    if (doctorAddResult.IsSuccess)
                    {
                        return PartialView("~/Views/Doctors/ManageDoctors.cshtml", _db.Doctors.ToList());
                    }
                    else
                    {
                        return Json(new { success = false, message = doctorAddResult.message.ToString() });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Model state is not valid." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message.ToString() });
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditDoctor(string id)
        {
            try
            {
                var doctor = await _doctorsService.GetDoctor(id);
                if (doctor != null)
                {
                    return PartialView("~/Views/Doctors/EditDoctor.cshtml", doctor);
                }
                else
                {
                    return Json(new { success = false, message = "Doctor not found." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message.ToString() });
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditDoctor(Doctor model)
        {
            try
            {
                var result = await _doctorsService.EditDoctor(model);
                if (result.IsSuccess)
                {
                    return PartialView("~/Views/Doctors/ManageDoctors.cshtml", _db.Doctors.ToList());
                }
                else
                {
                    return Json(new { success = false, message = result.message });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message.ToString() });
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            try
            {
                var result = await _doctorsService.DeleteDoctor(id);
                if (result)
                {
                    return PartialView("~/Views/Doctors/ManageDoctors.cshtml", _db.Doctors.ToList());
                }
                else
                {
                    return Json(new { success = false, message = "Failed to delete doctor." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message.ToString() });
            }
        }
        public async Task<IActionResult> Doctors()
        {
            return PartialView("~/Views/Doctors/Doctors.cshtml", _db.Doctors.ToList());
        }
    }
}

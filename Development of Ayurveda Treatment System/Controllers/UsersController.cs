using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class UsersController : Controller
    {
        private UserService _userService;
        private LoginSevice _loginSevice;
        private readonly AyurgrowDBContext _db;
        public UsersController(UserService userService, LoginSevice loginSevice, AyurgrowDBContext dBContext)
        {
            _userService = userService;
            _loginSevice = loginSevice;
            _db = dBContext;
        }
        // GET: UsersController
        public async Task<ActionResult> UserDashboard(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                Users _users = await _userService.GetByEmailAndPasswordAsync(email, password);
                if (_users != null)
                {
                    HttpContext.Session.SetString("UserId", _users.UserId);
                    var model = new UserDashboardViewModel
                    {
                        TotalAppointments = _db.Appointments.Count(a => a.UserId == _users.UserId),
                        CompletedAppointments = _db.Appointments.Count(a => a.UserId == _users.UserId && a.AppointmentDate < DateTime.Now),
                        PendingAppointments = _db.Appointments.Count(a => a.UserId == _users.UserId && a.AppointmentDate >= DateTime.Now),
                        TotalPayments = _db.Payments.Count(p => p.UserId == _users.UserId),
                        TotalAmountPaid = _db.Payments.Where(p => p.UserId == _users.UserId).Sum(p => p.Amount)
                    };
                    return View("UserDashboard", model);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public async Task<ActionResult> Home()
        {
            var userId = HttpContext.Session.GetString("UserId");

            if (!string.IsNullOrEmpty(userId))
            {
                var model = new UserDashboardViewModel
                {
                    TotalAppointments = _db.Appointments.Count(a => a.UserId == userId),
                    CompletedAppointments = _db.Appointments.Count(a => a.UserId == userId && a.AppointmentDate < DateTime.Now),
                    PendingAppointments = _db.Appointments.Count(a => a.UserId == userId && a.AppointmentDate >= DateTime.Now),
                    TotalPayments = _db.Payments.Count(p => p.UserId == userId),
                    TotalAmountPaid = _db.Payments.Where(p => p.UserId == userId).Sum(p => p.Amount)
                };
                return View("UserDashboard", model);
            }
            else
            {
                // session expired or not logged in
                return RedirectToAction("Login", "Users");
            }
        }

        public IActionResult UserProfile()
        {
            // For example, get currently logged-in user from DB
            var user = _db.Users.FirstOrDefault(u => u.UserType == "User");
            return PartialView("~/Views/Users/UserProfile.cshtml", user);
        }

        public IActionResult EditUserProfile(string userId)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserId == userId.ToString()); 
            return PartialView("~/Views/Users/EditProfile.cshtml", user);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        public IActionResult LoadSection(string section)
        {
            switch (section)
            {
                case "Medicine":
                    return PartialView("~/Views/Medicine/Medicine.cshtml", _db.Medicines.ToList());
                case "Vendors":
                    return PartialView("~/Views/Vendors/Vendors.cshtml", _db.Vendors.ToList());
                case "Courses":
                    return PartialView("~/Views/Courses/Courses.cshtml", _db.Courses.ToList());
                case "EBooks":
                    return PartialView("~/Views/EBooks/EBooks.cshtml", _db.EBooks.ToList());
                case "Billings":
                    return PartialView("~/Views/Billings/Billings.cshtml", _db.Payments.ToList());
                case "Doctors":
                    return PartialView("~/Views/Doctors/Doctors.cshtml", _db.Doctors.ToList());
                case "Feedback":
                    return PartialView("~/Views/Feedback/Feedback.cshtml");
                case "Reports":
                    return PartialView("~/Views/Reports/Reports.cshtml");
                //case "Policies":
                //    return PartialView("~/Views/Policies/Policies.cshtml");
                // add other sections...
                default:
                    return Content("<p>Section not found.</p>");
            }
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Users _users, Login _login)
        {
            try
            {
                _users.UserId = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                if (_users.MiddleName == null)
                {
                    _users.MiddleName = string.Empty;
                }                
                _login.Id = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                _login.Role = _users.UserType;
                ModelState.Remove(nameof(_users.UserId));
                ModelState.Remove(nameof(_users.MiddleName));
                ModelState.Remove(nameof(_login.Id));
                ModelState.Remove(nameof(_login.Role));
                ModelState.Remove(nameof(_users.Image));
                ModelState.Remove(nameof(_users.ProfilePhoto));
                ModelState.Remove(nameof(_users.UploadedFile));
                if (!ModelState.IsValid)
                    return View(_users);

                var result = await _userService.RegisterUserAsync(_users);
                var loginResult = await _loginSevice.NewLoginUserAsync(_login);

                if (result.IsSuccess && loginResult.IsSuccess)
                {
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View(_users);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Users _users)
        {
            try
            {
                if (_users.MiddleName == null)
                {
                    _users.MiddleName = string.Empty;
                }
                ModelState.Remove(nameof(_users.UserId));
                ModelState.Remove(nameof(_users.MiddleName));
                ModelState.Remove(nameof(_users.Image));
                ModelState.Remove(nameof(_users.ProfilePhoto));
                ModelState.Remove(nameof(_users.UploadedFile));
                if (!ModelState.IsValid)
                    return View(_users);

                var result = await _userService.EditeUserAsync(_users);

                if (result.IsSuccess)
                {
                    if (_users.UserType == "Admin")
                    {
                        return RedirectToAction("AdminDashboard", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("UserDashboard", "Users" );
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View(_users);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(UserDashboard));
            }
            catch
            {
                return View();
            }
        }
    }
}

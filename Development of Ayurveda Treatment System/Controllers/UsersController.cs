using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class UsersController : Controller
    {
        private UserService _userService;
        private LoginSevice _loginSevice;
        public UsersController(UserService userService, LoginSevice loginSevice)
        {
            _userService = userService;
            _loginSevice = loginSevice;
        }
        // GET: UsersController
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

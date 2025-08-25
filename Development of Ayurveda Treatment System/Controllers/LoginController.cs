using Microsoft.AspNetCore.Mvc;
using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Services;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class LoginController : Controller
    {
        private LoginSevice _loginSevice;
        private UserService _userService;
        public LoginController(LoginSevice loginSevice, UserService userServic)
        {
            _loginSevice = loginSevice;
            _userService = userServic;
        }
        // POST: LoginController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login _login)
        {
            try
            {
                //if (!ModelState.IsValid)
                //    return View(_login);

                var result = await _loginSevice.Login(_login);
                if (result.IsValidate)
                {
                    Console.WriteLine(result.Message);
                    if (result.login.Role == "User")
                    {
                        return RedirectToAction("UserDashboard", "Users", new { email = result.login.Email, password = result.login.Password });
                    }
                    else if (result.login.Role == "Admin")
                    {
                        return RedirectToAction("AdminDashboard", "Admin");
                    }
                }
                else
                {
                    Console.WriteLine(result.Message);
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    TempData["Error"] = "Please enter an email address.";
                    return RedirectToAction("Login", "Home");
                }
                var user = await _loginSevice.GetUserByEmailAsync(email);
                if (user.IsFound == false)
                {
                    TempData["Error"] = "Email not found.";
                    return RedirectToAction("Login", "Home");
                }
                ViewBag.ShowResetForm = true;
                ViewBag.Email = email;
                return View("~/Views/Home/Login.cshtml");
            }
            catch (Exception ex)
            {
                return View("Login", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email, string newPassword, string confirmPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    TempData["Error"] = "Please enter an email address.";
                    return RedirectToAction("Login", "Home");
                }
                var user = await _loginSevice.GetUserByEmailAsync(email);
                if (user.IsFound == false)
                {
                    TempData["Error"] = "Email not found.";
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    if (newPassword.ToLower() == confirmPassword.ToLower())
                    {
                        bool IsUpdatedLogin = await _loginSevice.UpdatePassword(email, newPassword);
                        bool IsUpdatedUser = await _userService.UpdatePassword(email, newPassword);
                        if (IsUpdatedLogin && IsUpdatedUser)
                        {
                            TempData["Error"] = "Password reset successfully.";
                            return RedirectToAction("Login", "Home");
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Password not match with confirm password";
                        return RedirectToAction("Login", "Home");
                    }
                }
                return View("Login", "Home");
            }
            catch (Exception ex)
            {
                return View("Login", "Home");
            }
        }
    }
}

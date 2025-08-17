using Microsoft.AspNetCore.Mvc;
using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Service;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class LoginController : Controller
    {
        private LoginSevice _loginSevice;
        public LoginController(LoginSevice loginSevice)
        {
            _loginSevice = loginSevice;
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
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Console.WriteLine(result.Message);
                    return RedirectToAction("Login", "Home");
                }
            }
            catch
            {
                return View();
            }
        }

    }
}

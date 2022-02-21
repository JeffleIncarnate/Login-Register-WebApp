using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel userModel)
        {
            SecurityServices securityService = new SecurityServices();

            if (securityService.IsValid(userModel))
            {
                return View("LoginSucess", userModel);
            } else
            {
                return View("LoginFailure", userModel);
            }
        }
    }
}

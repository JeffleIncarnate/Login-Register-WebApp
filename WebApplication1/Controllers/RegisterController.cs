using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessRegister(RegisterModel registerModel)
        {
            SecurityServices securityService = new SecurityServices();

            if (securityService.RegisterIsValid(registerModel))
            {
                return View("LoginSucess", registerModel);
            }
            else
            {
                return View("LoginFailure", registerModel);
            }
        }
    }
}

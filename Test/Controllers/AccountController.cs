using Microsoft.AspNetCore.Mvc;
using TestDomainENT.Entities;
using TestRepositoryDAL.DAL.Interfaces;
using TestServiceBLL.BLL.Interfaces;

namespace Test.Controllers
{
    public class AccountController : Controller
    {
        private IUserDAL _userBLL;
        public AccountController(IUserDAL userBLL) 
        {
            _userBLL = userBLL;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _userBLL.Login(userLogin);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _userBLL.Register(userRegister);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }

            return View("Login");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _userBLL.Logout();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return RedirectToAction("Register");
        }
    }
}

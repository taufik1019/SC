using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.Repositories.Data;
using SC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Areas.Staff.Controllers
{
    public class LoginController : Controller
    {
        AccountRepository accountRepository;
        public LoginController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login login)
        {
            // statement mengambil data dari database sesuai dengan email dan password
            var data = accountRepository.Login(login);
            if (data != null)
            {
                HttpContext.Session.SetString("Role", data.Role);
                if (data.RoleId == 1)
                {
                    return RedirectToAction("Index", "Home", new { Areas = "Staff" });
                }
            }
            return View();
            // return -> Id Employee, FullName, Email, Role -> Viewmodels
            // inisialisasi nilai padaa session

        }
    }
}

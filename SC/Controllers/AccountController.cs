using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC.Repositories.Data;
using SC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository;
        public AccountController(AccountRepository accountRepository)
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
                HttpContext.Session.SetInt32("id", data.RoleId);
                if (data.RoleId == 1)
                {
                   return RedirectToAction("Index", "Home");
                } else
                if(data.RoleId == 2)
                {
                    return RedirectToAction("Index", "Dasbordmhs");
                }
                
            }
            return View();
           

        }



        public IActionResult Register()
        {
           return View();
        }


        [HttpPost]
        public IActionResult Register(Register register)
        {
            var data = accountRepository.Register(register);
            if (data > 0)
           {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

      
    }
}

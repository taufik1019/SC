using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Controllers
{
    public class DasbordmhsController : Controller
    {
       
        public IActionResult Index()
        {
            //string role = HttpContext.Session.GetString("Role");
            //if(role.Equals("Mhs"))
            {
                
                return View();
            }
            //return RedirectToAction("Unautorized", "ErrorPage");
        }

        public IActionResult Profil()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SC.Models;
using SC.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Controllers
{
    public class ResponKeluhan1Controller : Controller
    {
        ResponRepository ResponRepository;

        public ResponKeluhan1Controller(ResponRepository responRepository)
        {
            this.ResponRepository = responRepository;
        }

        public IActionResult Index()
        {

            var data = ResponRepository.Get();
            return View(data);

        }

        // GET BY ID
        //GET
        public IActionResult Details(int id)
        {
            var data = ResponRepository.Get(id);
            return View(data);
        }

        // CREATE 
        // GET
        public IActionResult Create()
        {
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Respon respon)
        {
            if (ModelState.IsValid)
            {

                var result = ResponRepository.Post(respon);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // UPDATE
        // GET
        [HttpGet]
        public ActionResult Edit()
        {

            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Respon respon)
        {
            if (ModelState.IsValid)
            {
                var result = ResponRepository.Put(id, respon);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // DELETE
        // GET
        public ActionResult Remove(int id)
        {
            var data = ResponRepository.Get(id);
            return View(data);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(Respon respon)
        {
            var result = ResponRepository.Remove(respon);
            if (result > 0)
                return RedirectToAction("Index");
            return View();
        }
    }
}

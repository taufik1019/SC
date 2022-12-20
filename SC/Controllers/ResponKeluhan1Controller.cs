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
        ResponKeluhanRepository ResponKeluhanRepository;

        public ResponKeluhan1Controller(ResponKeluhanRepository ResponKeluhanRepository)
        {
            this.ResponKeluhanRepository = ResponKeluhanRepository;
        }

        public IActionResult Index()
        {

            var data = ResponKeluhanRepository.Get();
            return View(data);

        }

        // GET BY ID
        //GET
        public IActionResult Details(int id)
        {
            var data = ResponKeluhanRepository.Get(id);
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
        public IActionResult Create(ResponKeluhan responKeluhan)
        {
            if (ModelState.IsValid)
            {

                var result = ResponKeluhanRepository.Post(responKeluhan);
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
        public ActionResult Edit(int id, ResponKeluhan responKeluhan)
        {
            if (ModelState.IsValid)
            {
                var result = ResponKeluhanRepository.Put(id, responKeluhan);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // DELETE
        // GET
        public ActionResult Remove(int id)
        {
            var data = ResponKeluhanRepository.Get(id);
            return View(data);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(ResponKeluhan responKeluhan)
        {
            var result = ResponKeluhanRepository.Remove(responKeluhan);
            if (result > 0)
                return RedirectToAction("Index");
            return View();
        }
    }
}

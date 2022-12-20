using Microsoft.AspNetCore.Mvc;
using SC.Models;
using SC.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Controllers
{
    public class Keluhan1Controller : Controller
    {
        KeluhanRepository KeluhanRepository;
        ResponKeluhanRepository ResponKeluhanRepository;

        public Keluhan1Controller(KeluhanRepository keluhanRepository, ResponKeluhanRepository ResponKeluhanRepository)
        {
            this.KeluhanRepository = keluhanRepository;
            this.ResponKeluhanRepository = ResponKeluhanRepository;
        }
        // GET ALL
        public IActionResult Index()
        {
            var data = KeluhanRepository.Get();
            ViewBag.respon = ResponKeluhanRepository;
            return View(data);
        }

        //GET BY ID
        public IActionResult Details(int id)
        {
            var data = KeluhanRepository.Get(id);
            return View(data);
        }

        // CREATE 
        // GET
        //[Authorize("Mhs")]
        public IActionResult Create()
        {
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Keluhan keluhan)
        {
            if (ModelState.IsValid)
            {

                var result = KeluhanRepository.Post(keluhan);
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
        public ActionResult Edit(int id, Keluhan keluhan)
        {
            if (ModelState.IsValid)
            {
                var result = KeluhanRepository.Put(id, keluhan);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // DELETE
        // GET
        public ActionResult Remove(int id)
        {
            var data = KeluhanRepository.Get(id);
            return View(data);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(Keluhan keluhan)
        {
            var result = KeluhanRepository.Remove(keluhan);
            if (result > 0)
                return RedirectToAction("Index");
            return View();
        }
    
}
}

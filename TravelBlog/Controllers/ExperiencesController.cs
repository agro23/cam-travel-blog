using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class ExperiencesController : Controller
    {
        private TravelDbContext db = new TravelDbContext();
        public IActionResult Index()
        {
            List<Experience> model = db.Experiences.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Locations = new SelectList(db.Locations, "LocationId", "Place");
            ViewBag.People = new SelectList(db.People, "PersonId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Experience experience)
        {
            db.Experiences.Add(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(Experiences => Experiences.ExperienceId == id);
            return View(thisExperience);
        }

        [HttpPost]
        public IActionResult Edit(Experience experience)
        {
            db.Entry(experience).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(Experiences => Experiences.ExperienceId == id);
            return View(thisExperience);
        }

        public IActionResult Delete(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(Experiences => Experiences.ExperienceId == id);
            return View(thisExperience);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(Experiences => Experiences.ExperienceId == id);
            db.Experiences.Remove(thisExperience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

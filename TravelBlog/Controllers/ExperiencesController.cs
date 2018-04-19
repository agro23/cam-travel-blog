using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;
using TravelBlog.ViewModels;

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
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Place");
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Experience experience)
        {
           
            db.Experiences.Add(experience);

            var thisPersonId = Int32.Parse(Request.Form["PersonId"]);
            var thisPerson = db.People.FirstOrDefault(People => People.PersonId == thisPersonId);
            thisPerson.ExperienceId = experience.ExperienceId;
            var thisExperiencePeople = new ExperiencePeople{};
            thisExperiencePeople.ExperienceId = experience.ExperienceId;
            thisExperiencePeople.PersonId = thisPerson.PersonId;
            db.ExperiencePeople.Add(thisExperiencePeople);
 
            db.Entry(thisPerson).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Place");
            ViewBag.People = new SelectList(db.People, "PersonId", "Name");

            var thisExperience = db.Experiences.FirstOrDefault(Experiences => Experiences.ExperienceId == id);
            return View(thisExperience);
        }

        [HttpPost]
        public IActionResult Edit(Experience experience)
        {
            var thisPersonId = Int32.Parse(Request.Form["People"]);
            var thisPerson = db.People.FirstOrDefault(People => People.PersonId == thisPersonId);
            thisPerson.ExperienceId = experience.ExperienceId;
            var thisExperiencePeople = new ExperiencePeople { };
            thisExperiencePeople.ExperienceId = experience.ExperienceId;
            thisExperiencePeople.PersonId = thisPerson.PersonId;
            db.ExperiencePeople.Add(thisExperiencePeople);

            db.Entry(experience).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisExperience = db.Experiences.Include(ExperiencesController => ExperiencesController.Location).FirstOrDefault(Experiences => Experiences.ExperienceId == id);
            //ViewBag.PeopleHere = new SelectList(db.ExperiencePeople, "ExperiencePeopleId", "???")
            var viewModel = new ExperiencePeopleData();
            //viewModel.People = db.ExperiencePeople
                //.Include("People").Where(p => p.ExperiencePeople == thisExperience.ExperienceId).ToList();
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

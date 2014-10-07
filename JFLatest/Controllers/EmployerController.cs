using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JFLatest.Models;

namespace JFLatest.Controllers
{
    public class EmployerController : Controller
    {
        private jobfairContext db = new jobfairContext();

        //
        // GET: /Employer/

        public ActionResult Index()
        {
            return View(db.employer.ToList());
        }

        //
        // GET: /Employer/Details/5

        public ActionResult Details(string id = null)
        {
            employer employer = db.employer.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        //
        // GET: /Employer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(employer employer)
        {
            if (ModelState.IsValid)
            {
                db.employer.Add(employer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employer);
        }

        //
        // GET: /Employer/Edit/5

        public ActionResult Edit(string id = null)
        {
            employer employer = db.employer.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        //
        // POST: /Employer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(employer employer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employer);
        }

        //
        // GET: /Employer/Delete/5

        public ActionResult Delete(string id = null)
        {
            employer employer = db.employer.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        //
        // POST: /Employer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            employer employer = db.employer.Find(id);
            db.employer.Remove(employer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: /AddVacancy

        public ActionResult AddVacancy()
        {
            IEnumerable<SelectListItem> booleans = db.boolean.ToList().Select(x => new SelectListItem
            {
                Value = x.value.ToString(),
                Text = x.value
            });
            

            AddVacancy addVacancyModel = new AddVacancy();


            addVacancyModel.technicalSkill1Exp = 1;
            addVacancyModel.technicalSkill2Exp = 1;
            addVacancyModel.technicalSkill3Exp = 1;
            addVacancyModel.NoCriminalRecord = booleans;
            addVacancyModel.Disability = booleans;
            addVacancyModel.DriversLicense = booleans;
            addVacancyModel.WorkLocation = db.location.ToList().Select(x => new SelectListItem
            {
                Value = x.name.ToString(),
                Text = x.name
            });

            addVacancyModel.highestQualification = db.qualification.ToList().Select(x => new SelectListItem
            {
                Value = x.description.ToString(),
                Text = x.description
            });



            addVacancyModel.Language = db.language.ToList().Select(x => new SelectListItem
            {
                Value = x.name.ToString(),
                Text = x.name
            });


            addVacancyModel.SalaryRange = db.salary_range.ToList().Select(x => new SelectListItem
            {
                Value = x.the_range.ToString(),
                Text = x.the_range
            });
            addVacancyModel.Gender = db.gender.ToList().Select(x => new SelectListItem
            {
                Value = x.name.ToString(),
                Text = x.name
            });
            addVacancyModel.Race = db.race.ToList().Select(x => new SelectListItem
            {
                Value = x.name.ToString(),
                Text = x.name
            });


            return View(addVacancyModel);

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
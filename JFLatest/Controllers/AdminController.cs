using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using JFLatest.Models;
namespace JFLatest.Controllers
{
    public class AdminController : Controller
    {
        private jobfairContext db = new jobfairContext();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View(db.admin.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(string id = null)
        {
            admin admin = db.admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(admin admin)
        {
            if (ModelState.IsValid)
            {
                db.admin.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        //
        // GET: /Admin/Edit/5

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
        // POST: /Admin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(string id = null)
        {
            admin admin = db.admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            admin admin = db.admin.Find(id);
            db.admin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult ViewEmployers()
        {
            return View(db.employer.ToList());
        }

        public ActionResult MatchCandidates(int? jobseekerPage, MatchCandidatesModel mc, int? vacancyID)
        {
            if (mc == null)
            {
                mc = new MatchCandidatesModel();
            }
            mc.jobseekers = db.jobseeker.ToList().ToPagedList(jobseekerPage ?? 1, 1);

            if (mc.vacancy == null)
            {
                mc.vacancy = new MatchCandidatesModel.vacancyModel();
            }


            if (mc.vacancy.matchedJobseekers == null)
            {
                mc.vacancy.matchedJobseekers = new List<string>();
            }

            if (mc.vacancy.currentVacancy == null)
            {
                mc.vacancy.currentVacancy = db.vacancy.Where(v => v.id == (vacancyID ?? 6)).FirstOrDefault();
            }

            return View(mc);
        }
        public PartialViewResult NextPage(int? jobseekerPage, MatchCandidatesModel mc)
        {
            mc.jobseekers = db.jobseeker.ToList().ToPagedList(jobseekerPage ?? 1, 1);
            return PartialView("_PartialMatchCandidatesJobSeeker", mc.jobseekers);
        }

        public PartialViewResult Match(string vacancy, string jobseeker, MatchCandidatesModel mc)
        {

            //mc.vacancy.matchedJobseekers.Add(jobseeker);
            return PartialView("MatchCandidates", mc);
        }
    }



}
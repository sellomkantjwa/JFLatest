using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JFLatest.Models;
using System.Web.Security;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace JFLatest.Controllers
{
    [Authorize(Roles = "employer")]
    public class EmployerController : Controller
    {
        private jobfairContext db = new jobfairContext();

        //
        // GET: /Employer/

        public ActionResult Index()
        {
            //get all vacancies for the employer
            return View(db.vacancy.Where(e => e.ownerEmail == User.Identity.Name).ToList());
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
            AddVacancy addVacancyModel = initModel();

            return View(addVacancyModel);

        }

        private AddVacancy initModel()
        {
            IEnumerable<SelectListItem> booleans = db.boolean.ToList().Select(x => new SelectListItem
            {
                Value = x.value.ToString(),
                Text = x.value.ToString()
            });


            AddVacancy addVacancyModel = new AddVacancy();


            addVacancyModel.technicalSkill1Exp = 1;
            addVacancyModel.technicalSkill2Exp = 1;
            addVacancyModel.technicalSkill3Exp = 1;
            addVacancyModel.NoCriminalRecordOptions = booleans;
            addVacancyModel.DisabilityOptions = booleans;
            addVacancyModel.DriversLicenseOptions = booleans;
            addVacancyModel.WorkLocationOptions = db.location.ToList().Select(x => new SelectListItem
            {
                Value = x.name.ToString(),
                Text = x.name
            });

            //addVacancyModel.qualificationOptions = db.qualification.ToList().Select(x => new SelectListItem
            //{
            //    Value = x.level.ToString(),
            //    Text = x.description
            //});



            addVacancyModel.LanguageOptions = db.language.ToList().Select(x => new SelectListItem
            {
                Value = x.name.ToString(),
                Text = x.name
            });


            //addVacancyModel.SalaryMin = db.salary_range.ToList().Select(x => new SelectListItem
            //{
            //    Value = x.the_range.ToString(),
            //    Text = x.the_range
            //});
            addVacancyModel.GenderOptions = db.gender.ToList().Select(x => new SelectListItem
            {
                Value = x.id.ToString(),
                Text = x.name
            });



            addVacancyModel.RaceOptions = db.race.ToList().Select(x => new SelectListItem
            {
                Value = x.name.ToString(),
                Text = x.name
            });
            return addVacancyModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddVacancy(AddVacancy model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    vacancy vac = new vacancy()
                    {
                        name = model.name,
                        salaryMin = model.SalaryMin,
                        criminalRecord = model.criminalRecord,
                        disability = model.disability,
                        driversLicense = model.driversLicense,
                        gender = model.gender,
                        language = model.language,
                        location = model.location,
                        lowestQualification = "lol",
                        ownerEmail = User.Identity.Name,
                        race = model.race,
                    };

                    LinkedList<string> vacancyTechSkills = new LinkedList<string>();
                    vacancyTechSkills.AddLast(model.technicalSkill1);
                    vacancyTechSkills.AddLast(model.technicalSkill2);
                    vacancyTechSkills.AddLast(model.technicalSkill3);

                    foreach (string techSkill in vacancyTechSkills)
                    {
                        if (!string.IsNullOrEmpty(techSkill))
                        {
                            vacancytechskill newVacancyTechSkill = new vacancytechskill()
                            {
                                skill = (new skill()
                                {
                                    name = techSkill,
                                    type = "t"
                                }),
                                vacancy = vac
                            };
                            db.vacancytechskill.Add(newVacancyTechSkill);
                        }
                    }
                    LinkedList<string> vacancySoftSkills = new LinkedList<string>();
                    vacancySoftSkills.AddLast(model.softSkill1);
                    vacancySoftSkills.AddLast(model.softSkill2);
                    vacancySoftSkills.AddLast(model.softSkill3);

                    foreach (string softSkill in vacancySoftSkills)
                    {
                        if (!string.IsNullOrEmpty(softSkill))
                        {
                            vacancysoftskill newVacancySoftSkill = new vacancysoftskill()
                            {
                                skill = (new skill()
                                {
                                    name = softSkill,
                                    type = "s"
                                }),
                                vacancy = vac
                            };
                            db.vacancysoftskill.Add(newVacancySoftSkill);
                        }

                    }
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw;
                    }
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", (e.StatusCode).ToString());
                }

            }

            AddVacancy addVacancyModel = initModel();
            // If we got this far, something failed, redisplay form
            return View(addVacancyModel);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
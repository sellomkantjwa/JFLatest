using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Web.Mvc;
namespace JFLatest.Models
{
    public class AddVacancy
    {
        public bool showSideMenu { get; set; }
        [Display(Name = "Vacancy Name")]
        [Required]
        public string name { get; set; }

        [Display(Name = "Language")]
        public IEnumerable<SelectListItem> LanguageOptions { get; set; }


        [Display(Name = "Clean criminal record")]
        public IEnumerable<SelectListItem> NoCriminalRecordOptions { get; set; }


        [Display(Name = "Driver's license required")]
        public IEnumerable<SelectListItem> DriversLicenseOptions { get; set; }


        [Display(Name = "Race")]
        public IEnumerable<SelectListItem> RaceOptions { get; set; }

        [Display(Name = "Work location")]
        public IEnumerable<SelectListItem> WorkLocationOptions { get; set; }


        [Display(Name = "Minimum Salary (R)")]
        [RegularExpression("[0-9]+", ErrorMessage = "Enter a numeric value")]
        public int SalaryMin{ get; set; }

        [Display(Name = "Must have disability")]
        public IEnumerable<SelectListItem> DisabilityOptions { get; set; }

        [Display(Name = "Gender required for role")]
        public IEnumerable<SelectListItem> GenderOptions { get; set; }

        [Required]
        [Display(Name = "Technical Skill 1")]
        public string technicalSkill1 { get; set; }

        [Display(Name = "Technical Skill 2")]
        public string technicalSkill2 { get; set; }

        [Display(Name = "Technical Skill 3")]
        public string technicalSkill3 { get; set; }


        [Required]
        [Display(Name = "Years Experience")]
        public int technicalSkill1Exp { get; set; }

        [Display(Name = "Years Experience")]
        public int technicalSkill2Exp { get; set; }

        [Display(Name = "Years Experience")]
        public int technicalSkill3Exp { get; set; }


        [Required]
        [Display(Name = "Soft Skill 1")]
        public string softSkill1 { get; set; }

        [Display(Name = "Soft Skill 2")]
        public string softSkill2 { get; set; }

        [Display(Name = "Soft Skill 3")]
        public string softSkill3 { get; set; }

        //[Required]
        //[Display(Name = "Highest Qualification")]
        //public IEnumerable<SelectListItem> qualificationOptions { get; set; }




        [Required]
        public string language { get; set; }

        public string gender { get; set; }

        public string location { get; set; }

        public bool? driversLicense { get; set; }

        public bool? disability { get; set; }

        public bool? criminalRecord { get; set; }

        public string lowestQualification { get; set; }

        public string race { get; set; }

        public int qualificationLevel { get; set; }
    }
}
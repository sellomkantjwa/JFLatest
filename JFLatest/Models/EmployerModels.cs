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
        [Required]
        public string SelectedItemId { get; set; }

        [Required]
        [Display(Name = "Language")]
        public IEnumerable<SelectListItem> Language { get; set; }


        [Display(Name = "Clean criminal record")]
        public IEnumerable<SelectListItem> NoCriminalRecord { get; set; }


        [Display(Name = "Driver's license required")]
        public IEnumerable<SelectListItem> DriversLicense { get; set; }


        [Display(Name = "Race")]
        public IEnumerable<SelectListItem> Race { get; set; }

        [Display(Name = "Work location")]
        public IEnumerable<SelectListItem> WorkLocation { get; set; }


        [Display(Name = "Salary Range")]
        public IEnumerable<SelectListItem> SalaryRange { get; set; }

        [Display(Name = "Must have disability")]
        public IEnumerable<SelectListItem> Disability { get; set; }

        [Display(Name = "Gender required for role")]
        public IEnumerable<SelectListItem> Gender { get; set; }

        [Required]
        [Display(Name = "Technical Skill 1")]
        public string technicalSkill1 { get; set; }

        [Display(Name = "Technical Skill 2")]
        public string technicalSkill2 { get; set; }

        [Display(Name = "Technical Skill 3")]
        public string technicalSkill3 { get; set; }

        [Required]
        [Display(Name = "Soft Skill 1")]
        public string softSkill1 { get; set; }

        [Display(Name = "Soft Skill 2")]
        public string softSkill2 { get; set; }

        [Display(Name = "Soft Skill 3")]
        public string softSkill3 { get; set; }

        [Required]
        [Display(Name = "Highest Qualification")]
        public IEnumerable<SelectListItem> highestQualification { get; set; }






        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The {0} field must be exactly {2} characters long.")]
        [Display(Name = "Contact Number")]
        [RegularExpression("([0][0-9]*)", ErrorMessage = "{0} must contain only numbers and start with 0")]
        public string contactNumber { get; set; }
        public string userType { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "The {0} field must be at least {2} characters long.")]
        [Display(Name = "Name")]
        public string name { get; set; }
    }
}
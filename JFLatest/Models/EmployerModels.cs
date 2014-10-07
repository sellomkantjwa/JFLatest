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
    public class AddVacancy : IValidatableObject
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

        [Required]
        [Display(Name = "Highest Qualification")]
        public IEnumerable<SelectListItem> highestQualification { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, SelectListItem dependency)
        {
            if (!string.IsNullOrEmpty(dependency.Value.ToString()))
                yield return new ValidationResult("Description must be supplied.");
        }


    }
}
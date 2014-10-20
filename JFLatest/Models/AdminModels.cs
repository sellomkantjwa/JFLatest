using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JFLatest.Models
{


    public class MatchCandidatesModel
    {
        public IPagedList<jobseeker> jobseekers { get; set; }
        public vacancyModel vacancy  { get; set; }

        public class vacancyModel
        {
            public vacancy currentVacancy { get; set; }
            public List<string> matchedJobseekers { get; set; }
        }
    }




}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Grade
    {
        public int GradeId { get; set; }
        
        [Range(0, 5)]
        [Display(Name = "Grade number")]
        public int? GradeNumber { get; set; }

        [Display(Name = "Is passed")]
        public bool IsPassed { get; set; }

        public int PersonSubjectSemesterId { get; set; }
        public PersonSubjectSemester? PersonSubjectSemester { get; set; }
    }
}
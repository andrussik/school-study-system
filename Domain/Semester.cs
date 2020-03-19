using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Semester
    {
        public int SemesterId { get; set; }

        [Display(Name = "Semester name")] 
        public string SemesterName { get; set; } = default!;

        public ICollection<SubjectSemester>? SubjectSemesters { get; set; }
        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Display(Name = "Subject name")] 
        public string SubjectName { get; set; } = default!;

        public string Description { get; set; } = default!;

        [Display(Name = "Gradable")]
        public bool IsGradable { get; set; } = default!;
        
        [Range(0, 999)]
        public int ECTS { get; set; }

        public ICollection<SubjectSemester>? SubjectSemesters { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class SubjectSemester
    {
        public int SubjectSemesterId { get; set; }
        
        [Display(Name = "Subject")]
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }

        [Display(Name = "Semester")]
        public int SemesterId { get; set; }
        public Semester? Semester { get; set; }

        public ICollection<PersonSubjectSemester>? PersonSubjectSemesters { get; set; }

        public string SubjectSemesterName => Subject != null && Semester != null ? Subject.SubjectName + " " + Semester.SemesterName : "";
    }
}
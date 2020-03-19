using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PersonSubjectSemester
    {
        public int PersonSubjectSemesterId { get; set; }
        
        [Display(Name = "Person")]
        public int PersonId { get; set; }
        public Person? Person { get; set; }

        [Display(Name = "Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

        [Display(Name = "Subject by semester")]
        public int SubjectSemesterId { get; set; }
        public SubjectSemester? SubjectSemester { get; set; }

        public ICollection<Grade>? Grades { get; set; }

        public string PersonName => Person != null ? Person.FirstLastName : "";
        
        public string Name => (Person != null && SubjectSemester?.Subject != null && SubjectSemester?.Semester != null) ?
            Person.FirstLastName + " " +
            SubjectSemester.Subject.SubjectName + " " +
            SubjectSemester.Semester.SemesterName : "";
    }
}
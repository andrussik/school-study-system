using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Role
    {
        public int RoleId { get; set; }

        [Display(Name = "Role name")] 
        public string RoleName { get; set; } = default!;

        public ICollection<PersonSubjectSemester>? PersonSubjectSemesters { get; set; }
    }
}
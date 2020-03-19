using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Person
    {
        public int PersonId { get; set; }

        [Display(Name = "First name")] 
        public string FirstName { get; set; } = default!;

        [Display(Name = "Last name")] 
        public string LastName { get; set; } = default!;

        public char Gender { get; set; } = default!;

        [Display(Name = "Date of birth", Prompt = "1970-01-21")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        
        [Display(Name = "ID code")]
        public string? IdCode { get; set; }
        
        [Display(Name = "Student code")]
        public string? StudentCode { get; set; }

        public string Email { get; set; } = default!;

        public string Citizenship { get; set; } = default!;

        public ICollection<PersonSubjectSemester>? PersonSubjectSemesters { get; set; }

        [Display(Name = "Full name")]
        public string FirstLastName => FirstName + " " + LastName;

    }
}
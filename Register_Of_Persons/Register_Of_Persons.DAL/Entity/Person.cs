using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Register_Of_Persons.DAL.Entity
{
    public class Person
    {
        public int Id { get; set; }
        [Required] [MaxLength(128)] 
        public string Email { get; set; }
        [Required] [MaxLength(50)] 
        public string FirstName { get; set; }
        [Required] [MaxLength(50)] 
        public string LastName { get; set; }

        public virtual ICollection<PersonSkill> PersonSkills { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Register_Of_Persons.DAL.Entity
{
    public class Skill
    {
        public int Id { get; set; }
        [Required] [MaxLength(25)]
        public string Name { get; set; }

        public virtual ICollection<PersonSkill> PersonSkills { get; set; }
    }
}
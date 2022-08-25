using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Register_Of_Persons.BLL.Models
{
    public class SkillModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public virtual ICollection<PersonSkillModel> PersonSkills { get; set; }
    }
}
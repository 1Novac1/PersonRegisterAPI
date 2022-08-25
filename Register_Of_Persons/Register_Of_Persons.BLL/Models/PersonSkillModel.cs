using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Register_Of_Persons.BLL.Models
{
    public class PersonSkillModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int SkillId { get; set; }

        public PersonModel Person { get; set; }
        public SkillModel Skill { get; set; }
    }
}
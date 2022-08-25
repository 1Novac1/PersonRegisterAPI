namespace Register_Of_Persons.DAL.Entity
{
    public class PersonSkill
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int SkillId { get; set; }

        public Person Person { get; set; }
        public Skill Skill { get; set; }
    }
}
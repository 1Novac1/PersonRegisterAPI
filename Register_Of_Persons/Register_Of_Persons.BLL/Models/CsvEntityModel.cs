using CsvHelper.Configuration.Attributes;

namespace Register_Of_Persons.BLL.Models
{
    public class CsvEntityModel
    {
        [Name("Email")]
        public string Email { get; set; }
        [Name("First Name")]
        public string FirstName { get; set; }
        [Name("Last Name")]
        public string LastName { get; set; }
        [Name("Skills")]
        public string Skills { get; set; }
    }
}
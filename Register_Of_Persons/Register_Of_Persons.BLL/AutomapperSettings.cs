using AutoMapper;
using Register_Of_Persons.BLL.Models;
using Register_Of_Persons.DAL.Entity;

namespace Register_Of_Persons.BLL
{
    public class AutomapperSettings : Profile
    {
        public AutomapperSettings()
        {
            CreateMap<Person, PersonModel>().ReverseMap();
            CreateMap<Skill, SkillModel>().ReverseMap();
            CreateMap<PersonSkill, PersonSkillModel>().ReverseMap();
        }
    }
}
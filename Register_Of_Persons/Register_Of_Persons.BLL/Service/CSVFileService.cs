using Register_Of_Persons.BLL.Interfaces;
using Register_Of_Persons.BLL.Models;
using Register_Of_Persons.BLL.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Register_Of_Persons.BLL.Service
{
    public class CSVFileService
    {
        private List<CsvEntityModel> records;

        private readonly IPersonService personService;
        private readonly ISkillService skillService;
        private readonly IModelService<PersonSkillModel> personSkillService;

        public CSVFileService(IPersonService personService,
            ISkillService skillService, IModelService<PersonSkillModel> personSkillService)
        {
            records = new List<CsvEntityModel>();

            this.personService = personService;
            this.personSkillService = personSkillService;
            this.skillService = skillService;
        }

        public bool UploadInDatabase(Stream stream)
        {
            try
            {
                if (stream == null)
                    throw new ArgumentNullException($"{nameof(stream)} can not be NULL");

                CSVParser csvParser = new CSVParser();

                records = csvParser.Parse(stream);

                if (records == null)
                    throw new ArgumentNullException($"{nameof(records)} can not be NULL");

                if (records.Count == 0)
                    return false;

                if (!UpdateDataInDatabase())
                    return false;

                return true;
            }
            catch
            {
                throw;
            }
        }

        private bool UpdateDataInDatabase()
        {
            foreach (var record in records)
            {
                try
                {
                    var person = personService.GetByProperty(s => s.Email.ToLower() == record.Email.ToLower());

                    if (person == null)
                    {
                        personService.Add(new PersonModel() { Email = record.Email, FirstName = record.FirstName, LastName = record.LastName });
                        person = personService.GetByProperty(s => s.Email.ToLower() == record.Email.ToLower());
                    }

                    var skills = record.Skills.Split(',').ToList();

                    foreach (var skillName in skills)
                    {
                        string formattedSkillName = skillName.Replace(" ", "");

                        var skill = skillService.GetByProperty(s => s.Name.ToLower() == formattedSkillName.ToLower());

                        if (skill != null)
                        {
                            personSkillService.Add(new PersonSkillModel() { PersonId = person.Id, SkillId = skill.Id });
                            continue;
                        }

                        skillService.Add(new SkillModel() { Name = formattedSkillName });
                        skill = skillService.GetByProperty(s => s.Name.ToLower() == formattedSkillName.ToLower());

                        personSkillService.Add(new PersonSkillModel() { PersonId = person.Id, SkillId = skill.Id });
                    }
                }
                catch
                {
                    continue;
                }
            }

            return true;
        }
    }
}
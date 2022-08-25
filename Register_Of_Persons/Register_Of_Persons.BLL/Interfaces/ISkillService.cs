using Register_Of_Persons.BLL.Models;
using System.Collections.Generic;

namespace Register_Of_Persons.BLL.Interfaces
{
    public interface ISkillService : IModelService<SkillModel>
    {
        /// <summary>
        /// Searches the skill record by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns><see cref="SkillModel"/> record</returns>
        SkillModel GetByName(string name);
        /// <summary>
        /// Searches all skills records by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>IEnumerable of <see cref="SkillModel"/> records</returns>
        IEnumerable<SkillModel> GetAllByName(string name);
    }
}
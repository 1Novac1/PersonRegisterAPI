using Register_Of_Persons.BLL.Models;
using System.Collections.Generic;

namespace Register_Of_Persons.BLL.Interfaces
{
    public interface IPersonService : IModelService<PersonModel>
    {
        /// <summary>
        /// Searches the person record by first name or last name
        /// </summary>
        /// <param name="name">It can be a first name or a last name</param>
        /// <returns><see cref="PersonModel"/> record</returns>
        PersonModel GetByName(string name);
        /// <summary>
        /// Searches all people records by first or last name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>IEnumerable of <see cref="PersonModel"/> records</returns>
        IEnumerable<PersonModel> GetAllByName(string name);
        /// <summary>
        /// Searches the person record by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns><see cref="PersonModel"/> record</returns>
        PersonModel GetByEmail(string email);
        /// <summary>
        /// Searches all people records by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>IEnumerable of <see cref="PersonModel"/> records</returns>
        IEnumerable<PersonModel> GetAllByEmail(string email);
    }
}
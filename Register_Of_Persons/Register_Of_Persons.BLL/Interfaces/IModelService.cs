using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Register_Of_Persons.BLL.Interfaces
{
    public interface IModelService<T> where T : class
    {
        /// <summary>
        /// Adds <see langword="T"/> to Database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns><see langword="T"/> added record</returns>
        T Add(T entity);
        /// <summary>
        /// Removes <see langword="T"/> from Database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns><see langword="T"/> removed record</returns>
        T Remove(T entity);
        /// <summary>
        /// Updates record in database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns><see langword="T"/> updated record</returns>
        T Update(T entity);
        /// <summary>
        /// Returns all records from a table in a database
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of all table records</returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Returns a record by id from a table in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see langword="T"/> record</returns>
        T GetById(int id);
        /// <summary>
        /// Select first record from table given a filter expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns><see langword="T"/> record</returns>
        T GetByProperty(Expression<Func<T, bool>> expression);
        /// <summary>
        /// Select all records from table given a filter expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns><see cref="IEnumerable{T}"/> records</returns>
        IEnumerable<T> GetAllByProperty(Expression<Func<T, bool>> expression);
    }
}
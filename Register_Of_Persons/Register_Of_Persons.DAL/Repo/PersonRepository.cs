using Microsoft.EntityFrameworkCore;
using Register_Of_Persons.DAL.DatabaseContext;
using Register_Of_Persons.DAL.Entity;
using Register_Of_Persons.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Register_Of_Persons.DAL.Repo
{
    public class PersonRepository : IRepository<Person>, IDisposable
    {
        private readonly MssqlDbContext context;
        public PersonRepository(MssqlDbContext dbContext)
        {
            context = dbContext;
        }

        public Person Add(Person entity)
        {
            context.People.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public Person GetById(int id)
        {
            return context.People
                .Include(ps => ps.PersonSkills).ThenInclude(s => s.Skill)
                .FirstOrDefault(i => i.Id == id);
        }

        public Person GetByProperty(Expression<Func<Person, bool>> expression)
        {
            return context.People
                .Include(ps => ps.PersonSkills).ThenInclude(s => s.Skill)
                .FirstOrDefault(expression);
        }

        public IEnumerable<Person> GetAllByProperty(Expression<Func<Person, bool>> expression)
        {
            return context.People
               .Include(ps => ps.PersonSkills).ThenInclude(s => s.Skill)
               .Where(expression).ToList();
        }

        public IEnumerable<Person> GetAll()
        {
            return context.People
                .Include(ps => ps.PersonSkills).ThenInclude(s => s.Skill)
                .ToList();
        }

        public Person Remove(Person entity)
        {
            context.People.Remove(entity);
            context.SaveChanges();

            return entity;
        }

        public Person Update(Person entity)
        {
            context.People.Update(entity);
            context.SaveChanges();

            return entity;
        }

        ~PersonRepository()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
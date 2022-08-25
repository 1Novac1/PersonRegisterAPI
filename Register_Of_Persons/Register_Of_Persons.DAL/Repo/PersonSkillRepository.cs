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
    public class PersonSkillRepository : IRepository<PersonSkill>, IDisposable
    {
        private readonly MssqlDbContext context;
        public PersonSkillRepository(MssqlDbContext dbContext)
        {
            context = dbContext;
        }

        public PersonSkill Add(PersonSkill entity)
        {
            context.PersonSkills.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public PersonSkill GetById(int id)
        {
            return context.PersonSkills
                .Include(p => p.Person)
                .Include(s => s.Skill)
                .FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<PersonSkill> GetAll()
        {
            return context.PersonSkills
                .Include(p => p.Person)
                .Include(s => s.Skill)
                .ToList();
        }

        public PersonSkill Remove(PersonSkill entity)
        {
            context.PersonSkills.Remove(entity);
            context.SaveChanges();

            return entity;
        }

        public PersonSkill Update(PersonSkill entity)
        {
            context.PersonSkills.Update(entity);
            context.SaveChanges();

            return entity;
        }

        public PersonSkill GetByProperty(Expression<Func<PersonSkill, bool>> expression)
        {
            return context.PersonSkills
                .Include(p => p.Person)
                .Include(s => s.Skill)
                .FirstOrDefault(expression);
        }

        public IEnumerable<PersonSkill> GetAllByProperty(Expression<Func<PersonSkill, bool>> expression)
        {
            return context.PersonSkills
                .Include(p => p.Person)
                .Include(s => s.Skill)
                .Where(expression).ToList();
        }

        ~PersonSkillRepository()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
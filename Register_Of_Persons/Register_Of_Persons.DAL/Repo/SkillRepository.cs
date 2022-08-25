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
    public class SkillRepository : IRepository<Skill>, IDisposable
    {
        private readonly MssqlDbContext context;
        public SkillRepository(MssqlDbContext dbContext)
        {
            context = dbContext;
        }

        public Skill Add(Skill entity)
        {
            context.Skills.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public Skill GetById(int id)
        {
            return context.Skills
                .Include(ps => ps.PersonSkills).ThenInclude(p => p.Person)
                .FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Skill> GetAll()
        {
            return context.Skills
                .Include(ps => ps.PersonSkills).ThenInclude(p => p.Person)
                .ToList();
        }

        public Skill Remove(Skill entity)
        {
            context.Skills.Remove(entity);
            context.SaveChanges();

            return entity;
        }

        public Skill Update(Skill entity)
        {
            context.Skills.Update(entity);
            context.SaveChanges();

            return entity;
        }

        public Skill GetByProperty(Expression<Func<Skill, bool>> expression)
        {
            return context.Skills
                .Include(ps => ps.PersonSkills).ThenInclude(p => p.Person)
                .FirstOrDefault(expression);
        }

        public IEnumerable<Skill> GetAllByProperty(Expression<Func<Skill, bool>> expression)
        {
            return context.Skills
                .Include(ps => ps.PersonSkills).ThenInclude(p => p.Person)
                .Where(expression).ToList();
        }

        ~SkillRepository()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
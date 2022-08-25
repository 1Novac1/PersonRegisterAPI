using AutoMapper;
using Register_Of_Persons.BLL.Exceptions;
using Register_Of_Persons.BLL.Interfaces;
using Register_Of_Persons.BLL.Models;
using Register_Of_Persons.DAL.Entity;
using Register_Of_Persons.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Register_Of_Persons.BLL.Service
{
    public class SkillService : ISkillService
    {
        private readonly IMapper autoMapper;
        private readonly IRepository<Skill> skillRepository;

        public SkillService(IMapper autoMapper, IRepository<Skill> skillRepository)
        {
            this.autoMapper = autoMapper;
            this.skillRepository = skillRepository;
        }

        public SkillModel Add(SkillModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException($"{nameof(entity)} can not be NULL");

                if(skillRepository.GetByProperty(e => e.Name.ToLower() == entity.Name.ToLower()) != null)
                    throw new IsAlreadyExists($"{entity.Name} is already exists!");

                skillRepository.Add(autoMapper.Map<Skill>(entity));

                return entity;
            }
            catch
            {
                throw;
            }
        }

        public SkillModel GetById(int id)
        {
            return autoMapper.Map<SkillModel>(skillRepository.GetById(id));
        }

        public IEnumerable<SkillModel> GetAll()
        {
            return autoMapper.Map<IEnumerable<SkillModel>>(skillRepository.GetAll());
        }

        public SkillModel Remove(SkillModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException($"{nameof(entity)} can not be NULL");

                skillRepository.Remove(autoMapper.Map<Skill>(entity));

                return entity;
            }
            catch
            {
                throw;
            }
        }

        public SkillModel Update(SkillModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException($"{nameof(entity)} can not be NULL");

                skillRepository.Update(autoMapper.Map<Skill>(entity));

                return entity;
            }
            catch
            {
                throw;
            }
        }

        public SkillModel GetByProperty(Expression<Func<SkillModel, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException($"{nameof(expression)} can not be NULL");

            var mappedExpression = autoMapper.Map<Expression<Func<Skill, bool>>>(expression);

            return autoMapper.Map<SkillModel>(skillRepository.GetByProperty(mappedExpression));
        }

        public IEnumerable<SkillModel> GetAllByProperty(Expression<Func<SkillModel, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException($"{nameof(expression)} can not be NULL");

            var mappedExpression = autoMapper.Map<Expression<Func<Skill, bool>>>(expression);

            return autoMapper.Map<IEnumerable<SkillModel>>(skillRepository.GetAllByProperty(mappedExpression));
        }

        public SkillModel GetByName(string name)
        {
            return autoMapper.Map<SkillModel>(skillRepository
               .GetByProperty(s => s.Name.Contains(name)));
        }

        public IEnumerable<SkillModel> GetAllByName(string name)
        {
            return autoMapper.Map<IEnumerable<SkillModel>>(skillRepository
               .GetAllByProperty(s => s.Name.Contains(name)));
        }
    }
}
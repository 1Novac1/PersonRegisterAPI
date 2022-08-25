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
    public class PersonSkillService : IModelService<PersonSkillModel>
    {
        private readonly IMapper autoMapper;
        private readonly IRepository<PersonSkill> personSkillRepository;

        public PersonSkillService(IMapper autoMapper, IRepository<PersonSkill> personSkillRepository)
        {
            this.autoMapper = autoMapper;
            this.personSkillRepository = personSkillRepository;
        }

        public PersonSkillModel Add(PersonSkillModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException($"{nameof(entity)} can not be NULL");

                if (personSkillRepository.GetByProperty(e => e.PersonId == entity.PersonId && e.SkillId == entity.SkillId) != null)
                    throw new IsAlreadyExists($"{entity} is already exists!");

                personSkillRepository.Add(autoMapper.Map<PersonSkill>(entity));

                return entity;
            }
            catch
            {
                throw;
            }
        }

        public PersonSkillModel GetById(int id)
        {
            return autoMapper.Map<PersonSkillModel>(personSkillRepository.GetById(id));
        }

        public IEnumerable<PersonSkillModel> GetAll()
        {
            return autoMapper.Map<IEnumerable<PersonSkillModel>>(personSkillRepository.GetAll());
        }

        public PersonSkillModel Remove(PersonSkillModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException($"{nameof(entity)} can not be NULL");

                personSkillRepository.Remove(autoMapper.Map<PersonSkill>(entity));

                return entity;
            }
            catch
            {
                throw;
            }
        }

        public PersonSkillModel Update(PersonSkillModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException($"{nameof(entity)} can not be NULL");

                personSkillRepository.Update(autoMapper.Map<PersonSkill>(entity));

                return entity;
            }
            catch
            {
                throw;
            }
        }

        public PersonSkillModel GetByProperty(Expression<Func<PersonSkillModel, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException($"{nameof(expression)} can not be NULL");

            var mappedExpression = autoMapper.Map<Expression<Func<PersonSkill, bool>>>(expression);

            return autoMapper.Map<PersonSkillModel>(personSkillRepository.GetByProperty(mappedExpression));
        }

        public IEnumerable<PersonSkillModel> GetAllByProperty(Expression<Func<PersonSkillModel, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException($"{nameof(expression)} can not be NULL");

            var mappedExpression = autoMapper.Map<Expression<Func<PersonSkill, bool>>>(expression);

            return autoMapper.Map<IEnumerable<PersonSkillModel>>(personSkillRepository.GetAllByProperty(mappedExpression));
        }
    }
}
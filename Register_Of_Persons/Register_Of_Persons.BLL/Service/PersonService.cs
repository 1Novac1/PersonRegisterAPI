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
    public class PersonService : IPersonService
    {
        private readonly IMapper autoMapper;
        private readonly IRepository<Person> personRepository;

        public PersonService(IMapper autoMapper, IRepository<Person> personRepository)
        {
            this.autoMapper = autoMapper;
            this.personRepository = personRepository;
        }

        public PersonModel Add(PersonModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException($"{nameof(entity)} can not be NULL");

                if (personRepository.GetByProperty(e => e.Email.ToLower() == entity.Email.ToLower()) != null)
                    throw new IsAlreadyExists($"{entity.Email} is already exists!");

                personRepository.Add(autoMapper.Map<Person>(entity));

                return entity;
            }
            catch
            {
                throw;
            }
        }

        public PersonModel GetById(int id)
        {
            return autoMapper.Map<PersonModel>(personRepository.GetById(id));
        }

        public IEnumerable<PersonModel> GetAll()
        {
            return autoMapper.Map<IEnumerable<PersonModel>>(personRepository.GetAll());
        }

        public PersonModel Remove(PersonModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException($"{nameof(entity)} can not be NULL");

                personRepository.Remove(autoMapper.Map<Person>(entity));

                return entity;
            }
            catch
            {
                throw;
            }
        }

        public PersonModel Update(PersonModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException($"{nameof(entity)} can not be NULL");

                personRepository.Update(autoMapper.Map<Person>(entity));

                return entity;
            }
            catch
            {
                throw;
            }
        }

        public PersonModel GetByProperty(Expression<Func<PersonModel, bool>> expression)
        {
            if(expression == null)
                throw new ArgumentNullException($"{nameof(expression)} can not be NULL");

            var mappedExpression = autoMapper.Map<Expression<Func<Person, bool>>>(expression);
            
            return autoMapper.Map<PersonModel>(personRepository.GetByProperty(mappedExpression));
        }

        public PersonModel GetByName(string name)
        {
            return autoMapper.Map<PersonModel>(personRepository
                .GetByProperty(p => p.FirstName.Contains(name) || p.LastName.Contains(name)));
        }

        public IEnumerable<PersonModel> GetAllByName(string name)
        {
            return autoMapper.Map<IEnumerable<PersonModel>>(personRepository
                .GetAllByProperty(p => p.FirstName.Contains(name) || p.LastName.Contains(name)));
        }

        public PersonModel GetByEmail(string email)
        {
            return autoMapper.Map<PersonModel>(personRepository
                .GetByProperty(p => p.Email.Contains(email)));
        }

        public IEnumerable<PersonModel> GetAllByEmail(string email)
        {
            return autoMapper.Map<IEnumerable<PersonModel>>(personRepository
                .GetAllByProperty(p => p.Email.Contains(email)));
        }

        public IEnumerable<PersonModel> GetAllByProperty(Expression<Func<PersonModel, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException($"{nameof(expression)} can not be NULL");

            var mappedExpression = autoMapper.Map<Expression<Func<Person, bool>>>(expression);

            return autoMapper.Map<IEnumerable<PersonModel>>(personRepository.GetAllByProperty(mappedExpression));
        }
    }
}
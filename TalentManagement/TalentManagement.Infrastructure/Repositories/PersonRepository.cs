using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace TalentManagement.Infrastructure.Repositories
{
    public class PersonRepository : IRepository
    {
        private TalentManagementContext Context;

        public PersonRepository()
        {
            this.Context = new TalentManagementContext();
        }

        public IEnumerable<object> GetAll()
        {
            try
            {
                return this.Context.Persons
                    .Include(p => p.AccountType)
                    .Include(p => p.Bank)
                    .Include(p => p.City)
                    .Include(p => p.State)
                    .Include(p => p.Profile)
                    .Include(p => p.PersonKnowledges)
                    .Include(p => p.PersonWillingnesss)
                    .Include(p => p.PersonTimeWorks)

                    .ToList() as IEnumerable<Person>;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetById(int id)
        {
            try
            {
                return this.Context.Persons
                    .Include(p => p.AccountType)
                    .Include(p => p.Bank)
                    .Include(p => p.City)
                    .Include(p => p.State)
                    .Include(p => p.Profile)
                    .Include(p => p.PersonKnowledges)
                    .Include(p => p.PersonWillingnesss)
                    .Include(p => p.PersonTimeWorks)
                    .Where(p => p.Id == id)
                    .FirstOrDefault() as Person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(object person)
        {
            try
            {
                var _person = person as Person;

                this.Context.Persons.Add(_person);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(object person)
        {
            try
            {
                var _person = person as Person;

                var personOld = this.Context.Persons
                .Include(p => p.PersonKnowledges)
                .Include(p => p.PersonTimeWorks)
                .Include(p => p.PersonWillingnesss)
                .Where(p => p.Id == _person.Id).FirstOrDefault();

                if (_person.Password != personOld.Password)
                    UpdatePassworPerson(_person, personOld);
                else if (_person.ProfileId != personOld.ProfileId)
                    UpdateProfilePerson(_person, personOld);
                else
                    UpdatePerson(_person, personOld);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var personOld = this.Context.Persons.Where(p => p.Id == id).FirstOrDefault();
                this.Context.Persons.Remove(personOld);

                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdatePerson(Person _person, Person personOld)
        {
            personOld.AccountNumber = _person.AccountNumber;
            personOld.AccountTypeId = _person.AccountTypeId;
            personOld.Agency = _person.Agency;
            personOld.BankId = _person.BankId;
            personOld.CityId = _person.CityId;
            personOld.Cpf = _person.Cpf;
            personOld.Email = _person.Email;
            personOld.LinkedIn = _person.LinkedIn;
            personOld.LinkTest = _person.LinkTest;
            personOld.Name = _person.Name;
            personOld.OtherKnowledge = _person.OtherKnowledge;
            personOld.Phone = _person.Phone;
            personOld.Portfolio = _person.Portfolio;
            personOld.Salary = _person.Salary;
            personOld.Skype = _person.Skype;
            personOld.StateId = _person.StateId;
            personOld.Password = _person.Password;
            personOld.ProfileId = _person.ProfileId;

            if (personOld.PersonKnowledges.Count > 0)
            {
                for (int i = 0; i < _person.PersonKnowledges.Count; i++)
                {
                    personOld.PersonKnowledges.ToList()[i].Level = _person.PersonKnowledges.ToList()[i].Level;
                }
            }
            else
            {
                this.Context.PersonKnowledges.AddRange(_person.PersonKnowledges);
            }

            if (personOld.PersonTimeWorks.Count > 0)
            {
                this.Context.PersonTimeWorks.RemoveRange(personOld.PersonTimeWorks);
                this.Context.SaveChanges();
            }

            this.Context.PersonTimeWorks.AddRange(_person.PersonTimeWorks);

            if (personOld.PersonWillingnesss.Count > 0)
            {
                this.Context.PersonWillingnesss.RemoveRange(personOld.PersonWillingnesss);
                this.Context.SaveChanges();
            }

            this.Context.PersonWillingnesss.AddRange(_person.PersonWillingnesss);

            this.Context.SaveChanges();
        }

        private void UpdatePassworPerson(Person _person, Person personOld)
        {
            personOld.Password = _person.Password;

            this.Context.SaveChanges();
        }

        private void UpdateProfilePerson(Person _person, Person personOld)
        {
            personOld.ProfileId = _person.ProfileId;

            this.Context.SaveChanges();
        }
    }
}
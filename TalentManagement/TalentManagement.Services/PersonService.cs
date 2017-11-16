using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Contracts.Services;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Services
{
    public class PersonService : IPersonService
    {
        private IRepository Repository;

        public PersonService(IRepository repository)
        {
            this.Repository = repository;
        }

        public void DeletePerson(int id)
        {
            this.Repository.Delete(id);
        }

        public Person GePersontById(int id)
        {
            return this.Repository.GetById(id) as Person;
        }

        public IEnumerable<Person> GetAllPerson()
        {
            return this.Repository.GetAll() as IEnumerable<Person>;
        }

        public void InsertPerson(Person person)
        {
            person.ProfileId = (int)EnumProfile.Talent;
            this.Repository.Insert(person);
        }

        public void UpdatePerson(Person person)
        {
            this.Repository.Update(person);
        }

        public Person LoginPerson(string email, string password)
        {
            var persons = this.Repository.GetAll() as IEnumerable<Person>;
            var person = persons.Where(p => p.Email == email && p.Password == password).FirstOrDefault();

            return person;
        }

        public Person UpdatePasswordPerson(Person person)
        {
            var _person = this.Repository.GetById(person.Id) as Person;
            _person.Password = person.Password;
            this.Repository.Update(_person);

            return _person;
        }

        public Person UpdateProfilePerson(Person person)
        {
            var _person = this.Repository.GetById(person.Id) as Person;
            _person.ProfileId = person.ProfileId;
            this.Repository.Update(_person);

            return _person;
        }
    }

    public enum EnumProfile
    {
        Administrator = 1,
        Talent = 2
    }
}
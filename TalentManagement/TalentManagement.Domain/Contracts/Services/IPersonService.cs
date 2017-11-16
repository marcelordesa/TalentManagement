using System;
using System.Collections.Generic;
using System.Text;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Domain.Contracts.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAllPerson();
        Person GePersontById(int id);
        void InsertPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int id);
        Person LoginPerson(string email, string password);
        Person UpdatePasswordPerson(Person person);
        Person UpdateProfilePerson(Person person);
    }
}
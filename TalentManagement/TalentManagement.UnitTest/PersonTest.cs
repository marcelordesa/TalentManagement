using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalentManagement.Domain.Entities;
using TalentManagement.Domain.Contracts.Services;
using TalentManagement.FactoryServices.Enum;

namespace TalentManagement.UnitTest
{
    [TestClass]
    public class PersonTest
    {
        IPersonService personService = FactoryServices.FactoryServices.GetServiceInstance(EnumServices.Person) as IPersonService;

        [TestMethod]
        public void GetAllPersons()
        {
            personService.GetAllPerson();
        }

        [TestMethod]
        public void GetPersonById()
        {
            personService.GePersontById(1);
        }

        [TestMethod]
        public void UpdatePerson()
        {
            var person = personService.GePersontById(2);
            person.Name = "Test";

            personService.UpdatePerson(person);
        }

        [TestMethod]
        public void UpdatePassworPerson()
        {
            var person = personService.GePersontById(2);
            person.Password = "123";

            personService.UpdatePasswordPerson(person);
        }

        [TestMethod]
        public void UpdateProfilePerson()
        {
            var person = personService.GePersontById(2);
            person.ProfileId = 2;

            personService.UpdateProfilePerson(person);
        }
    }
}

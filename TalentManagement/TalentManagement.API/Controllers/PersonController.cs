using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentManagement.Domain.Contracts.Services;
using TalentManagement.FactoryServices.Enum;
using TalentManagement.Domain.Entities;

namespace TalentManagement.API.Controllers
{
    [Produces("application/json")]
    public class PersonController : Controller
    {
        IPersonService personService = FactoryServices.FactoryServices.GetServiceInstance(EnumServices.Person) as IPersonService;

        [Route("api/Person/GetAllPerson")]
        [HttpGet]
        public IEnumerable<Person> GetAllPerson()
        {
            return personService.GetAllPerson();
        }

        [Route("api/Person/GetPersonById/{id}")]
        [HttpGet("{id}")]
        public Person GetPersonById(int id)
        {
            return personService.GePersontById(id);
        }

        [Route("api/Person/InsertPerson")]
        [HttpPost]
        public void InsertPerson([FromBody]Person person)
        {
            personService.InsertPerson(person);
        }

        [Route("api/Person/UpdatePerson/{id}")]
        [HttpPut("{id}")]
        public void UpdatePerson(int id, [FromBody]Person person)
        {
            person.Id = id;
            personService.UpdatePerson(person);
        }

        [Route("api/Person/DeletePerson/{id}")]
        [HttpDelete("{id}")]
        public void DeletePerson(int id)
        {
            personService.DeletePerson(id);
        }

        [Route("api/Person/LoginPerson")]
        [HttpPost]
        public Person LoginPerson([FromBody]Person person)
        {
            return personService.LoginPerson(person.Email, person.Password);
        }

        [Route("api/Person/UpdatePasswordPerson/{id}")]
        [HttpPut("{id}")]
        public void UpdatePasswordPerson(int id, [FromBody]Person person)
        {
            person.Id = id;
            personService.UpdatePasswordPerson(person);
        }

        [Route("api/Person/UpdateProfilePerson/{id}")]
        [HttpPut("{id}")]
        public void UpdateProfilePerson(int id, [FromBody]Person person)
        {
            person.Id = id;
            personService.UpdateProfilePerson(person);
        }
    }
}
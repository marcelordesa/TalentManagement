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
    public class CityController : Controller
    {
        ICityService cityService = FactoryServices.FactoryServices.GetServiceInstance(EnumServices.City) as ICityService;

        [Route("api/City/GetAllCityByStateId/{id}")]
        [HttpGet("{id}")]
        public IEnumerable<City> GetAllCityByStateId(int id)
        {
            return cityService.GetAllCityByStateId(id);
        }
    }
}
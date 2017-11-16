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
    public class WillingnessController : Controller
    {
        IWillingnessService willingnessService = FactoryServices.FactoryServices.GetServiceInstance(EnumServices.Willingness) as IWillingnessService;

        [Route("api/Willingness/GetAllWillingness")]
        [HttpGet]
        public IEnumerable<Willingness> GetAllWillingness(int id)
        {
            return willingnessService.GetAllWillingness();
        }
    }
}
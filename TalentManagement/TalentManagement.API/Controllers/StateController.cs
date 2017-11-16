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
    public class StateController : Controller
    {
        IStateService stateService = FactoryServices.FactoryServices.GetServiceInstance(EnumServices.State) as IStateService;

        [Route("api/State/GetAllState")]
        [HttpGet]
        public IEnumerable<State> GetAllState()
        {
            return stateService.GetAllState();
        }
    }
}
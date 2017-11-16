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
    public class TimeWorkController : Controller
    {
        ITimeWorkService timeWorkService = FactoryServices.FactoryServices.GetServiceInstance(EnumServices.TimeWork) as ITimeWorkService;

        [Route("api/TimeWork/GetAllTimeWork")]
        [HttpGet]
        public IEnumerable<TimeWork> GetAllTimeWork(int id)
        {
            return timeWorkService.GetAllTimeWork();
        }
    }
}
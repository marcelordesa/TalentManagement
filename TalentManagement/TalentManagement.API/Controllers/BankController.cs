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
    public class BankController : Controller
    {
        IBankService bankService = FactoryServices.FactoryServices.GetServiceInstance(EnumServices.Bank) as IBankService;

        [Route("api/Bank/GetAllBank")]
        [HttpGet]
        public IEnumerable<Bank> GetAllBank()
        {
            return bankService.GetAllBank();
        }
    }
}
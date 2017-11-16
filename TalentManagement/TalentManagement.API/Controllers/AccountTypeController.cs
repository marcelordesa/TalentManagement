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
    public class AccountTypeController : Controller
    {
        IAccountTypeService accountTypeService = FactoryServices.FactoryServices.GetServiceInstance(EnumServices.AccountType) as IAccountTypeService;

        [Route("api/AccountType/GetAllAccountType")]
        [HttpGet]
        public IEnumerable<AccountType> GetAllAccountType()
        {
            return accountTypeService.GetAllAccountType();
        }
    }
}
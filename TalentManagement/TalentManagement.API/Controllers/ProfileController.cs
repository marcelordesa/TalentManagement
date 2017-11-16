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
    public class ProfileController : Controller
    {
        IProfileService profileService = FactoryServices.FactoryServices.GetServiceInstance(EnumServices.Profile) as IProfileService;

        [Route("api/Profile/GetAllProfile")]
        [HttpGet]
        public IEnumerable<Profile> GetAllProfile()
        {
            return profileService.GetAllProfile();
        }
    }
}
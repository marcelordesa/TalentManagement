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
    public class KnowledgeController : Controller
    {
        IKnowledgeService knowledgeService = FactoryServices.FactoryServices.GetServiceInstance(EnumServices.Knowledge) as IKnowledgeService;

        [Route("api/Knowledge/GetAllKnowledge")]
        [HttpGet]
        public IEnumerable<Knowledge> GetAllKnowledge(int id)
        {
            return knowledgeService.GetAllKnowledge();
        }
    }
}
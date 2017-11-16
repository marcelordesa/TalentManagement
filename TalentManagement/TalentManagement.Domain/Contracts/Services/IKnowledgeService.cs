using System;
using System.Collections.Generic;
using System.Text;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Domain.Contracts.Services
{
    public interface IKnowledgeService
    {
        IEnumerable<Knowledge> GetAllKnowledge();
    }
}
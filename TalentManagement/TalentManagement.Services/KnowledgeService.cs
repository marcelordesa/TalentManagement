using System;
using System.Collections.Generic;
using System.Text;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Contracts.Services;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Services
{
    public class KnowledgeService : IKnowledgeService
    {
        private IRepository Repository;

        public KnowledgeService(IRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<Knowledge> GetAllKnowledge()
        {
            return this.Repository.GetAll() as IEnumerable<Knowledge>;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Contracts.Services;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Services
{
    public class WillingnessService : IWillingnessService
    {
        private IRepository Repository;

        public WillingnessService(IRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<Willingness> GetAllWillingness()
        {
            return this.Repository.GetAll() as IEnumerable<Willingness>;
        }
    }
}
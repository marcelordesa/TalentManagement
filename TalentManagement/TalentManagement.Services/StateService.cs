using System;
using System.Collections.Generic;
using System.Text;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Contracts.Services;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Services
{
    public class StateService : IStateService
    {
        private IRepository Repository;

        public StateService(IRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<State> GetAllState()
        {
            return this.Repository.GetAll() as IEnumerable<State>;
        }
    }
}
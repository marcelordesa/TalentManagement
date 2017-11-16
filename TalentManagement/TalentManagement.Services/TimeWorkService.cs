using System;
using System.Collections.Generic;
using System.Text;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Contracts.Services;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Services
{
    public class TimeWorkService : ITimeWorkService
    {
        private IRepository Repository;

        public TimeWorkService(IRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<TimeWork> GetAllTimeWork()
        {
            return this.Repository.GetAll() as IEnumerable<TimeWork>;
        }
    }
}
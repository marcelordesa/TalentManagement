using System;
using System.Collections.Generic;
using System.Text;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Contracts.Services;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Services
{
    public class ProfileService : IProfileService
    {
        private IRepository Repository;

        public ProfileService(IRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<Profile> GetAllProfile()
        {
            return this.Repository.GetAll() as IEnumerable<Profile>;
        }
    }
}
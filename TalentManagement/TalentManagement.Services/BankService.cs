using System;
using System.Collections.Generic;
using System.Text;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Contracts.Services;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Services
{
    public class BankService : IBankService
    {
        private IRepository Repository;

        public BankService(IRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<Bank> GetAllBank()
        {
            return this.Repository.GetAll() as IEnumerable<Bank>;
        }
    }
}
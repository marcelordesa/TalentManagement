using System;
using System.Collections.Generic;
using System.Text;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Contracts.Services;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Services
{
    public class AccountTypeService : IAccountTypeService
    {
        private IRepository Repository;

        public AccountTypeService(IRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<AccountType> GetAllAccountType()
        {
            return this.Repository.GetAll() as IEnumerable<AccountType>;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TalentManagement.Infrastructure.Repositories
{
    public class AccountTypeRepository : IRepository
    {
        private TalentManagementContext Context;

        public AccountTypeRepository()
        {
            this.Context = new TalentManagementContext();
        }

        public IEnumerable<object> GetAll()
        {
            try
            {
                return this.Context.AccountTypes
                    .ToList() as IEnumerable<AccountType>;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetById(int id)
        {
            try
            {
                return this.Context.AccountTypes
                    .Where(p => p.Id == id)
                    .FirstOrDefault() as AccountType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(object accountType)
        {
            try
            {
                var _accountType = accountType as AccountType;

                this.Context.AccountTypes.Add(_accountType);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(object accountType)
        {
            try
            {
                var _accountType = accountType as AccountType;

                var accountTypeOld = this.Context.AccountTypes.Where(p => p.Id == _accountType.Id).FirstOrDefault();

                accountTypeOld.Name = _accountType.Name;

                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var accountTypeOld = this.Context.AccountTypes.Where(p => p.Id == id).FirstOrDefault();
                this.Context.AccountTypes.Remove(accountTypeOld);

                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
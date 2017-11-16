using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TalentManagement.Infrastructure.Repositories
{
    public class BankRepository : IRepository
    {
        private TalentManagementContext Context;

        public BankRepository()
        {
            this.Context = new TalentManagementContext();
        }

        public IEnumerable<object> GetAll()
        {
            try
            {
                return this.Context.Banks
                    .ToList() as IEnumerable<Bank>;
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
                return this.Context.Banks
                    .Where(p => p.Id == id)
                    .FirstOrDefault() as Bank;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(object bank)
        {
            try
            {
                var _bank = bank as Bank;

                this.Context.Banks.Add(_bank);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(object bank)
        {
            try
            {
                var _bank = bank as Bank;

                var bankOld = this.Context.Banks.Where(p => p.Id == _bank.Id).FirstOrDefault();

                bankOld.Name = _bank.Name;

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
                var bankOld = this.Context.Banks.Where(p => p.Id == id).FirstOrDefault();
                this.Context.Banks.Remove(bankOld);

                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
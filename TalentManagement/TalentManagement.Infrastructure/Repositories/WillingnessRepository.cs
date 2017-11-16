using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TalentManagement.Infrastructure.Repositories
{
    public class WillingnessRepository : IRepository
    {
        private TalentManagementContext Context;

        public WillingnessRepository()
        {
            this.Context = new TalentManagementContext();
        }

        public IEnumerable<object> GetAll()
        {
            try
            {
                return this.Context.Willingnesss
                    .ToList() as IEnumerable<Willingness>;
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
                return this.Context.Willingnesss
                    .Where(p => p.Id == id)
                    .FirstOrDefault() as Willingness;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(object willingness)
        {
            try
            {
                var _willingness = willingness as Willingness;

                this.Context.Willingnesss.Add(_willingness);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(object willingness)
        {
            try
            {
                var _willingness = willingness as Willingness;

                var willingnessOld = this.Context.Willingnesss.Where(p => p.Id == _willingness.Id).FirstOrDefault();
                willingnessOld.Description = _willingness.Description;

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
                var willingnessOld = this.Context.Willingnesss.Where(p => p.Id == id).FirstOrDefault();
                this.Context.Willingnesss.Remove(willingnessOld);

                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
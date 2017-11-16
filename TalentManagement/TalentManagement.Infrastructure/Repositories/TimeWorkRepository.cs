using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TalentManagement.Infrastructure.Repositories
{
    public class TimeWorkRepository : IRepository
    {
        private TalentManagementContext Context;

        public TimeWorkRepository()
        {
            this.Context = new TalentManagementContext();
        }

        public IEnumerable<object> GetAll()
        {
            try
            {
                return this.Context.TimeWorks
                    .ToList() as IEnumerable<TimeWork>;
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
                return this.Context.TimeWorks
                    .Where(p => p.Id == id)
                    .FirstOrDefault() as TimeWork;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(object timeWork)
        {
            try
            {
                var _timeWork = timeWork as TimeWork;

                this.Context.TimeWorks.Add(_timeWork);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(object timeWork)
        {
            try
            {
                var _timeWork = timeWork as TimeWork;

                var timeWorkOld = this.Context.TimeWorks.Where(p => p.Id == _timeWork.Id).FirstOrDefault();
                timeWorkOld.Description = _timeWork.Description;

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
                var timeWorkOld = this.Context.TimeWorks.Where(p => p.Id == id).FirstOrDefault();
                this.Context.TimeWorks.Remove(timeWorkOld);

                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
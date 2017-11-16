using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TalentManagement.Infrastructure.Repositories
{
    public class CityRepository : IRepository
    {
        private TalentManagementContext Context;

        public CityRepository()
        {
            this.Context = new TalentManagementContext();
        }

        public IEnumerable<object> GetAll()
        {
            try
            {
                return this.Context.Citys
                    .Include(c => c.State)
                    .ToList() as IEnumerable<City>;
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
                return this.Context.Citys
                    .Include(c => c.State)
                    .Where(p => p.Id == id)
                    .FirstOrDefault() as City;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(object city)
        {
            try
            {
                var _city = city as City;

                this.Context.Citys.Add(_city);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(object city)
        {
            try
            {
                var _city = city as City;

                var cityOld = this.Context.Citys.Where(p => p.Id == _city.Id).FirstOrDefault();

                cityOld.Name = _city.Name;
                cityOld.StateId = _city.StateId;

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
                var cityOld = this.Context.Citys.Where(p => p.Id == id).FirstOrDefault();
                this.Context.Citys.Remove(cityOld);

                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
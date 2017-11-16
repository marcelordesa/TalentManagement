using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Contracts.Services;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Services
{
    public class CityService : ICityService
    {
        private IRepository Repository;

        public CityService(IRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<City> GetAllCityByStateId(int stateId)
        {
            try
            {
                var citys = this.Repository.GetAll() as IEnumerable<City>;

                return citys.Where(c => c.StateId == stateId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
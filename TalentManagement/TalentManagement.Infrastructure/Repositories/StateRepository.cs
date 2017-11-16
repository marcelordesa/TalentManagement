using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TalentManagement.Infrastructure.Repositories
{
    public class StateRepository : IRepository
    {
        private TalentManagementContext Context;

        public StateRepository()
        {
            this.Context = new TalentManagementContext();
        }

        public IEnumerable<object> GetAll()
        {
            try
            {
                return this.Context.States
                    .ToList() as IEnumerable<State>;
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
                return this.Context.States
                    .Where(p => p.Id == id)
                    .FirstOrDefault() as State;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(object state)
        {
            try
            {
                var _state = state as State;

                this.Context.States.Add(_state);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(object state)
        {
            try
            {
                var _state = state as State;

                var stateOld = this.Context.States.Where(p => p.Id == _state.Id).FirstOrDefault();

                stateOld.Name = _state.Name;

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
                var stateOld = this.Context.States.Where(p => p.Id == id).FirstOrDefault();
                this.Context.States.Remove(stateOld);

                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
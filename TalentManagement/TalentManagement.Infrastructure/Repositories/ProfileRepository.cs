using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TalentManagement.Infrastructure.Repositories
{
    public class ProfileRepository : IRepository
    {
        private TalentManagementContext Context;

        public ProfileRepository()
        {
            this.Context = new TalentManagementContext();
        }

        public IEnumerable<object> GetAll()
        {
            try
            {
                return this.Context.Profiles
                    .ToList() as IEnumerable<Profile>;
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
                return this.Context.Profiles
                    .Where(p => p.Id == id)
                    .FirstOrDefault() as Profile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(object profile)
        {
            try
            {
                var _profile = profile as Profile;

                this.Context.Profiles.Add(_profile);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(object profile)
        {
            try
            {
                var _profile = profile as Profile;

                var profileOld = this.Context.Profiles.Where(p => p.Id == _profile.Id).FirstOrDefault();

                profileOld.Description = _profile.Description;

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
                var profileOld = this.Context.Profiles.Where(p => p.Id == id).FirstOrDefault();
                this.Context.Profiles.Remove(profileOld);

                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
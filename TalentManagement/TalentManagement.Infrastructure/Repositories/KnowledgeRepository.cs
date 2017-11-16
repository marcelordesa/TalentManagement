using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TalentManagement.Infrastructure.Repositories
{
    public class KnowledgeRepository : IRepository
    {
        private TalentManagementContext Context;

        public KnowledgeRepository()
        {
            this.Context = new TalentManagementContext();
        }

        public IEnumerable<object> GetAll()
        {
            try
            {
                return this.Context.Knowledges
                    .ToList() as IEnumerable<Knowledge>;
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
                return this.Context.Knowledges
                    .Where(p => p.Id == id)
                    .FirstOrDefault() as Knowledge;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(object knowledge)
        {
            try
            {
                var _knowledge = knowledge as Knowledge;

                this.Context.Knowledges.Add(_knowledge);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(object knowledge)
        {
            try
            {
                var _knowledge = knowledge as Knowledge;

                var knowledgeOld = this.Context.Knowledges.Where(p => p.Id == _knowledge.Id).FirstOrDefault();
                knowledgeOld.Description = _knowledge.Description;

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
                var knowledgeOld = this.Context.Knowledges.Where(p => p.Id == id).FirstOrDefault();
                this.Context.Knowledges.Remove(knowledgeOld);

                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace TalentManagement.Domain.Contracts.Repositories
{
    public interface IRepository
    {
        IEnumerable<object> GetAll();
        object GetById(int id);
        void Insert(object entity);
        void Update(object entity);
        void Delete(int id);
    }
}
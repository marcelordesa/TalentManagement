using System;
using System.Collections.Generic;
using System.Text;
using TalentManagement.Domain.Contracts.Repositories;

namespace TalentManagement.FactoryRepository
{
    public class FactoryRepository
    {
        public FactoryRepository()
        {

        }

        public static IRepository GetRepositoryInstance<T>() where T : IRepository, new()
        {
            return new T();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Domain.Contracts.Services
{
    public interface IBankService
    {
        IEnumerable<Bank> GetAllBank();
    }
}
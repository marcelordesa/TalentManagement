using System;
using System.Collections.Generic;
using System.Text;

namespace TalentManagement.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }

        public virtual State State { get; set; }
    }
}
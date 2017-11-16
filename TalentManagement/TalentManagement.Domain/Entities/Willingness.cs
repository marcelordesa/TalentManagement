using System;
using System.Collections.Generic;
using System.Text;

namespace TalentManagement.Domain.Entities
{
    public class Willingness
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PersonWillingness> PersonWillingnesss { get; set; }
    }
}
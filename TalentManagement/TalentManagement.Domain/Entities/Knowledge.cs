using System;
using System.Collections.Generic;
using System.Text;

namespace TalentManagement.Domain.Entities
{
    public class Knowledge
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PersonKnowledge> PersonKnowledges { get; set; }
    }
}
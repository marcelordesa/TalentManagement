using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TalentManagement.Domain.Entities
{
    public class PersonKnowledge
    {
        [Key]
        public int PersonId { get; set; }
        [Key]
        public int KnowledgeId { get; set; }
        public int Level { get; set; }
    }
}
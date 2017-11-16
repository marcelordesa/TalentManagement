using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TalentManagement.Domain.Entities
{
    public class PersonWillingness
    {
        [Key]
        public int PersonId { get; set; }
        [Key]
        public int WillingnessId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TalentManagement.Domain.Entities
{
    public class PersonTimeWork
    {
        [Key]
        public int PersonId { get; set; }
        [Key]
        public int TimeWorkId { get; set; }
    }
}
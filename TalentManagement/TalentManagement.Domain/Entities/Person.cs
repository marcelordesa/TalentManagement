using System;
using System.Collections.Generic;
using System.Text;

namespace TalentManagement.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Phone { get; set; }
        public string LinkedIn { get; set; }
        public string Portfolio { get; set; }
        public decimal? Salary { get; set; }
        public string Cpf { get; set; }
        public string Agency { get; set; }
        public string AccountNumber { get; set; }
        public string OtherKnowledge { get; set; }
        public string LinkTest { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? BankId { get; set; }
        public int? AccountTypeId { get; set; }
        public string Password { get; set; }
        public int? ProfileId { get; set; }

        public virtual City City { get; set; }
        public virtual State State { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual Profile Profile { get; set; }

        public virtual ICollection<PersonKnowledge> PersonKnowledges { get; set; }
        public virtual ICollection<PersonTimeWork> PersonTimeWorks { get; set; }
        public virtual ICollection<PersonWillingness> PersonWillingnesss { get; set; }
    }
}
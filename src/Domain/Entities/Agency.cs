using Core.BaseClasses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Agency: BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }     
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public List<Agent> Agents { get; set; } = new List<Agent>();
        [MaxLength(512)]
        public string Description { get; set; }
    }
}

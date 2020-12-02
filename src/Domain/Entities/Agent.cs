using Core.BaseClasses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Agent: BaseEntity
    {
        [Required, MaxLength(65)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public List<Agency> Agencies { get; set; } = new List<Agency>();
    }
}

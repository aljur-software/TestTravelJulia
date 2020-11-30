using Core.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayerEF.Entities
{
    public class Agent: BaseEntity
    {
        [Required, MaxLength(65)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Agency> Agencies { get; set; }
    }
}

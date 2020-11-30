using Core.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayerEF.Entities
{
    public class Agency: BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }     
        public List<Contact> Contacts { get; set; }
        public List<Agent> Agents { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }

    }
}

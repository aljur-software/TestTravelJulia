using Core.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayerEF.Entities
{
    public class Contact: BaseEntity
    {
        [Required]
        public ContactType Type { get; set; }
        [Required, MaxLength(65)]
        public string Value { get; set; }
    }

    public enum ContactType
    { 
        Email,
        Phone
    }
}

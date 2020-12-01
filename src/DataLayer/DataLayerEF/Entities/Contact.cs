using Core.BaseClasses;
using Core.Common;
using System.ComponentModel.DataAnnotations;

namespace DataLayerEF.Entities
{
    public class Contact: BaseEntity
    {
        [Required]
        public ContactType Type { get; set; }
        [Required, MaxLength(65)]
        public string Value { get; set; }
    }


}

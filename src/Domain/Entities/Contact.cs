using Core.BaseClasses;
using Core.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Contact: BaseEntity
    {
        [Required]
        public ContactType Type { get; set; } = ContactType.Phone;
        [Required, MaxLength(65)]
        public string Value { get; set; }
    }


}

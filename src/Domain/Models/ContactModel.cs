using Core.Common;
using System;

namespace Domain.Models
{
    [Serializable]
    public class ContactModel
    {
        public int Id { get; set; }
        public ContactType ContactType { get; set; }
        public string Value { get; set; }
    }
}

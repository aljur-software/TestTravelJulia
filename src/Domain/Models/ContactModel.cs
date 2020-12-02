using Core.BaseClasses;
using Core.Common;
using System;

namespace Domain.Models
{
    [Serializable]
    public class ContactModel: BaseModel
    {
        public ContactType ContactType { get; set; }
        public string Value { get; set; }
    }
}

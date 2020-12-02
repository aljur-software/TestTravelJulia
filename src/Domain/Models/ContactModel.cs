using Core.BaseClasses;
using Core.Common;
using System;
using System.Xml.Serialization;

namespace Domain.Models
{
    [Serializable]
    public class ContactModel: BaseModel
    {
        [XmlIgnore]
        public ContactType ContactType { get; set; } = ContactType.Phone;
        public string ContactTypeStr
        {
            get
            {
                return ContactType.ToString();
            }
            set
            {
                ContactType res = ContactType.Phone;
                Enum.TryParse(value, true, out res);
                ContactType = res;
            }
        }

        public string Value { get; set; }
    }
}

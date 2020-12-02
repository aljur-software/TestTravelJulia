using Core.BaseClasses;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    [Serializable]
    public class AgentModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ContactModel> Contacts { get; set; }
    }
}

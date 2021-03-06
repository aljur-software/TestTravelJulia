﻿using Core.BaseClasses;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    [Serializable]
    public class AgencyModel: BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<ContactModel> Contacts { get; set; }
        public List<AgentModel> Agents { get; set; }
        public string Description { get; set; }
    }
}

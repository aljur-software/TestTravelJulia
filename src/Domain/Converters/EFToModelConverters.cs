using Domain.Entities;
using Domain.Models;
using System;
using System.Linq;

namespace Domain.Converters
{
    public static class EFToModelConverters
    {
        public static ContactModel ContactEFToModel(Contact contact)
        {
            if (contact == null) throw new NullReferenceException("contact is null");
            return new ContactModel
            {
                Id = contact.Id,
                ContactType = contact.Type,
                Value = contact.Value
            };
        }

        public static AgentModel AgentEFToModel(Agent agent)
        {
            if (agent == null) throw new NullReferenceException("agent is null");
            return new AgentModel
            {
                Id = agent.Id,
                Name = agent.Name,
                Description = agent.Description,
                Contacts = agent.Contacts?.Select(_ => ContactEFToModel(_)).ToList()
            };
        }

        public static AgencyModel AgencyEFToModel(Agency agency)
        {
            if (agency == null) throw new NullReferenceException("agency is null");
            return new AgencyModel
            {
                Id = agency.Id,
                Name = agency.Name,
                Description = agency.Description,
                Contacts = agency.Contacts?.Select(_ => ContactEFToModel(_)).ToList(),
                Address = agency.Address,
                Agents = agency.Agents?.Select(_ => AgentEFToModel(_)).ToList()
            };
        }
    }
}

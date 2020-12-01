﻿using DataLayerEF.Entities;
using Domain.Models;
using System;
using System.Linq;


namespace Infrastructure.Converters
{
    public static class ModelToEFConverters
    {
        public static Contact ContactModelToEF(ContactModel contact)
        {
            if (contact == null) throw new NullReferenceException("contact is null");
            return new Contact
            {
                Id = contact.Id,
                Type = contact.ContactType,
                Value = contact.Value
            };
        }

        public static Agent AgentModelToEF(AgentModel agent)
        {
            if (agent == null) throw new NullReferenceException("agent is null");
            return new Agent
            {
                Id = agent.Id,
                Name = agent.Name,
                Description = agent.Description,
                Contacts = agent.Contacts?.Select(_ => ContactModelToEF(_)).ToList()
            };
        }

        public static Agency AgencyModelToEF(AgencyModel agency)
        {
            if (agency == null) throw new NullReferenceException("agency is null");
            return new Agency
            {
                Id = agency.Id,
                Name = agency.Name,
                Description = agency.Description,
                Contacts = agency.Contacts?.Select(_ => ContactModelToEF(_)).ToList(),
                Address = agency.Address,
                Agents = agency.Agents?.Select(_ => AgentModelToEF(_)).ToList()
            };
        }
    }
}

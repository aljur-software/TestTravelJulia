using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public static class Constants
    {
        public const string TABLE_AGENT_NAME = "Agent";
        public const string TABLE_AGENCY_NAME = "Agency";
        public const string TABLE_AGENCYAGENT_NAME = "AgencyAgent";
        public const string TABLE_CONTACT_NAME = "Contact";

        public const string CSVHEADER_AGENT = "Id,Name,Description";
        public const string CSVHEADER_AGENCY = "Id,Name,Address,Description";
        public const string CSVHEADER_AGENCYAGENT = "AgenciesId,AgentsId";
        public const string CSVHEADER_AGENTCONTACT = "Id,Type,Value,AgentId";
        public const string CSVHEADER_AGENCYCONTACT = "Id,Type,Value,AgencyId";
        public const string CSV_DELIMITER = ",";

        public const string CSV_EXTENTION = ".CSV";
    }
}

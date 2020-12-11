using Domain.Constants;
using Domain.Converters;
using Domain.Entities;
using Infrastructure.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataPreparation
{
    public class DataForBulkPreparer
    {
        public static Dictionary<string, string> SomeMethod(List<Agency> agencies)
        {
            var entitiesToCSVLines = new List<string>();
            entitiesToCSVLines.AddRange(CSVFormatters.CsvAgencyFormatter(agencies));
            var agencyCSVFilePath = CSVCreator.CreateCSV(entitiesToCSVLines, "H:\\1\\TempCSV\\");

            entitiesToCSVLines.Clear();
            var agencyContactToCSVLines = new List<string>();
            var agentContactToCSVLines = new List<string>();
            var agentsToAgenciesToCSVLines = new List<string>();
            foreach (var agency in agencies)
            {
                agencyContactToCSVLines.AddRange(CSVFormatters.CsvContactFormatter(agency.Contacts, agency.Id, true));
                entitiesToCSVLines.AddRange(CSVFormatters.CsvAgentFormatter(agency.Agents));
                agentsToAgenciesToCSVLines.AddRange(CSVFormatters.CsvAgencyAgentFormatter(agency.Agents, agency.Id));
                foreach (var agent in agency.Agents)
                {
                    agentContactToCSVLines.AddRange(CSVFormatters.CsvContactFormatter(agent.Contacts, agent.Id, false));
                }
            }
            var agencyContactCSVFilePath = CSVCreator.CreateCSV(agencyContactToCSVLines, "H:\\1\\TempCSV\\");
            var agentsCSVFilePath = CSVCreator.CreateCSV(entitiesToCSVLines, "H:\\1\\TempCSV\\");
            var agentContactsCSVFilePath = CSVCreator.CreateCSV(agentContactToCSVLines, "H:\\1\\TempCSV\\");
            var agentsToAgenciesCSVFilePath = CSVCreator.CreateCSV(agentsToAgenciesToCSVLines, "H:\\1\\TempCSV\\");

            var result = new Dictionary<string, string>();
            result.Add("agencyCSVFilePath", agencyCSVFilePath);
            result.Add("agencyContactCSVFilePath", agencyContactCSVFilePath);
            result.Add("agentsCSVFilePath", agentsCSVFilePath);
            result.Add("agentContactsCSVFilePath", agentContactsCSVFilePath);
            result.Add("agentsToAgenciesCSVFilePath", agentsToAgenciesCSVFilePath);
            return result;
        }


    }
}

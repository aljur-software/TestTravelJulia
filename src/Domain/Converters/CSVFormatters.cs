using Domain.Entities;
using System;
using System.Collections.Generic;


namespace Domain.Converters
{
    public class CSVFormatters
    {
        public static List<string> CsvAgencyFormatter(List<Agency> data)
        {
            List<string> list = new List<string>();
            list.Add(Constants.Constants.CSVHEADER_AGENCY);//Constants.CSVHEADER_AGENCY
            foreach (var item in data)
            {
                list.Add($"{item.Id}{Constants.Constants.CSV_DELIMITER}" +
                    $"{item.Name}{Constants.Constants.CSV_DELIMITER}" +
                    $"{item.Address}{Constants.Constants.CSV_DELIMITER}" +
                    $"{item.Description}");
            }

            return list;
        }

        public static List<string> CsvAgentFormatter(List<Agent> data)
        {
            List<string> list = new List<string>();
            list.Add(Constants.Constants.CSVHEADER_AGENT);
            foreach (var item in data)
            {
                list.Add($"{item.Id}{Constants.Constants.CSV_DELIMITER}" +
                    $"{item.Name}{Constants.Constants.CSV_DELIMITER}" +
                    $"{item.Description}");
            }

            return list;
        }

        public static List<string> CsvAgencyAgentFormatter(List<Agent> data, int AgencyId)
        {
            List<string> list = new List<string>();
            list.Add(Constants.Constants.CSVHEADER_AGENCYAGENT);
            foreach (var item in data)
            {
                list.Add($"{AgencyId}{Constants.Constants.CSV_DELIMITER}" +
                    $"{item.Id}{Constants.Constants.CSV_DELIMITER}");
            }

            return list;
        }

        public static List<string> CsvContactFormatter(List<Contact> data, int ownerId, bool IsAgencyContact)
        {
            List<string> list = new List<string>();
            list.Add(IsAgencyContact ? Constants.Constants.CSVHEADER_AGENCYCONTACT : Constants.Constants.CSVHEADER_AGENTCONTACT);
            foreach (var item in data)
            {
                list.Add($"{item.Id}{Constants.Constants.CSV_DELIMITER}" +
                    $"{item.Type}{Constants.Constants.CSV_DELIMITER}" +
                    $"{item.Value}{Constants.Constants.CSV_DELIMITER}" +
                    $"{ownerId}");
            }

            return list;
        }
    }
}

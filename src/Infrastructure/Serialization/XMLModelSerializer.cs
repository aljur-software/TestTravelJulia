using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Infrastructure.Serialization
{
    public class XMLModelSerializer<T> where T: class
    {
        XmlSerializer _serializer;
        public XMLModelSerializer()
        {
            _serializer = new XmlSerializer(typeof(T));
        }

        public T ModelDeserialize(Stream stream)
        {
            using (XmlReader reader = XmlReader.Create(stream))
            {
                var model = (T)_serializer.Deserialize(reader);
                return (model != null) ? model : throw new InvalidOperationException();
            }
        }

        /*
        public static string ToXMLTest(int agencyNum)
        {
            var agency = new Agency() {
                Id = agencyNum,
                Name = "Agency" + agencyNum.ToString(),
                Address = "address of agency " + agencyNum.ToString(),
                Description = "Description " + agencyNum.ToString(),
                Contacts = new List<Contact>() {
                    new Contact {
                        Id = 0,
                        Type = Core.Common.ContactType.Email,
                        Value = "Agency" + agencyNum.ToString() + "@gmail.com" }
                },
                Agents = new List<Agent>()
            };

            for (int i = 1; i < 10001; i++)
            {
                var agent = new Agent()
                {
                    Id = i,
                    Name = "Agent" + i.ToString(),
                    Description = "Description " + i.ToString(),
                    Contacts = new List<Contact>() {
                        new Contact {
                            Id = 0,
                            Type = Core.Common.ContactType.Email,
                            Value = "Agent" + i.ToString() + "@gmail.com"
                        }

                    }
                };
                agency.Agents.Add(agent);
            }

            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(typeof(Agency));
                serializer.Serialize(stringwriter, agency);
                var n = stringwriter.ToString();
                File.WriteAllTextAsync("H:\\1\\TempXML\\XML"+ agencyNum.ToString() + ".xml", n);
                return n;
            }
        }
        */

    }
}

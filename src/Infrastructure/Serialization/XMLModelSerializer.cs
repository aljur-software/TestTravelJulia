using Domain.Models;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Infrastructure.Serialization
{
    public class XMLModelSerializer<T> where T: class
    {
        XmlSerializer _serializer;
        public XMLModelSerializer()//Type T
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

        public static string ToXML1(T obj)
        {
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(typeof(AgencyModel));
                serializer.Serialize(stringwriter, obj);
                var n = stringwriter.ToString();
                return n;
            }
        }
    }
}

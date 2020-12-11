using Core.Common;
using Infrastructure.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;


namespace Infrastructure.ZipReader
{
    public class ZipReader<T> where T : class
    {
        public List<T> ReadFromZip(Stream stream) 
        {
            try
            {
                var agenciesWithAgents = new List<T>();
                using (var archive = new ZipArchive(stream))
                {
                    XMLModelSerializer<T> serializer = new XMLModelSerializer<T>();
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        agenciesWithAgents.Add(serializer.ModelDeserialize(entry.Open()));
                    }
                }
                return agenciesWithAgents;
            }
            catch (Exception ex)
            {
                throw new DeserializeDataException("Reading data from .zip failed: " + ex.Message, ex);
            }

        }       
    }
}

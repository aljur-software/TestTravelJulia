using Domain.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FileManager
{
    public class CSVCreator
    {
        public static string CreateCSV(List<string> info, string directory)
        {
            if (directory == string.Empty)
                directory = Environment.CurrentDirectory + "\\TempCSV\\";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            var fileName = directory + Guid.NewGuid() + Constants.CSV_EXTENTION;
            File.WriteAllLines(fileName, info);

            return fileName;
        }
    }
}

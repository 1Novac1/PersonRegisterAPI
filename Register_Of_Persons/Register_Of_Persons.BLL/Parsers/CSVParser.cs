using CsvHelper;
using Register_Of_Persons.BLL.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Register_Of_Persons.BLL.Parsers
{
    public class CSVParser
    {
        public List<CsvEntityModel> Parse(Stream fileStream)
        {
            try
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                    {
                        return csvReader.GetRecords<CsvEntityModel>().ToList();
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

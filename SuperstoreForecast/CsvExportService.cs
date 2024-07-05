using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

public class CsvExportService
{
    public void ExportSalesDataToCsv(IEnumerable<SalesData> salesData, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(salesData);
        }
    }
}

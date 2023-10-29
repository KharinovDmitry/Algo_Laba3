using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace Core
{
    public class CsvWriter
    {
        public static void WriteAnalyzeResult(AnalyzeResult result)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo("C:\\Users\\terro\\OneDrive\\Рабочий стол\\Charts.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(result.Title);

                worksheet.Cells[1, 1].Value = "ArrLength";
                worksheet.Cells[1, 2].Value = "Time";

                for (int i = 0; i < result.Measurements.Count; i++)
                {
                    var ArrLength = result.Measurements[i].ArrayLength;
                    var Time = result.Measurements[i].TimeInS;

                    worksheet.Cells[i + 2, 1].Value = ArrLength;
                    worksheet.Cells[i + 2, 2].Value = Time;
                }

                package.Save();
            }
        }
    }
}

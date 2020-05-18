using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace TestMultithreadingAndAsyncProcessing
{
    public class ExcelFile
    {
        Application excelFile;
        Workbook workBook;
        Worksheet workSheet;

        public ExcelFile(string filePath, int sheet)
        {
            excelFile = new Excel.Application();
            workBook = excelFile.Workbooks.Open(filePath);
            workSheet = workBook.Worksheets[sheet];
        }

        public string ReadCell(int row, int column)
        {
            if (workSheet.Cells[row, column].Value2 != null)
            {
                return workSheet.Cells[row, column].Value2.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public void CreateListFromColumn(ExcelFile excelFile, List<string> listOfCellContent, int startRow, int finalRow, int column)
        {
            for (int row = startRow; row <= finalRow; row++)
            {
                listOfCellContent.Add(excelFile.ReadCell(row, column).ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace LLW_Framework
{
    public static class NavFromFile
    {
        private static Excel.Application excelApp = new Excel.Application();
        private static Excel._Worksheet workSheet = new Excel.Worksheet();

        public static List<Journals> GetDataFromExcelFile(string filePath)
        {
            List<Journals> fullDataFromFile = new List<Journals>();
            Journals journal;
            JournalMenu jMenu;
            string name;
            var workBook = excelApp.Workbooks.Open(filePath);

            for (int journalCount = 1; journalCount <= workBook.Sheets.Count; journalCount++)
            {
                workSheet = workBook.Sheets[journalCount];

                if (workSheet.Name == "Index")
                {
                    break;
                }
                name = workSheet.Name;

                journal.journalName = name;

                Console.WriteLine("------------------------{0}--------------------------", journal.journalName);
                List<JournalMenu> menu = new List<JournalMenu>();

                for (int column = 1; GetValue(2, column) != ""; column++)
                {
                    string item = GetValue(2, column);
                    Console.WriteLine("*********menu " + item);

                    for (int row = 3; GetValue(row, column) != ""; row++)
                    {
                        if (GetValue(row, column) != "")
                        {
                            jMenu.menuItem = GetValue(row, column);
                            jMenu.menuHeader = item;
                            menu.Add(jMenu);
                            Console.WriteLine(jMenu.menuItem);
                        }
                    }
                }

                journal.menu = menu;
                fullDataFromFile.Add(journal);
            }
            CloseExcelApp();
            return fullDataFromFile;
        }

        private static void CloseExcelApp()
        {
            excelApp.Quit();
            excelApp = null;
        }

        private static string GetValue(int row, int column)
        {
            string cellValue = "";
            Excel.Range cell = (Excel.Range)workSheet.Cells[row, column];
            if (cell.Value != null)
            {
                cellValue = cell.Value.ToString();
            }
            return cellValue;
        }

        public static List<Journals> MakeParamsData(string jourName)
        {
            List<Journals> someJournals = new List<Journals>();
            List<string> journalNames = new List<string>();

            if (jourName == "")
            {
                return GetDataFromExcelFile(ResourceFile.FilePath);
            }
            else
            {
                string[] namesFromTestData = jourName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < namesFromTestData.Count(); i++)
                {
                    journalNames.Add(namesFromTestData[i]);
                }

                foreach (Journals j in GetDataFromExcelFile(ResourceFile.FilePath))
                {
                    foreach (string s in journalNames)
                    {
                        if (s == j.journalName)
                        {
                            someJournals.Add(j);
                        }
                    }
                }
                return someJournals;
            }
        }
    }
}

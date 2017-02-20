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
            JournalMenu menu;
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
                journal.jName = name;
                //Console.WriteLine("------------------------{0}--------------------------", journal.jName);
                List<JournalMenu> jMenu = new List<JournalMenu>();

                for (int column = 1; GetValue(2, column) != ""; column++)
                {
                    //journalMenu.Add(GetValue(2, column));
                    string item = GetValue(2, column);
                    //Console.WriteLine("*********menu " + item);

                    for (int row = 3; GetValue(row, column) != ""; row++)
                    {
                        if (GetValue(row, column) != "")
                        {
                            menu.menuItem = GetValue(row, column);
                            menu.menuHeader = item;
                            jMenu.Add(menu);
                            //Console.WriteLine(menu.menuItem);
                            //journalMenu.Add(GetValue(row, column));
                        }
                    }
                }

                journal.jMenu = jMenu;
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

        public static List<Journals> MakeParamsData(string journalName)
        {
            List<Journals> someJournals = new List<Journals>();
            List<string> journalNames = new List<string>();

            if (journalName == "")
            {
                return GetDataFromExcelFile(ResourceFile.FilePath);
            }
            else
            {
                string[] namesFromTestData = journalName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < namesFromTestData.Count(); i++)
                {
                    journalNames.Add(namesFromTestData[i]);
                }

                foreach (Journals j in GetDataFromExcelFile(ResourceFile.FilePath))
                {
                    foreach (string s in journalNames)
                    {
                        if (s == j.jName)
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
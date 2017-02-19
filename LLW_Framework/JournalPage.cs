using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LLW_Framework
{
    public class JournalPage
    {
        internal IWebDriver driver;
        static string url;
        static string menuHeaderXPath = "//a[contains(text(), \"";
        static string menuItemXPath = "//span[contains(text(), \"";
        static string tmpMenuHeaderXPath;
        static string tmpMenuItemXPath;

        public bool CheckItemExist(BaseElement obj, IWebDriver driver)
        {
            if (obj.getElement(driver) != null)
            {
                return true;
            }
            else return false;
        }

        public JournalPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static void GoToTheJournal(string journalName, IWebDriver driver)
        {
            try
            {
                url = string.Concat(SetUpData.BaseUrl, journalName);
                driver.Navigate().GoToUrl(url);
            }
            catch (Exception e)
            {
                string message = string.Format("journal page {0} is unavailable", url);
            }
        }

        public static List<Journals> MakeParamsData(string jourName)
        {
            List<Journals> someJournals = new List<Journals>();
            List<string> journalNames = new List<string>();

            if (jourName == "")
            {
                return NavFromFile.GetDataFromExcelFile(ResourceFile.FilePath);
            }
            else
            {
                String[] namesFromTestData = jourName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < namesFromTestData.Count(); i++)
                {
                    journalNames.Add(namesFromTestData[i]);
                }

                foreach (Journals j in NavFromFile.GetDataFromExcelFile(ResourceFile.FilePath))
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

        public static void CheckMenuHeader(Journals j, IWebDriver driver)
        {
            foreach (var menu in j.menu)
            {
                if (nameof(menu.menuHeader) == "menuHeader")
                {
                    tmpMenuHeaderXPath = string.Concat(menuHeaderXPath, menu.menuHeader, "\")]");
                }
            }

        }
    }
}
//}
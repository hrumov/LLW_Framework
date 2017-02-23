using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NLog;

namespace LLW_Framework
{
    public class JournalPage
    {
        private IWebDriver driver;
        private string url;
        public string menuHeaderXPath { get; } = "//a[contains(text(), '***')]"; //'Articles & Issues'
        public string menuItemXPath { get; } = "//span[contains(text(), '***' )]"; //'Subjects'
        public string journalName { get; } = "aacr";

        //static Logger logger = LogManager.GetCurrentClassLogger();

        public JournalPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public JournalPage()
        {
        }

        public bool IsElementPresent(string elementXPath, IWebDriver driver)
        {
            return driver.FindElement(By.XPath(elementXPath)).Enabled;
        }

        public bool IsJournalExist(string journalName, IWebDriver driver)
        {
            try
            {
                url = string.Concat(ResourceFile.BaseUrl, journalName);
                //logger.Debug("Going to the journal page {0}", url);
                driver.Navigate().GoToUrl(url);
            }
            catch (Exception e)
            {
                string message = string.Format("The journal {0} does not exist", journalName);
                //logger.Error(e, message);
            }
            if (driver.Url.Contains("PageNotFoundError"))
                return true;
            else return false;
        }

        /*public bool CheckMenuHeader(JournalPage jp, Journals j, IWebDriver driver)
        {
            if (jp.IsJournalExist(j.jName, driver))
            {
                foreach (var item in j.jMenu)
                {
                    if (nameof(item.menuHeader) == "menuHeader")
                    {
                        Console.WriteLine("++++ {0}", item.menuHeader.ToString());
                        logger.Info("Checking if element exists {0}, its XPath: {1}", item.menuHeader, menuHeaderXPath);
                        return driver.FindElement(By.XPath(menuHeaderXPath.Replace("***", item.menuHeader))).Enabled;
                    }
                    else
                    {
                        Console.WriteLine("error {0}", item.ToString());
                        return false;
                    }
                }
            }
            return false;
        }

        public bool CheckMenuItem(JournalPage jp, Journals j, IWebDriver driver)
        {
            if (jp.IsJournalExist(j.jName, driver))
            {
                foreach (var item in j.jMenu)
                {
                    if (nameof(item.menuItem) == "menuItem")
                    {
                        Console.WriteLine("---- {0}", item.menuItem.ToString());
                        logger.Info("Checking if element exists {0}, its XPath: {1}", item.menuItem, menuItemXPath);
                        return driver.FindElement(By.XPath(menuItemXPath.Replace("***", item.menuItem))).Enabled;
                    }
                    else
                    {
                        Console.WriteLine("error {0}", item.ToString());
                        return false;
                    }
                }
            }
            return false;
        }*/
    }
}

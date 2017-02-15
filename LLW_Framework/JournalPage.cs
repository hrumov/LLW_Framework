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

        public JournalPage(IWebDriver driver)
        {
            this.driver = driver;
        }


    }
}

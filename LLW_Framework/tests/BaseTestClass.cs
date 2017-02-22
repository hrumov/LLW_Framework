using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLW_Framework
{
    [TestFixture]
    public class BaseTestClass
    {
        public IWebDriver driverForJournals = BrowserFactory.GetBrowser(ResourceFile.Browser);
        //public IWebDriver driverForLogin = BrowserFactory.GetBrowser(ResourceFile.Browser);
    }
}

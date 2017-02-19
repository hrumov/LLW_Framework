using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLW_Framework
{
    [TestFixture]
    public class BaseTestNUnit
    {
        public IWebDriver driverForJournals = BrowserFactory.getBrowser(ResourceFile.Browser);
        //public IWebDriver driverForLogin = BrowserFactory.getBrowser(ResourceFile.Browser);
    }
}

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
    public class JournalTest
    {
        internal IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [Test]
        public void a()
        {
            driver.Navigate().GoToUrl(SetUpData.BaseUrl + "aacr");
            JournalPage jp = new JournalPage(driver);
            //driver.FindElement(By.XPath("//span[contains(text(), /aacr/subjects )]"));
            //bool isElementPresent = driver.FindElement(By.XPath("//span[contains(text(), 'Subjects' )]")).Enabled;
            bool isElementPresent = driver.FindElement(By.XPath("//a[contains(text(), 'Articles & Issues')]")).Enabled;
            Assert.True(isElementPresent);

        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Dispose();
        }
    }
}

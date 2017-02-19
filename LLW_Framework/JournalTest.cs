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
    public class JournalTest : BaseTestNUnit
    {
        //internal IWebDriver driver;
        static List<Journals> dataForParams = NavFromFile.MakeParamsData(ResourceFile.JournalsToTest);
        static AssertsAccumulator accumulator = new AssertsAccumulator();

        [SetUp]
        public void SetUp()
        {

            driverForJournals.Manage().Window.Maximize();
            driverForJournals.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            /*driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));*/
        }

        [Test]
        [TestCaseSource("dataForParams")]
        public void NavigationTest(Journals j)
        {
            //JournalPage jp = new JournalPage(driver);

            JournalPage.GoToTheJournal(j.journalName, driverForJournals);
            //JournalPage.

            

            //driver.Navigate().GoToUrl(SetUpData.BaseUrl + "aacr");
            //JournalPage jp = new JournalPage(driver);
            //driver.FindElement(By.XPath("//span[contains(text(), /aacr/subjects )]"));
            //bool isElementPresent = driver.FindElement(By.XPath("//span[contains(text(), 'Subjects' )]")).Enabled;

            bool isElementPresent = driverForJournals.FindElement(By.XPath("//a[contains(text(), 'Articles & Issues')]")).Enabled;
            Assert.True(isElementPresent);

        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            driverForJournals.Dispose();
        }
    }
}

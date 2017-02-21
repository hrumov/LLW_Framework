﻿using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLW_Framework
{
    [TestFixture]
    public class JournalTest : BaseTestClass
    {
        private static List<Journals> navParams = NavFromFile.MakeParamsData(ResourceFile.JournalName);
        private static AssertsAccumulator accumulator = new AssertsAccumulator();
        private static JournalPage jp = new JournalPage();
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        private static IEnumerable<TestCaseData> AddCases()
        {
            yield return new TestCaseData("123");
            yield return new TestCaseData("234");
            yield return new TestCaseData("345");
        }

        private static TestCaseData CreateTestCaseData(Journals j)
        {
            return new TestCaseData(); 
        }

        //static Logger logger = LogManager.GetCurrentClassLogger();

        [SetUp]
        public void SetUp()
        {
            driverForJournals.Manage().Window.Maximize();
            driverForJournals.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [Test]
        [TestCaseSource("AddCases")]
        public void paramTest(string name)
        {
            Assert.IsNotNull(name);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        /*
        //переделать параметризацию. она возможна для string, int
        //к собесу jenkins, serialisation
        [Test]
        //[Ignore("123")]
        [TestCaseSource("navParams")]
        public void CheckJournalexisting(Journals j)
        {
            Assert.False(jp.IsJournalExist(j.jName, driverForJournals));
            //accumulator.Accumulate(() => Assert.True(jp.IsJournalExist(j.jName, driverForJournals)));
            //accumulator.Release();
        }

        [Test]
        //[Ignore("123")]
        [TestCaseSource("navParams")]
        public void NavigationTest(Journals j)
        {
            driverForJournals.Navigate().GoToUrl(string.Concat(ResourceFile.BaseUrl, j.jName));
            foreach (var item in j.jMenu)
            {
                if (nameof(item.menuItem) == "menuItem")
                {
                    //Console.WriteLine("---- {0}", item.menuItem.ToString());
                    string a = string.Concat("++++ {0}", item.menuItem.ToString(), "in journal ", j.jName, "not found");
                    //logger.Info("Checking if element exists {0}, its XPath: {1}", item.menuItem, jp.menuItemXPath);
                    Assert.True(driverForJournals.FindElement(By.XPath(jp.menuItemXPath.Replace("***", item.menuItem))).Enabled, a);
                    //accumulator.Accumulate(() => Assert.True(driverForJournals.FindElement(By.XPath(jp.menuItemXPath.Replace("***", item.menuItem))).Enabled));
                }
                if (nameof(item.menuHeader) == "menuHeader")
                {
                    //Console.WriteLine("==== {0}", item.menuHeader.ToString());
                    string a = string.Concat("++++ {0}", item.menuHeader.ToString(), "in journal ", j.jName, "not found");
                    //logger.Info("Checking if element exists {0}, its XPath: {1}", item.menuHeader, jp.menuHeaderXPath);
                    Assert.True(driverForJournals.FindElement(By.XPath(jp.menuHeaderXPath.Replace("***", item.menuHeader))).Enabled, a);
                    //accumulator.Accumulate(() => Assert.True(driverForJournals.FindElement(By.XPath(jp.menuHeaderXPath.Replace("***", item.menuHeader))).Enabled, a));
                }
            }
            accumulator.Release();
        }
        */
        [OneTimeTearDown]
        public void CloseDriver()
        {
            //driverForJournals.Dispose();
            driverForJournals.Quit();
        }
    }
}

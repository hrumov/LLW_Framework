﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLW_Framework
{
    [TestFixture]
    public class LoginTest : BaseTestClass
    {
        static LoginPage lp = new LoginPage();

        [SetUp]
        public void SetUp()
        {
            driverForJournals.Manage().Window.Maximize();
            driverForJournals.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            //driverForLogin.Manage().Window.Maximize();
            //driverForLogin.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [Test]
        public void LoginCheck()
        {
            Assert.True(lp.CheckLogin(driverForJournals));
            //Assert.True(lp.CheckLogin(driverForLogin));
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            driverForJournals.Quit();
            //driverForLogin.Quit();
        }
    }
}

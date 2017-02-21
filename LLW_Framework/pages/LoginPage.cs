using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLW_Framework
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string logOutXpath = "//a[contains(text(), 'Log Out')]";
        private string loginFormXPath = "//input[@placeholder='Username or Email']";
        private string passwordFormXPath = "//input[@placeholder='Password']";
        private string loginButtomXPath = "//input[@value='Login']";

        /*public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }*/

        public LoginPage()
        {
        }

        public bool CheckLogin(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(ResourceFile.BaseUrl);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Int32.Parse(ResourceFile.ElementWaitingTime)));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(loginFormXPath)));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(passwordFormXPath)));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(loginButtomXPath)));
            //wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(loginButtomXPath)));

            driver.FindElement(By.XPath(loginFormXPath)).Clear();
            driver.FindElement(By.XPath(loginFormXPath)).SendKeys(ResourceFile.Login);

            driver.FindElement(By.XPath(passwordFormXPath)).Clear();
            driver.FindElement(By.XPath(passwordFormXPath)).SendKeys(ResourceFile.Password);

            driver.FindElement(By.XPath(loginButtomXPath)).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Int32.Parse(ResourceFile.ElementWaitingTime)));

            if (driver.FindElement(By.XPath(logOutXpath)).Displayed)
                return true;
            return false;
        }
    }
}

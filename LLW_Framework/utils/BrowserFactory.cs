using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLW_Framework
{
    public class BrowserFactory
    {
        public static IWebDriver GetBrowser(String browser)
        {
            IWebDriver driver = null;

            switch (browser)
            {
                case "firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                    }
                    break;

                case "chrome":
                    if (driver == null)
                    {
                        driver = new ChromeDriver();
                    }
                    break;
            }
            return driver;
        }
    }
}

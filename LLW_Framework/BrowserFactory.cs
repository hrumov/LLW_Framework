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
        public static IWebDriver getBrowser(String browser)
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

                /*case "remote":
                    //IWebDriver driver;
                    DesiredCapabilities desiredCap = DesiredCapabilities.Firefox();
                    desiredCap.SetCapability("browserstack.user", "uladzimir5");
                    desiredCap.SetCapability("browserstack.key", "RSQy6UiFJ5iEUDg2EosK");

                    driver = new RemoteWebDriver(
                      new Uri("http://hub-cloud.browserstack.com/wd/hub/"), desiredCap
                    );
                    break;*/
            }
            return driver;
        }
    }
}

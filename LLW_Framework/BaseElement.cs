using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLW_Framework
{
    public class BaseElement
    {
        public By locator;
        public string name;

        public BaseElement(By locator, string name)
        {
            this.locator = locator;
            this.name = name;
        }

        public IWebElement getElement(IWebDriver driver)
        {
            try
            {
                return driver.FindElement(locator);
            }
            catch (NoSuchElementException e)
            {
                return null;
            }
        }
    }
}

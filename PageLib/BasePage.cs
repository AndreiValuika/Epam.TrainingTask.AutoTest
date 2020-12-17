using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Linq;

namespace PageLib
{
    public abstract class BasePage
    {
        protected static IWebDriver _driver;

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }

        public void Maximize() 
        {
            _driver.Manage().Window.Maximize();
        }

        public bool IsElementPresent(By locator)
        {
            return _driver.FindElements(locator).Count() > 0;
        }
    }

}

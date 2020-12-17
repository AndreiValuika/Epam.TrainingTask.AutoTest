using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageLib
{
    public class StartPage:BasePage
    {
        public StartPage(IWebDriver driver,string url) : base(driver)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public LoginPage goLogin() 
        {
            _driver.FindElement(By.XPath("//a[@href='/login']")).Click();
            return new LoginPage(_driver);
        }
    }
}

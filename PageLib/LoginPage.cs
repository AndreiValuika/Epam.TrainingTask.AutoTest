using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageLib
{
    public class LoginPage : BasePage
    {
        
        public LoginPage(IWebDriver driver) : base(driver)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            IWebElement element = wait.Until(d => d.FindElement(By.XPath("//*[@id='login']/form/div[1]/h1")));
        }


        public IWebElement LoginField => _driver.FindElement(By.Id("login_field"));

        public IWebElement PasswordField => _driver.FindElement(By.Id("password"));

        public IWebElement CommitButton => _driver.FindElement(By.Name("commit"));

        public MainPage logIn(string user, string password) 
        {
            LoginField.SendKeys(user);
            PasswordField.SendKeys(password);
            CommitButton.Click();
            return new MainPage(_driver);
        }


    }
}

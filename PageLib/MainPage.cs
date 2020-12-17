using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageLib
{
    public class MainPage:BasePage
    {

        public IWebElement NewRepoButton => _driver.FindElement(By.XPath("//*[@id='repos-container']/h2/a"));

        public IWebElement RepoNameField => _driver.FindElement(By.Id("repository_name"));
        public MainPage(IWebDriver driver) : base(driver)
        {
            
        }
        public MainPage CreateRepo(string repo) 
        {
            NewRepoButton.Click();
            RepoNameField.SendKeys(repo);

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            var CreateButton = wait.Until(d => d.FindElement(By.XPath("//*[@id='new_repository']/div[4]/button")));
           
            while (!CreateButton.Enabled){}

            CreateButton.Click();

            return this; 

        }
        public bool CheckRepoName(string repo) 
        {
            try
            {
                _driver.FindElement(By.LinkText(repo));
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}

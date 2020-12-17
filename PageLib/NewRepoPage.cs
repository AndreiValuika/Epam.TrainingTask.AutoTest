using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageLib
{
    public class NewRepoPage:BasePage
    {
        public IWebElement RepoNameField => _driver.FindElement(By.Id("repository_name"));
        public IWebElement CreateButton => _driver.FindElement(By.XPath("//*[@id='new_repository']/div[4]/button"));
        public NewRepoPage(IWebDriver driver) : base(driver)
        {

        }

        public MainPage CreateRepo(string repo) 
        {
            RepoNameField.SendKeys(repo);

            CreateButton.Click();

            return new MainPage(_driver);
        }
    }
}

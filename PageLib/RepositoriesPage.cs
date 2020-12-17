using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageLib
{
   public class RepositoriesPage:BasePage
    {
        public RepositoriesPage(IWebDriver driver) : base(driver)
        {

        }

        public string getRepoName()
        {
            return _driver.FindElement(By.XPath("//*[@id='js-repo-pjax-container']/div[1]/div/div/h1/strong/a")).Text;
        }

        public SettingPage goSetting() 
        {
            IWebElement item = _driver.FindElement(By.XPath("//ul/li[1]/div[1]/div[1]/h3/a"));
            item.Click();
            _driver.FindElement(By.XPath("//ul/li[9]/a")).Click();
            return new SettingPage(_driver);
        }
    }
}

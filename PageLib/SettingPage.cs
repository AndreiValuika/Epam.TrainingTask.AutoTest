using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageLib
{
    public class SettingPage:BasePage
    {
        private By menuButton = By.XPath("//header/div[7]/details/summary");
        private By deleteRepoButton = By.XPath("//ul/li[4]/details/summary");

        public IWebElement DeleteButton => _driver.FindElement(By.XPath("//ul/li[4]/details/summary"));

        public IWebElement nameField => _driver.FindElement(By.Name("new_name"));
        public IWebElement renameButton => _driver.FindElement(By.XPath("//button[text()='Rename']"));
        public SettingPage(IWebDriver driver) : base(driver)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            IWebElement element = wait.Until(d=>d.FindElement(By.XPath("//*[@id='options_bucket']/div[1]/h2")));
        }


        public RepositoriesPage Rename(string newName) 
        {
            nameField.SendKeys(Keys.LeftControl + "a");
            nameField.SendKeys(Keys.Delete);
            nameField.SendKeys(newName);
            while (!renameButton.Enabled)
            {

            }
            renameButton.Click();
            return new RepositoriesPage(_driver);
        }

        public void MakePrivate() 
        {
            var item = _driver.FindElement(By.XPath("//*[@id='options_bucket']/div[10]/ul/li[1]/div[1]/form/details/summary"));
            item.Click();

            var item1 = _driver.FindElement(By.XPath("//*[@id='options_bucket']/div[10]/ul/li[1]/div[1]/form/details/details-dialog/div[3]/div[2]/label/input"));
            item1.Click();

            string delRepoName = _driver.FindElement(By.XPath("//*[@id='options_bucket']/div[10]/ul/li[1]/div[1]/form/details/details-dialog/div[4]/p[1]/strong")).Text;
            _driver.FindElement(By.XPath("//*[@id='options_bucket']/div[10]/ul/li[1]/div[1]/form/details/details-dialog/div[4]/p[2]/input")).SendKeys(delRepoName);
            _driver.FindElement(By.XPath("//*[@id='options_bucket']/div[10]/ul/li[1]/div[1]/form/details/details-dialog/div[4]/div/button")).Click();
        }
        
        public MainPage DeleteRepo() 
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            //IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(menuButton));
            //_driver.FindElement(menuButton).Click();

            //IWebElement element1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Your repositories']")));
            //_driver.FindElement(By.XPath("//a[text()='Your repositories']")).Click();

            //IWebElement item = _driver.FindElement(By.XPath("//ul/li[1]/div[1]/div[1]/h3/a"));
            //string repoName = item.Text;
            //item.Click();

           // _driver.FindElement(By.XPath("//ul/li[9]/a")).Click();

            IWebElement element3 = wait.Until(ExpectedConditions.ElementToBeClickable(deleteRepoButton));
            _driver.FindElement(deleteRepoButton).Click();

            string delRepoName = _driver.FindElement(By.XPath("//*[@id='options_bucket']/div[10]/ul/li[4]/details/details-dialog/div[3]/p[2]/strong")).Text;
            _driver.FindElement(By.XPath("//*[@id='options_bucket']/div[10]/ul/li[4]/details/details-dialog/div[3]/form/p/input")).SendKeys(delRepoName);

            _driver.FindElement(By.XPath("//*[@id='options_bucket']/div[10]/ul/li[4]/details/details-dialog/div[3]/form/button")).Click();


            return new MainPage(_driver);


        }

    }
}

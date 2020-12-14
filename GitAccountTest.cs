using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Epam.TrainingTask.AutoTest
{
    public class GitAccountTest
    {
        private IWebDriver _driver;
        private const string SOURSE_URL = "https://github.com";
        private By createButton = By.XPath("//*[@id='new_repository']/div[4]/button");
        private By menuButton = By.XPath("//header/div[7]/details/summary");
        private By deleteRepoButton = By.XPath("//ul/li[4]/details/summary");

        [OneTimeSetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("disable-infobars");
            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl(SOURSE_URL);

            _driver.FindElement(By.XPath("//a[@href='/login']")).Click();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.Id("login_field")));

            _driver.FindElement(By.Id("login_field")).SendKeys("valujkoTest");
            _driver.FindElement(By.Id("password")).SendKeys("Still1717");

            _driver.FindElement(By.Name("commit")).Click();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void CreateRepoTest()
        {
            _driver.FindElement(By.XPath("//*[@id='repos-container']/h2/a")).Click();
            _driver.FindElement(By.Id("repository_name")).SendKeys("TestRepo");

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(createButton));
            _driver.FindElement(createButton).Click();
            _driver.FindElement(By.LinkText("TestRepo"));

            Assert.Pass();
        }
        [Test]
        public void DeleteRepoTest()
        {
            
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(menuButton));
            _driver.FindElement(menuButton).Click();
            
            IWebElement element1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Your repositories']")));
            _driver.FindElement(By.XPath("//a[text()='Your repositories']")).Click();

            IWebElement item = _driver.FindElement(By.XPath("//ul/li[1]/div[1]/div[1]/h3/a"));
            string repoName = item.Text;
            item.Click();
            
            _driver.FindElement(By.XPath("//ul/li[9]/a")).Click();

            IWebElement element3 = wait.Until(ExpectedConditions.ElementToBeClickable(deleteRepoButton));
            _driver.FindElement(deleteRepoButton).Click();

            string delRepoName = _driver.FindElement(By.XPath("//*[@id='options_bucket']/div[10]/ul/li[4]/details/details-dialog/div[3]/p[2]/strong")).Text;
            _driver.FindElement(By.XPath("//*[@id='options_bucket']/div[10]/ul/li[4]/details/details-dialog/div[3]/form/p/input")).SendKeys(delRepoName);

            _driver.FindElement(By.XPath("//*[@id='options_bucket']/div[10]/ul/li[4]/details/details-dialog/div[3]/form/button")).Click();
            Assert.Pass();
        }
        
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }








    }
}

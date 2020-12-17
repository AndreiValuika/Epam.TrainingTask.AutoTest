using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Epam.TrainingTask.AutoTest
{
    public class GitAccountTest
    {
        static Browser Browser = Browser.Instance;
        private const string LOGIN = "valujkoTest";
        private const string PASSWORD = "Still1717";
        private IWebDriver _driver;
        private const string SOURSE_URL = "https://github.com";
        private By menuButton = By.XPath("//header/div[7]/details/summary");

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Browser = Browser.Instance;
            _driver = Browser.GetDriver();

            new StartPage(_driver, SOURSE_URL)
                .goLogin()
                .logIn(LOGIN, PASSWORD)
                .Maximize();

        }

        [SetUp]
        public void Setup() 
        {
            Browser.NavigateTo(SOURSE_URL);
        }

        [TestCase("Tes21")]
        public void CreateRepoTest(string repo)
        {
            var result = new MainPage(_driver)
                .CreateRepo(repo)
                .CheckRepoName(repo);

            Assert.IsTrue(result);
        }

        [Test]
        public void MakePrivateTest()
        {
            GoRepository();
            new RepositoriesPage(_driver)
                             .goSetting()
                             .MakePrivate();
            
            Assert.Pass();
        }

        [TestCase("Testi146542")]
        public void DeleteRepoTest(string repo)
        {
            new MainPage(_driver).CreateRepo(repo);

            GoRepository();
            var result = new RepositoriesPage(_driver)
                                .goSetting()
                                .DeleteRepo()
                                .CheckRepoName(repo);
           
            Assert.IsFalse(result);
        }

        public void GoRepository()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementToBeClickable(menuButton));
            _driver.FindElement(menuButton).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Your repositories']")));
            _driver.FindElement(By.XPath("//a[text()='Your repositories']")).Click();
        }


        [TestCase("NewNa1")]
        public void RenameRepoTest(string repo)
        {
            GoRepository();
            var result = new RepositoriesPage(_driver)
                             .goSetting()
                             .Rename(repo)
                             .getRepoName();
                     
            Assert.AreEqual(repo,result);
        }

       

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }








    }
}

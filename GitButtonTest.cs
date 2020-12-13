using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Epam.TrainingTask.AutoTest
{
    public class Tests
    {
        private IWebDriver _driver;
        private const string SOURSE_URL = "https://github.com";

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(SOURSE_URL);
        }

        [Test]
        public void CreateAccountButtonClickTest()
        {
            _driver.FindElement(By.LinkText("Sign up for GitHub")).Click();
            _driver.FindElement(By.XPath("//h1[text()='Create your account']"));
            Assert.Pass();
        }

        [Test]
        public void SingInButtonClickTest()
        {
            _driver.FindElement(By.XPath("//a[@href='/login']")).Click();
            Assert.AreEqual(_driver.Url, "https://github.com/login");
        }

        [Test]
        public void SingInTest()
        {
            _driver.FindElement(By.XPath("//a[@href='/login']")).Click();
            _driver.FindElement(By.Id("login_field")).SendKeys("valujkoTest");
            _driver.FindElement(By.Id("password")).SendKeys("Still1717");
            _driver.FindElement(By.Name("commit")).Click();
            var newButton = _driver.FindElement(By.XPath("//a[@href='/new']"));
            Assert.NotNull(newButton);
        }

        [TearDown]
        public void TearDown() 
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
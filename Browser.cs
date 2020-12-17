using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.TrainingTask.AutoTest
{
	public class Browser
	{
		private static Browser _currentInstane;
		private static IWebDriver _driver;
		public static int ImplWait;
		public static double TimeoutForElement;

		private Browser()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArgument("disable-infobars");
			_driver = new ChromeDriver(options);
		}

		

		public static Browser Instance => _currentInstane ?? (_currentInstane = new Browser());

		public static void WindowMaximise()
		{
			_driver.Manage().Window.Maximize();
		}

		public static void NavigateTo(string url)
		{
			_driver.Navigate().GoToUrl(url);
		}

		public static IWebDriver GetDriver()
		{
			return _driver;
		}

		public static void Quit()
		{
			_driver.Quit();
			_currentInstane = null;
			_driver = null;
		}
	}
}

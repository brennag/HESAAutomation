using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using CMPTestAutomation.PageObjects;
using TechTalk.SpecFlow;

namespace CMPTestAutomation
{
    [Binding]
    public class Hooks
    {
        private static IWebDriver _driver;

        [BeforeTestRun(Order = 1)]
        public static void BeforeTestRun()
        {
            var options = new ChromeOptions();
            options.AddArguments("--incognito");
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),options);
            _driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(3);
            _driver.Manage().Window.Maximize();
            PageObjectFactory.StrapiLoginPage = new LoginPage(_driver);
            PageObjectFactory.StrapiHomePage = new HomePage(_driver);
            PageObjectFactory.StrapiIntroPage = new SIntroPage(_driver);
            PageObjectFactory.StrapiReleaseSchedulePage = new SReleaseSchedulePage(_driver);
            PageObjectFactory.StrapiDataDictionariesPage = new SDataDictionariesPage(_driver);
            PageObjectFactory.StrapiDataDictionaryEntitiesPage = new SDataDictionaryEntitiesPage(_driver);
            PageObjectFactory.StrapiDataDictionaryFieldsPage = new SDataDictionaryFieldsPage(_driver);
            PageObjectFactory.GatsbyHomePage = new GHomePage(_driver);
            PageObjectFactory.GatsbyIntroPage = new GIntroPage(_driver);
            PageObjectFactory.GatsbyReleaseSchedulePage = new GReleaseSchedulePage(_driver);
            PageObjectFactory.GatsbyDataDictionaryPage = new GDataDictionaryPage(_driver);
        }

        [AfterTestRun(Order = 1)]
        public static void AfterTestRun()
        {
            _driver.Close();
            _driver.Dispose();
            _driver = null;
        }
    }
}
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CMPTestAutomation.PageObjects
{
    public class GDataDictionaryPage : BasePageObject
    {
        public GDataDictionaryPage(IWebDriver driver)
        {
            Url = "https://hesacodingmanualdev.z33.web.core.windows.net/dataDictionary/";
            Driver = driver;
        }
        private IWebElement DataDictionaryPageHeader => Driver.FindElement(By.XPath("/html/body/div/div[1]/div/main/div/h1"));
        private IWebElement HomePageBreadCrumb => Driver.FindElement(By.LinkText("Go back to the homepage"));

        public bool BrowserIsOnGatsbyDataDictionaryPage
        {
            get
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

                wait.Until(d => DataDictionaryPageHeader.Displayed);
                
                return Driver.Url == Url;
            }
        }

        public bool GatsbyDataDictionaryHeaderDisplayed => DataDictionaryPageHeader.Displayed;
        public bool GatsbyHomePageBreadcrumbLinkDisplayed => HomePageBreadCrumb.Displayed;
    }
}
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CMPTestAutomation.PageObjects
{
    public class GHomePage : BasePageObject
    {
        public GHomePage(IWebDriver driver)
        {
            Url = "https://hesacodingmanualdev.z33.web.core.windows.net/";
            Driver = driver;
        }
        private IWebElement HomePageHeader => Driver.FindElement(By.XPath("/html/body/div/div[1]/div/main/h1"));
        private IWebElement WelcomeToHomePage => Driver.FindElement(By.XPath("/html/body/div/div[1]/div/main/p"));
        private IWebElement IntroductionPageLink => Driver.FindElement(By.LinkText("Introduction"));
        private IWebElement DataModelPageLink => Driver.FindElement(By.LinkText("Data Model"));
        private IWebElement ReleaseSchedulePageLink => Driver.FindElement(By.LinkText("Coding Manual Release Schedule"));
        private IWebElement DataDictionaryPageLink => Driver.FindElement(By.LinkText("Data Dictionary"));

        public bool BrowserIsOnGatsbyHomePage
        {
            get
            {
                //Wait until the name of the page is visible
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

                wait.Until(d => HomePageHeader.Displayed);

                return Driver.Url == Url;
            }
        }

        public bool GatsbyHomePageHeaderDisplayed => HomePageHeader.Displayed;
        public bool GatsbyHomeWelcomeToHomePageDisplayed => WelcomeToHomePage.Displayed;
        public bool GatsbyHomeIntroductionPageLinkDisplayed => IntroductionPageLink.Displayed;
        public bool GatsbyHomeDataModelPageLinkDisplayed => DataModelPageLink.Displayed;
        public bool GatsbyHomeReleaseSchedulePageLinkDisplayed => ReleaseSchedulePageLink.Displayed;
        public bool GatsbyDataDictionaryLinkDisplayed => DataDictionaryPageLink.Displayed;
    }
}
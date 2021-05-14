using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CMPTestAutomation.PageObjects
{
    public class GIntroPage : BasePageObject
    {
        public GIntroPage(IWebDriver driver)
        {
            Url = "https://hesacodingmanualdev.z33.web.core.windows.net/introduction/";
            Driver = driver;
        }
        private IWebElement IntroPageHeader => Driver.FindElement(By.XPath("/html/body/div/div[1]/div/main/div/h1"));
        private IWebElement VersionWrapper => Driver.FindElement(By.XPath("/html/body/div/div[1]/div/main/div/div[1]"));
        private IWebElement IntroContent => Driver.FindElement(By.XPath("/html/body/div/div[1]/div/main/div/div[2]/div"));
        private IWebElement HomePageBreadCrumb => Driver.FindElement(By.LinkText("Go back to the homepage"));

        public bool BrowserIsOnGatsbyIntroPage
        {
            get
            {
                //Wait until the name of the page is visible
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(d => IntroPageHeader.Displayed);

                return Driver.Url == Url;
            }
        }

        public bool GatsbyIntroPageHeaderDisplayed => IntroPageHeader.Displayed;
        public bool GatsbyVersionWrapperDisplayed => VersionWrapper.Displayed;
        public bool GatsbyIntroductionContentDisplayed => IntroContent.Displayed;
        public bool GatsbyHomePageBreadcrumbLinkDisplayed => HomePageBreadCrumb.Displayed;
    }
}
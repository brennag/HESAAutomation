using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CMPTestAutomation.PageObjects
{
    public class GReleaseSchedulePage : BasePageObject
    {
        public GReleaseSchedulePage (IWebDriver driver)
        {
            Url = "https://hesacodingmanualdev.z33.web.core.windows.net/releaseSchedule/";
            Driver = driver;
        }

        private IWebElement ReleaseSchedulePageHeader => Driver.FindElement(By.XPath("/html/body/div/div[1]/div/main/div/h1"));
        private IWebElement VersionWrapper => Driver.FindElement(By.XPath("/html/body/div/div[1]/div/main/div/div[1]"));
        private IWebElement ScheduleReleaseCodingManualHeading => Driver.FindElement(By.XPath("/html/body/div/div[1]/div/main/div/div[3]"));
        private IWebElement ScheduledReleasesOfCodingManual => Driver.FindElement(By.XPath("/html/body/div/div[1]/div/main/div/div[4]/div/figure/table"));
        private IWebElement ScheduledReleaseDocumentsHeading => Driver.FindElement(By.XPath("/html/body/div/div[1]/div/main/div/div[5]"));
        private IWebElement ScheduledReleasesOfCodingManualDocuments => Driver.FindElement(By.XPath("/html/body/div/div[1]/div/main/div/div[6]/div/figure/table"));
        private IWebElement HomePageBreadCrumb => Driver.FindElement(By.LinkText("Go back to the homepage"));

        public bool BrowserIsOnGatsbyReleaseSchedulePage
        {
            get
            {
                //Wait until the main header of the home page is visible
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(d => ReleaseSchedulePageHeader.Displayed);

                return Driver.Url == Url;
            }
        }

        public bool GatsbyReleaseSchedulePageHeaderDisplayed => ReleaseSchedulePageHeader.Displayed;
        public bool GatsbyVersionWrapperDisplayed => VersionWrapper.Displayed;
        public bool GatsbyScheduleReleaseCodingManualHeadingDisplayed => ScheduleReleaseCodingManualHeading.Displayed;
        public bool GatsbyScheduledReleasesOfCodingManualDisplayed => ScheduledReleasesOfCodingManual.Displayed;
        public bool GatsbyScheduledReleaseDocumentsHeadingDisplayed => ScheduledReleaseDocumentsHeading.Displayed;
        public bool GatsbyScheduledReleasesOfCodingManualDocumentsDisplayed => ScheduledReleasesOfCodingManualDocuments.Displayed;
        public bool GatsbyHomePageBreadcrumbLinkDisplayed => HomePageBreadCrumb.Displayed;
    }
}
using System;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CMPTestAutomation.PageObjects
{
    public class SReleaseSchedulePage : BasePageObject
    {
        public SReleaseSchedulePage(IWebDriver driver)
        {
            Url = "https://coding-manual-pub-dev.azurewebsites.net/admin/plugins/content-manager/collectionType/application::release-schedule.release-schedule";
            Driver = driver;
        }
        private IWebElement PageHeader =>
            Driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/div[2]/div[1]/div/div/div[1]/div/h1"));
        private IWebElement AddNewReleaseScheduleButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/div[2]/div[1]/div/div/div[2]/div/button"));
        private IWebElement StrapiPublishButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[1]/div/div/div[2]/div/button[1]"));
        private IWebElement StrapiSaveButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[1]/div/div/div[2]/div/button[2]"));
        private IWebElement StrapiNavigateBackButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[1]"));
        private IWebElement StrapiReleaseScheduleTitle => Driver.FindElement(By.Id("Title"));
        private IWebElement StrapiReleaseScheduleVersion => Driver.FindElement(By.Id("Version"));
        private IWebElement StrapiReleaseScheduleDescription => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[2]/div[1]/div/div[2]/div/div/div[1]/div[2]/div[2]/div"));
        private IWebElement StrapiScheduleReleaseCodingManualHeading => Driver.FindElement(By.Id("ScheduleReleaseCodingManualHeading"));
        private IWebElement StrapiScheduledReleasesOfCodingManual => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[2]/div[1]/div/div[4]/div/div/div[1]/div[2]/div[2]/div"));
        private IWebElement StrapiScheduledReleaseDocumentsHeading => Driver.FindElement(By.Id("ScheduledReleaseDocumentsHeading"));
        private IWebElement StrapiScheduledReleasesOfCodingManualDocuments => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[2]/div[1]/div/div[6]/div/div/div[1]/div[2]/div[2]/div"));
        private IWebElement StrapiCodingManualId => Driver.FindElement(By.Id("CodingManualId"));
        private IWebElement DeleteEntry => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[2]/div[2]/div[6]/ul/li[2]/div/p"));
        private IWebElement DeleteEntryConfirmationYes => Driver.FindElement(By.XPath("/html/body/div[5]/div/div[1]/div/div/div[4]/button[2]/span"));


        #region VoidChecks

        public override void FillOutStrapiForm()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(d => PageHeader.Displayed);

            AddNewReleaseScheduleButton.Click();

            StrapiReleaseScheduleTitle.Clear(); StrapiReleaseScheduleTitle.SendKeys("TestReleaseScheduleTitle");
            StrapiReleaseScheduleVersion.Clear(); StrapiReleaseScheduleVersion.SendKeys("TestVersion");
            StrapiReleaseScheduleDescription.Clear(); StrapiReleaseScheduleDescription.SendKeys("TestDescription");
            StrapiScheduleReleaseCodingManualHeading.Clear(); StrapiScheduleReleaseCodingManualHeading.SendKeys("TestHeading");
            StrapiScheduledReleasesOfCodingManual.Clear(); StrapiScheduledReleasesOfCodingManual.SendKeys("TestScheduledRelease");
            StrapiScheduledReleaseDocumentsHeading.Clear(); StrapiScheduledReleaseDocumentsHeading.SendKeys("TestScheduledReleaseDocumentHeading");
            StrapiScheduledReleasesOfCodingManualDocuments.Clear(); StrapiScheduledReleasesOfCodingManualDocuments.SendKeys("TestDocuments");
            StrapiCodingManualId.Clear(); StrapiCodingManualId.SendKeys("C1234");

            wait.Until(d => StrapiSaveButton.Enabled);
            StrapiSaveButton.Click();

            wait.Until(d => StrapiPublishButton.Enabled);
            StrapiPublishButton.Click();

            StrapiNavigateBackButton.Click();

        }

        public void UpdateStrapiForm()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(d => StrapiReleaseScheduleTitle.Displayed);

            StrapiReleaseScheduleTitle.Clear(); StrapiReleaseScheduleTitle.SendKeys("TestReleaseScheduleTitle2");
            StrapiReleaseScheduleVersion.Clear(); StrapiReleaseScheduleVersion.SendKeys("TestVersion2");
            StrapiReleaseScheduleDescription.Clear(); StrapiReleaseScheduleDescription.SendKeys("TestDescription2");
            StrapiScheduleReleaseCodingManualHeading.Clear(); StrapiScheduleReleaseCodingManualHeading.SendKeys("TestHeading2");
            StrapiScheduledReleasesOfCodingManual.Clear(); StrapiScheduledReleasesOfCodingManual.SendKeys("TestScheduledRelease2");
            StrapiScheduledReleaseDocumentsHeading.Clear(); StrapiScheduledReleaseDocumentsHeading.SendKeys("TestScheduledReleaseDocumentHeading2");
            StrapiScheduledReleasesOfCodingManualDocuments.Clear(); StrapiScheduledReleasesOfCodingManualDocuments.SendKeys("TestDocuments2");
            StrapiCodingManualId.Clear(); StrapiCodingManualId.SendKeys("C12345");

            wait.Until(d => StrapiSaveButton.Enabled);
            StrapiSaveButton.Click();

            wait.Until(d => StrapiPublishButton.Enabled);
            StrapiPublishButton.Click();
        }
        public void DeleteRecord()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(d => StrapiReleaseScheduleTitle.Displayed);

            wait.Until(d => DeleteEntry.Displayed);
            DeleteEntry.Click();
            wait.Until(d => DeleteEntryConfirmationYes.Enabled);
            DeleteEntryConfirmationYes.Click();
        }


        #endregion
    }
}
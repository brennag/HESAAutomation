using System;
using System.Security.AccessControl;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CMPTestAutomation.PageObjects
{
    public class SDataDictionariesPage : BasePageObject
    {
        public SDataDictionariesPage(IWebDriver driver)
        {
            Url = "https://coding-manual-pub-dev.azurewebsites.net/admin/plugins/content-manager/collectionType/application::data-dictionary.data-dictionary";
            Driver = driver;
        }

        private IWebElement PageHeader =>
            Driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/div[2]/div[1]/div/div/div[1]/div/h1"));
        private IWebElement AddNewDataDictionaryButton => Driver.FindElement(
            By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/div[2]/div[1]/div/div/div[2]/div/button"));
        private IWebElement StrapiPublishButton => Driver.FindElement(By.XPath(
            "/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[1]/div/div/div[2]/div/button[1]"));
        private IWebElement StrapiSaveButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[1]/div/div/div[2]/div/button[2]"));
        private IWebElement StrapiNavigateBackButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[1]"));
        private IWebElement StrapiDDEntityName => Driver.FindElement(By.Id("EntityName"));
        private IWebElement StrapiDDEntityShortName => Driver.FindElement(By.Id("EntityShortName"));
        private IWebElement StrapiDDVersion => Driver.FindElement(By.Id("Version"));
        private IWebElement StrapiDDCollectionID => Driver.FindElement(By.Id("CollectionId"));
        private IWebElement StrapiDDApplicableTo => Driver.FindElement(By.Id("ApplicableTo"));
        private IWebElement StrapiDDCoverage => Driver.FindElement(By.Id("Coverage"));
        private IWebElement StrapiDDDescription => Driver.FindElement(By.Id("Description"));
        private IWebElement StrapiDDNotes => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[2]/div[1]/div/div[5]/div/div/div[1]/div[2]/div[2]/div"));
        private IWebElement StrapiDDReasonRequired => Driver.FindElement(By.Id("ReasonRequired"));
        private IWebElement DeleteEntry => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[2]/div[2]/div[6]/ul/li[2]/div/p"));
        private IWebElement DeleteEntryConfirmationYes => Driver.FindElement(By.XPath("/html/body/div[5]/div/div[1]/div/div/div[4]/button[2]/span"));


        #region VoidChecks

        public override void FillOutStrapiForm()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(d => PageHeader.Displayed);

            AddNewDataDictionaryButton.Click();

            StrapiDDEntityName.Clear(); StrapiDDEntityName.SendKeys("TestDDName");
            StrapiDDEntityShortName.Clear(); StrapiDDEntityShortName.SendKeys("TestShortName");
            StrapiDDVersion.Clear(); StrapiDDVersion.SendKeys("TestVersion");
            StrapiDDCollectionID.Clear(); StrapiDDCollectionID.SendKeys("C1234");
            StrapiDDApplicableTo.Clear(); StrapiDDApplicableTo.SendKeys("TestApplicableTo");
            StrapiDDCoverage.Clear(); StrapiDDCoverage.SendKeys("TestCoverage");
            StrapiDDDescription.Clear(); StrapiDDDescription.SendKeys("TestDescription");
            StrapiDDNotes.Clear(); StrapiDDNotes.SendKeys("TestNotes");
            StrapiDDReasonRequired.Clear(); StrapiDDReasonRequired.SendKeys("TestReasonRequired");
            
            wait.Until(d => StrapiSaveButton.Enabled);
            StrapiSaveButton.Click();

            wait.Until(d => StrapiPublishButton.Enabled);
            StrapiPublishButton.Click();

            StrapiNavigateBackButton.Click();

        }
        
        public void UpdateStrapiForm()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(d => StrapiDDEntityName.Displayed);

            StrapiDDEntityName.Clear(); StrapiDDEntityName.SendKeys("TestDDName2");
            StrapiDDEntityShortName.Clear(); StrapiDDEntityShortName.SendKeys("TestShortName2");
            StrapiDDVersion.Clear(); StrapiDDVersion.SendKeys("TestVersion2");
            StrapiDDCollectionID.Clear(); StrapiDDCollectionID.SendKeys("C12345");
            StrapiDDApplicableTo.Clear(); StrapiDDApplicableTo.SendKeys("TestApplicableTo2");
            StrapiDDCoverage.Clear(); StrapiDDCoverage.SendKeys("TestCoverage2");
            StrapiDDDescription.Clear(); StrapiDDDescription.SendKeys("TestDescription2");
            StrapiDDNotes.Clear(); StrapiDDNotes.SendKeys("TestNotes2");
            StrapiDDReasonRequired.Clear(); StrapiDDReasonRequired.SendKeys("TestReasonRequired2");

            wait.Until(d => StrapiSaveButton.Enabled);
            StrapiSaveButton.Click();

            wait.Until(d => StrapiPublishButton.Enabled);
            StrapiPublishButton.Click();
        }

        public void DeleteRecord()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(d => StrapiDDEntityName.Displayed);

            wait.Until(d => DeleteEntry.Displayed);
            DeleteEntry.Click();
            wait.Until(d => DeleteEntryConfirmationYes.Enabled);
            DeleteEntryConfirmationYes.Click();
        }

        #endregion

        public bool BrowserIsOnStrapiDataDictionariesPage
        {
            get
            {
                return Driver.Url == Url;
            }
        }
    }
}
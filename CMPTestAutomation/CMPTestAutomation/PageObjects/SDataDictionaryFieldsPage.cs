using System;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CMPTestAutomation.PageObjects
{
    public class SDataDictionaryFieldsPage : BasePageObject
    {
        public SDataDictionaryFieldsPage(IWebDriver driver)
        {
            Url = "https://coding-manual-pub-dev.azurewebsites.net/admin/plugins/content-manager/collectionType/application::field.field";
            Driver = driver;
        }
        private IWebElement PageHeader =>
            Driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/div[2]/div[1]/div/div/div[1]/div/h1"));
        private IWebElement StrapiPublishButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[1]/div/div/div[2]/div/button[1]"));
        private IWebElement StrapiSaveButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[1]/div/div/div[2]/div/button[2]"));
        private IWebElement StrapiNavigateBackButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[1]"));
        private IWebElement AddNewFieldButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/div[2]/div[1]/div/div/div[2]/div/button"));
        private IWebElement StrapiFieldName => Driver.FindElement(By.Id("Name"));
        private IWebElement StrapiFieldShortName => Driver.FindElement(By.Id("ShortName"));
        private IWebElement StrapiCollectionID => Driver.FindElement(By.Id("CollectionId"));
        private IWebElement StrapiVersion => Driver.FindElement(By.Id("Version"));
        private IWebElement StrapiDescription => Driver.FindElement(By.Id("Description"));
        private IWebElement StrapiParentEntity => Driver.FindElement(By.Id("ParentEntity"));
        private IWebElement StrapiApplicableTo => Driver.FindElement(By.Id("ApplicableTo"));
        private IWebElement StrapiCoverage => Driver.FindElement(By.Id("Coverage"));
        private IWebElement StrapiNotes => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[2]/div[1]/div/div[5]/div/div/div[1]/div[2]/div[2]/div"));
        private IWebElement StrapiReasonRequired => Driver.FindElement(By.Id("ReasonRequired"));
        private IWebElement DeleteEntry => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[2]/div[2]/div[6]/ul/li[2]/div/p"));
        private IWebElement DeleteEntryConfirmationYes => Driver.FindElement(By.XPath("/html/body/div[5]/div/div[1]/div/div/div[4]/button[2]/span"));

        #region VoidChecks

        public override void FillOutStrapiForm()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(d => PageHeader.Displayed);

            AddNewFieldButton.Click();

            StrapiFieldName.Clear(); StrapiFieldName.SendKeys("TestFieldName");
            StrapiFieldShortName.Clear(); StrapiFieldShortName.SendKeys("TestShortName");
            StrapiVersion.Clear(); StrapiVersion.SendKeys("TestVersion");
            StrapiCollectionID.Clear(); StrapiCollectionID.SendKeys("C1234");
            StrapiApplicableTo.Clear(); StrapiApplicableTo.SendKeys("TestApplicableTo");
            StrapiCoverage.Clear(); StrapiCoverage.SendKeys("TestCoverage");
            StrapiDescription.Clear(); StrapiDescription.SendKeys("TestDescription");
            StrapiParentEntity.Clear(); StrapiParentEntity.SendKeys("TestParentEntity");
            StrapiNotes.Clear(); StrapiNotes.SendKeys("TestNotes");
            StrapiReasonRequired.Clear(); StrapiReasonRequired.SendKeys("TestReasonRequired");

            wait.Until(d => StrapiSaveButton.Enabled);
            StrapiSaveButton.Click();

            wait.Until(d => StrapiPublishButton.Enabled);
            StrapiPublishButton.Click();

            StrapiNavigateBackButton.Click();
        }

        public void UpdateStrapiForm()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(d => StrapiFieldName.Displayed);

            StrapiFieldName.Clear(); StrapiFieldName.SendKeys("TestFieldName2");
            StrapiFieldShortName.Clear(); StrapiFieldShortName.SendKeys("TestShortName2");
            StrapiVersion.Clear(); StrapiVersion.SendKeys("TestVersion2");
            StrapiCollectionID.Clear(); StrapiCollectionID.SendKeys("C12345");
            StrapiApplicableTo.Clear(); StrapiApplicableTo.SendKeys("TestApplicableTo2");
            StrapiCoverage.Clear(); StrapiCoverage.SendKeys("TestCoverage2");
            StrapiDescription.Clear(); StrapiDescription.SendKeys("TestDescription2");
            StrapiParentEntity.Clear(); StrapiParentEntity.SendKeys("TestParentEntity2");
            StrapiNotes.Clear(); StrapiNotes.SendKeys("TestNotes2");
            StrapiReasonRequired.Clear(); StrapiReasonRequired.SendKeys("TestReasonRequired2");

            wait.Until(d => StrapiSaveButton.Enabled);
            StrapiSaveButton.Click();

            wait.Until(d => StrapiPublishButton.Enabled);
            StrapiPublishButton.Click();
        }

        public void DeleteRecord()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(d => StrapiFieldName.Displayed);

            wait.Until(d => DeleteEntry.Displayed);
            DeleteEntry.Click();
            wait.Until(d => DeleteEntryConfirmationYes.Enabled);
            DeleteEntryConfirmationYes.Click();
        }

        #endregion
    }
}
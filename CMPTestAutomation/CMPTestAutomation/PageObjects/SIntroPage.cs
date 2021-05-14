using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CMPTestAutomation.PageObjects
{
    public class SIntroPage : BasePageObject
    {
        public SIntroPage(IWebDriver driver)
        {
            Url = "https://coding-manual-pub-dev.azurewebsites.net/admin/plugins/content-manager/singleType/application::introduction.introduction";
            Driver = driver;
        }
        private IWebElement PageHeader =>
            Driver.FindElement(
                By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[1]/div/div/div[1]/div/h1"));
        private IWebElement StrapiUnPublishButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[1]/div/div/div[2]/div/button[1]"));
        private IWebElement StrapiUnpublishConfirmationButton => Driver.FindElement(By.XPath("/html/body/div[5]/div/div[1]/div/div/div[4]/button[2]/span"));
        private IWebElement StrapiSaveButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[1]/div/div/div[2]/div/button[2]"));
        private IWebElement StrapiIntroductionVersion => Driver.FindElement(By.Id("Version"));

        #region VoidChecks

        public override void FillOutStrapiForm()
        {

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(d => PageHeader.Displayed);

            StrapiIntroductionVersion.Clear(); StrapiIntroductionVersion.SendKeys(new Random().Next(1,20000000).ToString());
            
            wait.Until(d => StrapiSaveButton.Enabled);
            StrapiSaveButton.Click();

            wait.Until(d => StrapiUnPublishButton.Enabled);
            StrapiUnPublishButton.Click();

            wait.Until(d => StrapiUnpublishConfirmationButton.Enabled);
            StrapiUnpublishConfirmationButton.Click();

            wait.Until(d => PageHeader.Displayed);
            var button = Driver.FindElement(By.XPath(
                "/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[1]/div/div/div[2]/div/button[1]"));
            wait.Until(d => button.Enabled);
            button.Click();

        }
        #endregion
    }
}
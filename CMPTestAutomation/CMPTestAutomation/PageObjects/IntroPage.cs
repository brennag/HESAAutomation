using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace CMPTestAutomation.PageObjects
{
    public class IntroPage : BasePageObject
    {
        public IntroPage(IWebDriver driver)
        {
            Url = "https://coding-manual-pub-dev.azurewebsites.net/admin/plugins/content-manager/singleType/application::introduction.introduction";
            Driver = driver;
        }

        private IWebElement PageHeader =>
            Driver.FindElement(By.XPath(
                "/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[1]/div/div/div[1]/div/h1"));
        private IWebElement TitleField => Driver.FindElement(By.Id("Title"));
        private IWebElement ContentField => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[2]/div[1]/div/div[2]/div/div/div[1]/div[2]/div[2]/div"));
        private IWebElement VersionField => Driver.FindElement(By.Id("Version"));
        private IWebElement SaveButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[1]/div/div/div[2]/div/button[2]"));
        private IWebElement PublishButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[2]/div[1]/div/div/div[2]/div/button[1]"));
        private IWebElement NavigateBack => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[3]/div[2]/div/form/div[1]"));

        #region VoidChecks

        public void UpdateForm()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => PageHeader.Displayed);
            TitleField.Clear(); TitleField.SendKeys("TestName");
            ContentField.Clear(); ContentField.SendKeys("TestShortName");
            VersionField.Clear(); VersionField.SendKeys("TestVersion");

            wait.Until(d => SaveButton.Enabled);
            SaveButton.Click();

            wait.Until(d => PublishButton.Enabled);
            PublishButton.Click();

            wait.Until(d => NavigateBack.Enabled);
            NavigateBack.Click();
        }

        #endregion
    }
}

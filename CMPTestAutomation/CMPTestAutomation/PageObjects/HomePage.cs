using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CMPTestAutomation.PageObjects
{
    public class HomePage : BasePageObject
    {
        public HomePage(IWebDriver driver)
        {
            Url = "https://coding-manual-pub-dev.azurewebsites.net/admin/";
            Driver = driver;
        }

        private IWebElement Header => Driver.FindElement(By.Id("mainHeader"));
        private IWebElement UserDropDownMenu => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div[1]/div/button"));
        private IWebElement LogoutButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div[1]/div/div/button[2]"));
        public void Logout()
        {
            UserDropDownMenu.Click();
            LogoutButton.Click();
        }
        public bool BrowserIsOnHomePage
        {
            get
            {
                //Wait until the main header of the home page is visible
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(d => Header.Displayed);

                return Driver.Url == Url;
            }
        }
    }
}
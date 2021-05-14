using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CMPTestAutomation.PageObjects
{
    public class LoginPage : BasePageObject

    {
        public LoginPage(IWebDriver driver)
        {
            Url = "https://coding-manual-pub-dev.azurewebsites.net/admin/auth/login";
            Driver = driver;
        }
        private IWebElement EmailField => Driver.FindElement(By.Id("email"));
        private IWebElement PasswordField => Driver.FindElement(By.Id("password"));
        // Not currently used, so commenting out
        // private IWebElement RememberMeCheckBox => Driver.FindElement(By.Id("rememberMe"));
        // private IWebElement ForgotPasswordLink => Driver.FindElement(By.LinkText("Forgot your password?"));
        private IWebElement LoginButton => Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div[2]/section[2]/div/div/form/div[4]/button"));//TODO find a better selector for this element

        #region VoidChecks
        public void Login(string Username,string Password)
        {
            //Wait for the page to load
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => EmailField.Displayed);

            //Enter username and password, then click Login/Submit button
            EmailField.SendKeys(Username);
            PasswordField.SendKeys(Password);
            LoginButton.Click();
        }
        #endregion

        #region BoolChecks
        public bool BrowserIsOnLoginPage
        {
            get
            {
                //Wait until the main header of the login page is visible
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(d => EmailField.Displayed);

                return Driver.Url == Url;
            }
        }
        #endregion
    }
}

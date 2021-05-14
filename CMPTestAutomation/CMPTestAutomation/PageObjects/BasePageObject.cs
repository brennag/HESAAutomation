using OpenQA.Selenium;

namespace CMPTestAutomation.PageObjects
{
    public abstract class BasePageObject
    {
        public string Url;
        public IWebDriver Driver;
        public void Navigate()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public virtual void FillOutStrapiForm()
        {

        }

        public bool IsOnCorrectPage()
        {
            return Driver.Url == Url;
        }
    }
}

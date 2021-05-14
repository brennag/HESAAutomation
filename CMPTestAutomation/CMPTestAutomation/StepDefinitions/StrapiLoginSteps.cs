using CMPTestAutomation.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static CMPTestAutomation.PageObjectFactory;

namespace CMPTestAutomation.StepDefinitions
{
    [Binding]
    public class StrapiLoginSteps
    {
        private static readonly CmpTestConfiguration Config = CMPTestAutomation.Configuration.GetApplicationConfiguration();

        [BeforeFeature("Login")]
        public static void BeforeFeatureLogin()
        {
            StrapiLoginPage.Navigate();
            StrapiLoginPage.Login("cmp_team_sa@hesa.ac.uk", Config.AdminAccountPassword);
        }
        [AfterFeature("Login")]
        public static void AfterFeatureLogin()
        {
            StrapiHomePage.Logout();
        }
        [Given(@"I am on the (.*) page")]
        [When(@"I am on the (.*) page")]
        public void GivenIAmOnThePage(string pageName)
        {
            switch (pageName)
            {
                case "Login":
                {
                    StrapiLoginPage.Navigate();
                    var result = StrapiLoginPage.BrowserIsOnLoginPage;
                    Assert.True(result, "Was not taken to Strapi login page");
                    break;
                }
                case "Home":
                {
                    StrapiHomePage.Navigate();
                    var result = StrapiHomePage.BrowserIsOnHomePage;
                    Assert.True(result, "Was not taken to Strapi homepage");
                    break;
                }
                case "Strapi Data Dictionaries":
                {
                    StrapiDataDictionariesPage.Navigate();
                    Assert.True(StrapiDataDictionariesPage.IsOnCorrectPage(), "Was not taken to Data Dictionary page");
                    }
                    break;
                case "Strapi Data Dictionary Entities":
                {
                    StrapiDataDictionaryEntitiesPage.Navigate();
                    Assert.True(StrapiDataDictionaryEntitiesPage.IsOnCorrectPage(), "Was not taken to Data Dictionary Entities page");
                    }
                    break;
                case "Strapi Data Dictionary Fields":
                {
                    StrapiDataDictionaryFieldsPage.Navigate();
                    Assert.True(StrapiDataDictionaryFieldsPage.IsOnCorrectPage(), "Was not taken to Data Dictionary Fields page");
                    }
                    break;
                case "Strapi Intro":
                {
                    StrapiIntroPage.Navigate();
                    Assert.True(StrapiIntroPage.IsOnCorrectPage(), "Was not taken to Strapi Intro page");
                    }
                    break;
                case "Strapi Release Schedule":
                {
                    StrapiReleaseSchedulePage.Navigate();
                    Assert.True(StrapiReleaseSchedulePage.IsOnCorrectPage(), "Was not taken to Strapi Release Schedule page");
                    }
                    break;
            }
        }
        
        [When(@"I login as an (.*)")]

        public void WhenILogin(string UserRole)

        {
            if (UserRole == "Administrator")
            {
                StrapiLoginPage.Login("cmp_team_sa@hesa.ac.uk",Config.AdminAccountPassword);
            }
            if (UserRole == "Author")
            {
                StrapiLoginPage.Login("gary.brennan@gmail.com", Config.AuthorAccountPassword);
            }
            if (UserRole == "Editor")
            {
                StrapiLoginPage.Login("gary.brennan@hesa.ac.uk", Config.EditorAccountPassword);
            }
        }
        
        [Then(@"The Home page is presented with relevant Admin options")]
        public void ThenTheAdminHomePageIsPresented()
        {
            var result = StrapiHomePage.BrowserIsOnHomePage;
            Assert.True(result, "Was not taken to Strapi homepage");
            //ToDo => Add asserts for checking Admin only elements visible
        }

        [Then(@"The Home page is presented with relevant Author options")]
        public void ThenTheAuthorHomePageIsPresented()
        {
            var result = StrapiHomePage.BrowserIsOnHomePage;
            Assert.True(result, "Was not taken to Strapi homepage");
            //ToDo => Add asserts for checking Admin only elements visible
        }

        [Then(@"The Home page is presented with relevant Editor options")]
        public void ThenTheEditorHomePageIsPresented()
        {
            var result = StrapiHomePage.BrowserIsOnHomePage;
            Assert.True(result, "Was not taken to Strapi homepage");
            //ToDo => Add asserts for checking Admin only elements visible
        }

        [Then(@"I log out")]
        [When(@"I log out")]
        public void ThenILogOut()
        {
            StrapiHomePage.Logout();
        }

    }
}

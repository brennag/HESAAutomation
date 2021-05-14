using NUnit.Framework;
using TechTalk.SpecFlow;
using static CMPTestAutomation.PageObjectFactory;

namespace CMPTestAutomation.StepDefinitions
{
    [Binding]
    public class NavigateGatsbyPagesSteps
    {
        [When(@"I select the Gatsby Introduction page link")]
        public void WhenISelectTheGatsbyIntroductionPageLink()
        {
            GatsbyIntroPage.Navigate();
        }
        
        [When(@"I select the Gatsby Release Schedule page link")]
        public void WhenISelectTheGatsbyReleaseSchedulePageLink()
        {
            GatsbyReleaseSchedulePage.Navigate();
        }

        [When(@"I select the Gatsby Data Dictionary page link")]
        public void WhenISelectTheGatsbyDataDictionaryPageLink()
        {
            GatsbyDataDictionaryPage.Navigate();
        }

        [Then(@"I am taken to the Gatsby Introduction page")]
        public void ThenIAmTakenToTheGatsbyIntroductionPage()
        {
            Assert.True(GatsbyIntroPage.BrowserIsOnGatsbyIntroPage, "Was not taken to Gatsby Intro page");
            Assert.True(GatsbyIntroPage.GatsbyIntroPageHeaderDisplayed, "Introduction Page Header is not displayed");
            Assert.True(GatsbyIntroPage.GatsbyVersionWrapperDisplayed, "Version wrapper not displayed ");
            Assert.True(GatsbyIntroPage.GatsbyIntroductionContentDisplayed, "Introduction Content is not displayed");
            Assert.True(GatsbyIntroPage.GatsbyHomePageBreadcrumbLinkDisplayed, "HomePage Breadcrumb is not present");
        }
        
        [Then(@"I am taken to the Gatsby Release Schedule page")]
        public void ThenIAmTakenToTheGatsbyReleaseSchedulePage()
        {
            Assert.True(GatsbyReleaseSchedulePage.BrowserIsOnGatsbyReleaseSchedulePage, "Was not taken to Gatsby Release Schedule Page");
            Assert.True(GatsbyReleaseSchedulePage.GatsbyReleaseSchedulePageHeaderDisplayed, "Gatsby Release Schedule Page Header is not displayed");
            Assert.True(GatsbyReleaseSchedulePage.GatsbyVersionWrapperDisplayed, "Release Schedule Page Version Wrapper is not displayed ");
            Assert.True(GatsbyReleaseSchedulePage.GatsbyScheduleReleaseCodingManualHeadingDisplayed, "Schedule Release Coding Manual Heading is not displayed");
            Assert.True(GatsbyReleaseSchedulePage.GatsbyScheduledReleasesOfCodingManualDisplayed, "Gatsby Scheduled Releases Of Coding Manual is not displayed");
            Assert.True(GatsbyReleaseSchedulePage.GatsbyScheduledReleaseDocumentsHeadingDisplayed, "Gatsby Scheduled Release Documents Heading is not displayed");
            Assert.True(GatsbyReleaseSchedulePage.GatsbyScheduledReleasesOfCodingManualDocumentsDisplayed, "Gatsby Scheduled Releases Of Coding Manual Documents is not displayed");
            Assert.True(GatsbyReleaseSchedulePage.GatsbyHomePageBreadcrumbLinkDisplayed, "HomePage Breadcrumb is not present");
        }

        [Then(@"I am taken to the Gatsby Data Dictionary page")]
        public void ThenIAmTakenToTheGatsbyDataDictionaryPage()
        {
            Assert.True(GatsbyDataDictionaryPage.BrowserIsOnGatsbyDataDictionaryPage, "Was not taken to Gatsby Data Dictionary Page");
            Assert.True(GatsbyDataDictionaryPage.GatsbyDataDictionaryHeaderDisplayed, "Gatsby Data Dictionary Page Header is not displayed");
            Assert.True(GatsbyDataDictionaryPage.GatsbyHomePageBreadcrumbLinkDisplayed, "HomePage Breadcrumb is not present");
        }
    }
}

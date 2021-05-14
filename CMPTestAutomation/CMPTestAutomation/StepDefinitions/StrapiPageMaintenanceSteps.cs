using CMPTestAutomation.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static CMPTestAutomation.PageObjectFactory;

namespace CMPTestAutomation.StepDefinitions
{
    [Binding]
    public class StrapiPageMaintenanceSteps
    {

        private BasePageObject _currentPage;

        private string _pageName;

        [When(@"I publish changes to the (.*) page")]
        public void WhenIPublishChangesToThePage(string PageName)
        {
            SetPageObject(PageName);
            _pageName = PageName;
            _currentPage.FillOutStrapiForm();
        }
        
        [Then(@"the page will be updated")]
        public void ThenThePageWillBeUpdated()
        {
            Assert.True(_currentPage.IsOnCorrectPage(), $"Was not taken to {_pageName} page");
        }

        private void SetPageObject(string PageName)
        {
            switch (PageName)
            {
                case "Strapi Data Dictionaries":
                    _currentPage = StrapiDataDictionariesPage;
                    break;
                case "Strapi Data Dictionary Entities":
                    _currentPage = StrapiDataDictionaryEntitiesPage;
                    break;
                case "Strapi Data Dictionary Fields":
                    _currentPage = StrapiDataDictionaryFieldsPage;
                    break;
                case "Strapi Intro":
                    _currentPage = StrapiIntroPage;
                    break;
                case "Strapi Release Schedule":
                    _currentPage = StrapiReleaseSchedulePage;
                    break;
            }
        }
    }
}

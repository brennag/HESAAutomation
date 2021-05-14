Feature: NavigateGatsbyPages
	As a user
	I want to navigate the Gatsby pages
	So that I see can ensure the content is correct

Scenario:1 Navigate to Introduction page
	Given I am on the Gatsby Home page
	When I select the Gatsby Introduction page link
	Then I am taken to the Gatsby Introduction page

Scenario:3 Navigate to Release Schedule page
	Given I am on the Gatsby Home page
	When I select the Gatsby Release Schedule page link
	Then I am taken to the Gatsby Release Schedule page

Scenario:4 Navigate to Data Dictionary page
	Given I am on the Gatsby Home page
	When I select the Gatsby Data Dictionary page link
	Then I am taken to the Gatsby Data Dictionary page
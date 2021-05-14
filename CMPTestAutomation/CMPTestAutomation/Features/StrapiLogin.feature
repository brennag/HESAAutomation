Feature: StrapiLogin
	As a user 
	I want to log into Strapi and log out of Strapi
	So that I can administer the CMS elements of a page and then close my session

Scenario: Log in to and out of Strapi as Administrator
	Given I am on the Login page
	When I login as an Administrator
	Then The Home page is presented with relevant Admin options
	And I log out

Scenario: Log in to and out of Strapi as an Author 
	Given I am on the Login page
	When I login as an Author
	Then The Home page is presented with relevant Author options
	And I log out

Scenario: Login to and out of Strapi as an Editor
	Given I am on the Login page
	When I login as an Editor
	Then The Home page is presented with relevant Editor options
	And I log out

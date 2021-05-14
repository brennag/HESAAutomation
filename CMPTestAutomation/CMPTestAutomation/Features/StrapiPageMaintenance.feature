@Login

Feature: StrapiPageMaintenance
	As a user
	I want to maintain the Strapi pages
	So that the latest information is published

Scenario Outline: Update Data Dictionaries page
	Given I am on the <PageName> page
	When I publish changes to the <PageName> page
	Then the page will be updated
	Examples:
	| PageName                        |
	| Strapi Data Dictionaries        |
	| Strapi Data Dictionary Entities |
	| Strapi Data Dictionary Fields   |
	| Strapi Release Schedule         |


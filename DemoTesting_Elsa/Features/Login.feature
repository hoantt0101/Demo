@ui
Feature: Login

A short summary of the feature

Scenario: Valid login
	Given I go to elsa speech analyzer
	When I click sign in button
	Then I see sign in page is displayed correctly
	When I input email '<validEmail>'
	* I input password '<validPwd>'
	* I click Login btn
	Then I see welcome page is displayed

@login
Examples: 
| validEmail              | validPwd         |
| elsaTesting@yopmail.com | ZonePassword123! |
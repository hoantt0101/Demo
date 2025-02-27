@ui
Feature: CreateNewAcc

A short summary of the feature

Scenario: Create valid account
	Given I go to elsa speech analyzer
	When I click create new account button
	Then I see sign up page is displayed correctly
	When I click create new account btn
	Then I see Sign up form is displayed
	When I fill valid account details
	* I click create an account btn
	Then I see welcome page is displayed

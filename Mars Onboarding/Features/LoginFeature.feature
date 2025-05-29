Feature: LoginFeature

As a user I would like to log in to the application to access my restricted content

Background:
	
Given I am on the login page

@tag1
Scenario: Perform a successful login
	Given I enter a valid username and password
	Then I should be redirected to the home page

Scenario: Perform login with invalid credentials	
	Given I enter an invalid username and password
	Then I should see an error message indicating invalid credentials
	When I click on the send verification email button
	Then I should see email verification failed message

Scenario: Perform login with invalid username
	Given I enter an invalid username and a valid password
	Then I should see error message indicating invalid credentials
	When I click on the send verification email button
	Then I should see email verification failed message

Scenario: Perform login with invalid password
	Given I enter a valid username and an invalid password
	Then I should see error message indicating invalid credentials
	When I click on the send verification email button
	Then I should see an email verification sent message


Scenario: Perform login with empty username and password
	Given I enter an empty username and password
	Then I should see please enter a valid email address message
	And I should see  password must be at least 6 characters message

Scenario: Perform login with empty username
	Given I enter an empty username and a valid password
	Then I should see please enter a valid email address message

Scenario: Perform login with empty password
	Given I enter a valid username and an empty password
	Then I should see  password must be at least 6 characters message



Feature: Languages and Skills

As a user I would like to add languages and skills to my profile so that 
I can showcase my abilities to potential employers.
@tag1
Scenario: Add a new language to the profile
	Given I logged in successfully
	When I added a new language to my profile
	Then I should see the new language in my profile
@tag1
Scenario: Edit an existing language in the profile
	Given I logged in successfully
	When I edited an existing language in my profile
	Then I should see the updated language in my profile
@tag1
Scenario: Delete a language from the profile
	Given I logged in successfully
	When I deleted a language from my profile
	Then I should not see the deleted language in my profile
@tag1	
Scenario: Add a new skill to the profile
	Given I logged in successfully
	When I added a new skill to my profile
	Then I should see the new skill in my profile
@tag1
Scenario: Edit an existing skill in the profile
	Given I logged in successfully
	When I edited an existing skill in my profile
	Then I should see the updated skill in my profile
@tag1
Scenario: Delete a skill from the profile		
	Given I logged in successfully
	When I deleted a skill from my profile
	Then I should not see the deleted skill in my profile

Scenario: Add a new language with filling only language and not the level
Given I logged in successfully 
	When I added a new language to my profile with only the language field filled
	Then An error message should be displayed indicating that the  language level is required

Scenario: Add a new language with filling only level and not the language
	Given I logged in successfully
	When I added a new language to my profile with only the level field filled
	Then An error message should be displayed indicating that the language is required

Scenario: Add a new language with empty fields
	Given I logged in successfully
	When I added a new language to my profile with empty fields
	Then An error message should be displayed indicating that both fields are required

Scenario: Add a new skill with filling only skill and not the level
	Given I logged in successfully
	When I added a new skill to my profile with only the skill field filled
	Then An error message should be displayed indicating that the level required

Scenario: Add a new skill with filling only level and not the skill
	Given I logged in successfully
	When I added a new skill to my profile with only the level field filled
	Then An error message should be displayed indicating that the skill is required

Scenario: Add a new skill with empty fields
	Given I logged in successfully
	When I added a new skill to my profile with empty fields
	Then An error message should be displayed indicating that both the fields are required
	
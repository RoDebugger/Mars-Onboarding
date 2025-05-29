Feature: LanguagesFeature 

As a user I would like to add languages to my profile so that 
I can showcase my abilities to potential employers.

@AddLang
Scenario Outline: Add a new language to the profile
	Given I logged in successfully
	When I added a new '<language>' to my profile
	Then I should see the new '<language>' in my profile
Examples:
	| language |
	| English  |  
	| French   |
	| German   |
	| Italian  |

	
@EditLang
Scenario Outline: Edit an existing language in the profile
	Given I logged in successfully
	When I edited an existing '<language>' and '<level>' in my profile
	Then I should see the updated '<language>' and '<level>' in my profile
 Examples: 
	| language | level |
	| English-edited | Expert |
	| French-edited  | Intermediate |
	| German-edited  | Expert       |
	| Italian-edited | Intermediate |

@DeleteLang
Scenario Outline: Delete a language from the profile
	Given I logged in successfully
	When I deleted a '<language>' from my profile
	Then I should not see the deleted '<language>' in my profile
	Examples: 
	| language |
	| English  |
	| French   |
	| German   |
	| Italian  |


Scenario: Add a new language with filling only language and not the level
Given I logged in successfully 
	When I added a new language to my profile with only the language field filled
	Then An error message should be displayed indicating that the level is required

Scenario: Add a new language with filling only level and not the language
	Given I logged in successfully
	When I added a new language to my profile with only the level field filled
	Then An error message should be displayed indicating that the language is required

	Scenario: Add a new language with empty fields
	Given I logged in successfully
	When I added a new language to my profile with empty fields
	Then An error message should be displayed indicating that both fields are required
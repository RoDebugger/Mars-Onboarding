Feature: SkillsFeature

As a user I would like to add skills to my profile so that 
I can showcase my abilities to potential employers.

	@AddSkill
Scenario Outline: Add a new skill to the profile
	Given I logged in successfully
	When I added a new '<skill>' to my list of skills
	Then I should see the new '<skill>' in the list of skills
Examples:
	| skill      |
	| Java       |
	| Python     |
	| JavaScript |
	| C#         |
@EditSkill
Scenario Outline: Edit an existing skill in the profile
	Given I logged in successfully
	When I edited an existing '<skill>' and '<level>' in my profile
	Then I should see the updated '<skill>' and '<level>' in my profile
	Examples: 
	| skill             | level        |
	| Testing       | Expert       |
	| Coding     | Intermediate |
	| Analysing | Expert       |
	| Writing         | Intermediate |

Scenario Outline: Delete a skill from the profile		
	Given I logged in successfully
	When I deleted a '<skill>' from my profile
	Then I should not see the deleted '<skill>' in my profile

	Examples:
	| skill |
	| Java  |
	| Python |
	| JavaScript |
	| C#         |

	

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

@SameSkill
Scenario Outline: As a user I should not be able to add the same skill twice with different levels
	Given I logged in successfully
	When I added a new '<skill>' to my profile with level '<level>'
	Then I should see a "<expectedMessage>" message
	Examples: 
	| skill | level  | expectedMessage                    |
	| Java  | Expert | Java has been added to your skills |
	| Java  | Intermediate | Duplicated data |
			
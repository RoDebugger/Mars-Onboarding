using System;
using Mars_Onboarding.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Mars_Onboarding.StepDefinitions
{
    [Binding]
    public class SkillsFeatureStepDefinitions
    {

        private IWebDriver driver;
        private ScenarioContext _scenarioContext;
        private LoginPage loginPage;
        private SkillsPage skillsPage;
        public SkillsFeatureStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext, LoginPage loginPage, SkillsPage skillsPage)
        {
            this.driver = driver;
            _scenarioContext = scenarioContext;
            this.loginPage = loginPage;
            this.skillsPage = skillsPage;
        }
      
      


        [When("I added a new {string} to my list of skills")]
        public void WhenIAddedANewToMyListOfSkills(string skill)
        {
            var skillsPage = new SkillsPage();
            skillsPage.AddSkill(driver, skill);
            _scenarioContext["AddedSkill"] = skill;
        }

        [Then("I should see the new {string} in the list of skills")]
        public void ThenIShouldSeeTheNewInTheListOfSkills(string skill)
        {
           
            skillsPage.GetSkill(driver,skill);
         
        }
        

        [When("I edited an existing {string} and {string} in my profile")]
        public void WhenIEditedAnExistingAndInMyProfile(string skill, string level)
        {
            var skillsPage = new SkillsPage();
            skillsPage.AddSkill(driver, skill);
            skillsPage.EditSkill(driver, skill, level);
            _scenarioContext["EditedSkill"] = skill; // Store the edited skill for cleanup

        }

        [Then("I should see the updated {string} and {string} in my profile")]
        public void ThenIShouldSeeTheUpdatedAndInMyProfile(string skill, string level)
        {
            skillsPage.GetSkill(driver, skill);
            skillsPage.GetUpdatedSkillLevel(driver,skill, level);
        }
       

        [When("I deleted a {string} from my profile")]
        public void WhenIDeletedAFromMyProfile(string skill)
        {
            skillsPage.AddSkill(driver, skill);
            skillsPage.DeleteSkill(driver, skill);
        }

        [Then("I should not see the deleted {string} in my profile")]
        public void ThenIShouldNotSeeTheDeletedInMyProfile(string skill)
        {
            skillsPage.VerifySkillDeleted(driver, skill);
        }
        [When("I added a new skill to my profile with only the skill field filled")]
        public void WhenIAddedANewSkillToMyProfileWithOnlyTheSkillFieldFilled()
        {

            skillsPage.AddSkillWithEmptyLevel(driver);


        }
        [Then("An error message should be displayed indicating that the level required")]
        public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatTheLevelRequired()
        {

            skillsPage.GetEmptyFieldsError(driver);
            IWebElement errorMessage = driver.FindElement(By.XPath("/html/body/div[1]"));
           Assert.That(errorMessage.Text.Contains("Please enter skill and experience level"), Is.True, "Test Failed: Error message not displayed as expected.");
        }

        [When("I added a new skill to my profile with only the level field filled")]
        public void WhenIAddedANewSkillToMyProfileWithOnlyTheLevelFieldFilled()
        {

            skillsPage.AddSkllWithEmptySkill(driver);

        }
        [Then("An error message should be displayed indicating that the skill is required")]
        public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatTheSkillIsRequired()
        {

            skillsPage.GetEmptyFieldsError(driver);
            IWebElement errorMessage = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(errorMessage.Text.Contains("Please enter skill and experience level"), Is.True, "Test Failed: Error message not displayed as expected.");
        }

        [When("I added a new skill to my profile with empty fields")]
        public void WhenIAddedANewSkillToMyProfileWithEmptyFields()
        {

            skillsPage.AddSkillWithEmptyFields(driver);
        }
           
        
        [Then("An error message should be displayed indicating that both the fields are required")]
        public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatBothTheFieldsAreRequired()
        {

            skillsPage.GetEmptyFieldsError(driver);
            IWebElement errorMessage = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(errorMessage.Text.Contains("Please enter skill and experience level"), Is.True, "Test Failed: Error message not displayed as expected.");
        }




        [When("I added a new {string} to my profile with level {string}")]
        public void WhenIAddedANewToMyProfileWithLevel(string skill, string level)
        {
           skillsPage.AddSameSkillWithDifferentLevel(driver, skill, level);
        }

        [Then("I should see a {string} message")]
        public void ThenIShouldSeeAMessage(string message)
        {
            skillsPage.VerifyAddedSkill(driver, message);
            IWebElement webElement = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(webElement.Text.Contains(message), Is.True, "Test Failed: Message not displayed as expected.");

        }





    }
}

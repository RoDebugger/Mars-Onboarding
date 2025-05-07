using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Reqnroll;
using Mars_Onboarding.Pages;
using Mars_Onboarding.Support;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mars_Onboarding.StepDefinitions
{
    [Binding]
    public class LanguagesAndSkillsStepDefinitions : CommonDriver
    {
        public new static IWebDriver driver;
        public LanguagesAndSkillsStepDefinitions()
        {
            driver = new ChromeDriver();
        }


        [Given("I logged in successfully")]
        public void GivenILoggedInSuccessfully()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginActions(driver);
        }

        [When("I added a new language to my profile")]
        public void WhenIAddedANewLanguageToMyProfile()
        {
            LanguagesPage languagesPage = new LanguagesPage();
            languagesPage.AddLanguage(driver);
        }

        [Then("I should see the new language in my profile")]
        public void ThenIShouldSeeTheNewLanguageInMyProfile()
        {
            LanguagesPage languagesPage = new LanguagesPage();
            languagesPage.GetLanguage(driver);
        }

        [When("I edited an existing language in my profile")]
        public void WhenIEditedAnExistingLanguageInMyProfile()
        {
            LanguagesPage languagesPage = new LanguagesPage();
            languagesPage.EditLanguage(driver);
        }

        [Then("I should see the updated language in my profile")]
        public void ThenIShouldSeeTheUpdatedLanguageInMyProfile()
        {
            LanguagesPage languagesPage = new LanguagesPage();
            languagesPage.GetEditedLanguage(driver);
        }

        [When("I deleted a language from my profile")]
        public void WhenIDeletedALanguageFromMyProfile()
        {
            LanguagesPage languagesPage = new LanguagesPage();
            languagesPage.DeleteLanguage(driver);
        }

        [Then("I should not see the deleted language in my profile")]
        public void ThenIShouldNotSeeTheDeletedLanguageInMyProfile()
        {
            LanguagesPage languagesPage = new LanguagesPage();
            languagesPage.VerifyLanguageDeleted(driver);
        }

        [When("I added a new skill to my profile")]
        public void WhenIAddedANewSkillToMyProfile()
        {
            SkillsPage skillsPage = new SkillsPage();
            skillsPage.AddSkill(driver);
        }

        [Then("I should see the new skill in my profile")]
        public void ThenIShouldSeeTheNewSkillInMyProfile()
        {
            SkillsPage skillsPage = new SkillsPage();
            skillsPage.GetSkill(driver);
        }

        [When("I edited an existing skill in my profile")]
        public void WhenIEditedAnExistingSkillInMyProfile()
        {
            SkillsPage skillsPage = new SkillsPage();
            skillsPage.EditSkill(driver);
        }

        [Then("I should see the updated skill in my profile")]
        public void ThenIShouldSeeTheUpdatedSkillInMyProfile()
        {
            SkillsPage skillsPage = new SkillsPage();
            skillsPage.GetEditedSkill(driver);
        }

        [When("I deleted a skill from my profile")]
        public void WhenIDeletedASkillFromMyProfile()
        {
            SkillsPage skillsPage = new SkillsPage();
            skillsPage.DeleteSkill(driver);
        }

        [Then("I should not see the deleted skill in my profile")]
        public void ThenIShouldNotSeeTheDeletedSkillInMyProfile()
        {
            SkillsPage skillsPage = new SkillsPage();
            skillsPage.VerifySkillDeleted(driver);
        }

        [When("I added a new language to my profile with only the language field filled")]
        public void WhenIAddedANewLanguageToMyProfileWithOnlyTheLanguageFieldFilled()
        {
            LanguagesPage languagesPage = new LanguagesPage();
            languagesPage.AddLanguageWithEmptyLevel(driver);
        }

        [Then("An error message should be displayed indicating that the level is required")]
        public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatTheLanguageLevelIsRequired()
        {
            LanguagesPage languagesPage = new LanguagesPage();
            languagesPage.VerifyEmptyLangLevel(driver);
        }

        [When("I added a new language to my profile with only the level field filled")]
        public void WhenIAddedANewLanguageToMyProfileWithOnlyTheLevelFieldFilled()
        {
            LanguagesPage languagesPage = new LanguagesPage();
            languagesPage.AddLanguageWithEmptyField(driver);
        }

        [Then("An error message should be displayed indicating that the language is required")]
        public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatTheLanguageIsRequired()
        {
            LanguagesPage languagesPage = new LanguagesPage();
            languagesPage.VerifyEmptyLanguageField(driver);
        }

        [When("I added a new language to my profile with empty fields")]
        public void WhenIAddedANewLanguageToMyProfileWithEmptyFields()
        {
            LanguagesPage languagesPage = new LanguagesPage();
            languagesPage.AddLanguagewithBothEmptyFields(driver);
        }

        [Then("An error message should be displayed indicating that both fields are required")]
        public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatBothFieldsAreRequired()
        {
            LanguagesPage languagesPage = new LanguagesPage();
            languagesPage.VerifyBothEmptyFields(driver);
        }

        [When("I added a new skill to my profile with only the skill field filled")]
        public void WhenIAddedANewSkillToMyProfileWithOnlyTheSkillFieldFilled()
        {
            SkillsPage skillsPage = new SkillsPage();
            skillsPage.AddSkillWithEmptyLevel(driver);
            

        }
        [Then("An error message should be displayed indicating that the level required")]
        public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatTheLevelRequired()
        {
            SkillsPage skillsPage = new SkillsPage();
            skillsPage.VerifyEmptyLevelError(driver);
        }

        [When("I added a new skill to my profile with only the level field filled")]
        public void WhenIAddedANewSkillToMyProfileWithOnlyTheLevelFieldFilled()
        {
            SkillsPage skillsPage = new SkillsPage();
            skillsPage.AddSkllWithEmptySkill(driver);

        }
        [Then("An error message should be displayed indicating that the skill is required")]
        public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatTheSkillIsRequired()
        {
            SkillsPage skillsPage = new SkillsPage();
            skillsPage.VerifyEmptySkillError(driver);
        }

        [When("I added a new skill to my profile with empty fields")]
        public void WhenIAddedANewSkillToMyProfileWithEmptyFields()
        {
            SkillsPage skillsPage = new SkillsPage();
            skillsPage.AddSkillWithEmptyFields(driver);
        }
        [Then("An error message should be displayed indicating that both the fields are required")]
        public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatBothTheFieldsAreRequired()
        {
            SkillsPage skillsPage = new SkillsPage();
            skillsPage.VerifyErrorMessage(driver);
        }





    }
}

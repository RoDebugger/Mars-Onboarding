using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Reqnroll;
using Mars_Onboarding.Pages;
using static System.Runtime.InteropServices.JavaScript.JSType;
using NUnit.Framework;

namespace Mars_Onboarding.StepDefinitions
{
    [Binding]
    public class LanguagesFeatureStepDefinitions 
    {
        private IWebDriver driver;
        private ScenarioContext _scenarioContext;
        private LoginPage loginPage;
        private LanguagesPage languagesPage;
        public LanguagesFeatureStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext, LoginPage loginPage, LanguagesPage languagesPage)
        {
            this.driver = driver;
            _scenarioContext = scenarioContext;
            this.loginPage = loginPage;
            this.languagesPage = languagesPage;
        }
        

        [Given("I logged in successfully")]
        public void GivenILoggedInSuccessfully()
        {
            loginPage.NavigateToPage(driver);
            loginPage.LoginActions(driver);
        }
        [When("I added a new {string} to my profile")]
        public void WhenIAddedANewToMyProfile(string language)
        {
            var languagesPage = new LanguagesPage();
            languagesPage.AddLanguage(driver, language);
            _scenarioContext["AddedLanguage"] = language; // Store the added language for cleanup

        }

        [Then("I should see the new {string} in my profile")]
        public void ThenIShouldSeeTheNewInMyProfile(string language)
        {
            languagesPage.GetLanguage(driver, language);

        }

        
        [When("I edited an existing {string} and {string}in my profile")]
        public void WhenIEditedAnExistingAndInMyProfile(string language, string level )
        {

            var languagesPage = new LanguagesPage();
            languagesPage.AddLanguage(driver, language);
            languagesPage.EditLanguage(driver, language, level);

            _scenarioContext["EditedLanguage"] = language; // Store the edited language for cleanup
            
        }

        [Then("I should see the updated {string} and {string}in my profile")]
        public void ThenIShouldSeeTheUpdatedAndInMyProfile(string language, string level)
        {
            languagesPage.GetLanguage(driver, language);
            languagesPage.GetEditedLanguageLevel(driver, language, level);          
        }
       

        [When("I deleted a {string}from my profile")]
        public void WhenIDeletedAFromMyProfile(string language)
        {
            languagesPage.AddLanguage(driver, language);
            languagesPage.DeleteLanguage(driver, language);
        }

        [Then("I should not see the deleted {string}in my profile")]
        public void ThenIShouldNotSeeTheDeletedInMyProfile(string language)
        {
            languagesPage.VerifyLanguageDeleted(driver, language);
        }





        [When("I added a new language to my profile with only the language field filled")]
        public void WhenIAddedANewLanguageToMyProfileWithOnlyTheLanguageFieldFilled()
        {
            
            languagesPage.AddLanguageWithEmptyLevel(driver);
        }

        [Then("An error message should be displayed indicating that the level is required")]
        public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatTheLanguageLevelIsRequired()
        {
           
            languagesPage.GetEmptyFieldsError(driver);
            IWebElement errorMessage = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(errorMessage.Text == "Please enter language and level", Is.True, "Test Failed: Language level not empty.");
        }

        [When("I added a new language to my profile with only the level field filled")]
        public void WhenIAddedANewLanguageToMyProfileWithOnlyTheLevelFieldFilled()
        {
           
            languagesPage.AddLanguageWithEmptyField(driver);
        }

        [Then("An error message should be displayed indicating that the language is required")]
        public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatTheLanguageIsRequired()
        {
           
            languagesPage.GetEmptyFieldsError(driver);
            IWebElement errorMessage = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(errorMessage.Text == "Please enter language and level", Is.True, "Test Failed: Language field not empty.");
        }

        [When("I added a new language to my profile with empty fields")]
        public void WhenIAddedANewLanguageToMyProfileWithEmptyFields()
        {
            
            languagesPage.AddLanguagewithBothEmptyFields(driver);
        }

        [Then("An error message should be displayed indicating that both fields are required")]
        public void ThenAnErrorMessageShouldBeDisplayedIndicatingThatBothFieldsAreRequired()
        {
           
            languagesPage.GetEmptyFieldsError(driver);
            IWebElement errorMessage = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(errorMessage.Text == "Please enter language and level", Is.True, "Test Failed: Language and level fields not empty.");
        }
        [When("I added a new {string} and {string} two times")]
        public void WhenIAddedANewAndTwoTimes(string language, string level)
        {
           languagesPage.AddSameLanguage(driver, language, level);
        }

        [Then("I should see an {string} message")]
        public void ThenIShouldSeeAnMessage(string expectedMessage)
        {
            languagesPage.GetSameLanguageError(driver);
            IWebElement errorMessage = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(errorMessage.Text == expectedMessage, Is.True, $"Test Failed: Expected message '{expectedMessage}' but got '{errorMessage.Text}'.");
        }




    }
}

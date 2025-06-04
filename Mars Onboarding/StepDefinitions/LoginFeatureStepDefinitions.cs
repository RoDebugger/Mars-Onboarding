using System;
using Mars_Onboarding.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace Mars_Onboarding.StepDefinitions
{
    [Binding]
    public class LoginFeatureStepDefinitions
    {
            private IWebDriver driver;
        private LoginPage loginPage;

        public LoginFeatureStepDefinitions(IWebDriver driver)
            {
                this.driver = driver;
            this.loginPage = new LoginPage();
        }
           

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            loginPage.NavigateToPage(driver);
        }

        [Given("I enter a valid username and password")]
        public void GivenIEnterAValidUsernameAndPassword()
        {
            loginPage.LoginActions(driver);  
        }

        [Then("I should be redirected to the home page")]
        public void ThenIShouldBeRedirectedToTheHomePage()
        {
           loginPage.SuccessfulLogin(driver);
        }
        [Given("I enter an invalid username and password")]
        public void GivenIEnterAnInvalidUsernameAndPassword()
        {
            loginPage.InvalidLogin(driver);
        }

        [Then("I should see an error message indicating invalid credentials")]
        public void ThenIShouldSeeAnErrorMessageIndicatingInvalidCredentials()
        {
            loginPage.ErrorMessage(driver);
        }

        [When("I click on the send verification email button")]
        public void WhenIClickOnTheSendVerificationEmailButton()
        {
            loginPage.ErrorNotification(driver);
            loginPage.ClickVerifyButton(driver);
        }

        [Then("I should see email verification failed message")]
        public void ThenIShouldSeeEmailVerificationFailedMessage()
        {
            loginPage.VerifyEmailFailed(driver);
        }

        [Given("I enter an invalid username and a valid password")]
        public void GivenIEnterAnInvalidUsernameAndAValidPassword()
        {
            loginPage.IncorrectUsername(driver);
        }

        [Then("I should see error message indicating invalid credentials")]
        public void ThenIShouldSeeErrorMessageIndicatingInvalidCredentials()
        {
           loginPage.ErrorMessage(driver);
        }

        [Given("I enter a valid username and an invalid password")]
        public void GivenIEnterAValidUsernameAndAnInvalidPassword()
        {
            loginPage.IncorrectPassword(driver);
        }

        [Then("I should see an email verification sent message")]
        public void ThenIShouldSeeAnEmailVerificationSentMessage()
        {
            loginPage.VerifyEmailSuccess(driver);
        }



        [Given("I enter an empty username and password")]
        public void GivenIEnterAnEmptyUsernameAndPassword()
        {
           loginPage.EmptyFields(driver);
        }

        [Given("I enter an empty username and a valid password")]
        public void GivenIEnterAnEmptyUsernameAndAValidPassword()
        {
           loginPage.EmptyUsername(driver);
        }

        [Given("I enter a valid username and an empty password")]
        public void GivenIEnterAValidUsernameAndAnEmptyPassword()
        {
            loginPage.EmptyPassword(driver);
        }


        [Then("I should see email verification sent message")]
        public void ThenIShouldSeeEmailVerificationSentMessage()
        {
           loginPage.VerifyEmailSuccess(driver);
        }

        [Then("I should see please enter a valid email address message")]
        public void ThenIShouldSeePleaseEnterAValidEmailAddressMessage()
        {
           loginPage.VerifyEmail(driver);
        }

        [Then("I should see  password must be at least 6 characters message")]
        public void ThenIShouldSeePasswordMustBeAtLeastCharactersMessage()
        {
            loginPage.VerifyPassword(driver);
        }

        

    }
}

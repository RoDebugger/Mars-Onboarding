using System;
using Mars_Onboarding.Pages;
using NUnit.Framework;
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
            Thread.Sleep(2000); // Wait for the page to load
            loginPage.GetSuccessfulLogin(driver);
            IWebElement profileNameElement = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));
            Assert.That(profileNameElement.Text, Is.EqualTo("Hi Roshini"), "Test Failed: Login was not successful.");
        }
        [Given("I enter an invalid username and password")]
        public void GivenIEnterAnInvalidUsernameAndPassword()
        {
            loginPage.InvalidLogin(driver);
        }

        [Then("I should see an error message indicating invalid credentials")]
        public void ThenIShouldSeeAnErrorMessageIndicatingInvalidCredentials()
        {
            Thread.Sleep(1000); // Wait for the error message to appear
            loginPage.ErrorMessage(driver);
            IWebElement webElement = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            Assert.That(webElement.Text, Is.EqualTo("Confirm your email"), "Test Failed: Error message not displayed as expected.");
            IWebElement alert = driver.FindElement(By.XPath("/html/body/div[1]/a"));
            alert.Click(); // Close the alert if it appears


        }


        [When("I click on the send verification email button")]
        public void WhenIClickOnTheSendVerificationEmailButton()
        {
            loginPage.ClickVerifyButton(driver);
        }

        [Then("I should see email verification failed message")]
        public void ThenIShouldSeeEmailVerificationFailedMessage()
        {
         Thread.Sleep(1000); // Wait for the error message to appear
            loginPage.VerifyEmailFailed(driver);
            IWebElement verifyEmailElement = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            Assert.That(verifyEmailElement.Text, Is.EqualTo("Email Verification Failed"), "Test Failed: Email verification failed message not displayed as expected.");
        }

        [Given("I enter an invalid username and a valid password")]
        public void GivenIEnterAnInvalidUsernameAndAValidPassword()
        {
            loginPage.IncorrectUsername(driver);
        }

        [Then("I should see error message indicating invalid credentials")]
        public void ThenIShouldSeeErrorMessageIndicatingInvalidCredentials()
        {
            Thread.Sleep(1000); // Wait for the error message to appear
            loginPage.ErrorMessage(driver);
            IWebElement webElement = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            Assert.That(webElement.Text, Is.EqualTo("Confirm your email"), "Test Failed: Error message not displayed as expected.");
            IWebElement alert = driver.FindElement(By.XPath("/html/body/div[1]/a"));
            alert.Click(); // Close the alert if it appears

        }

        [Given("I enter a valid username and an invalid password")]
        public void GivenIEnterAValidUsernameAndAnInvalidPassword()
        {
            loginPage.IncorrectPassword(driver);
        }

        [Then("I should see an email verification sent message")]
        public void ThenIShouldSeeAnEmailVerificationSentMessage()
        {
            Thread.Sleep(1000); // Wait for the email verification message to appear
            loginPage.VerifyEmailSuccess(driver);
            IWebElement confirmEmailElement = driver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.That(confirmEmailElement.Text, Is.EqualTo("Email Verification Sent"), "Test Failed: Email verification sent message not displayed as expected.");
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

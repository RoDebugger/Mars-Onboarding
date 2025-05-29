using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Onboarding.Pages
{
    public class LoginPage
    {

        public string password = "Westlake123";
        public string emailAddress = "roshini04@hotmail.com";
        public string url = "http://localhost:5003/";


        // Locators
        private readonly By SignInButton = By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a");
        private readonly By EmailField = By.Name("email");
        private readonly By PasswordField = By.Name("password");
        private readonly By LoginButton = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button");
        private readonly By ProfileName = By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span");
        private readonly By SendVerification = By.XPath("//*[@id=\"submit-btn\"]");
        private readonly By ConfirmEmailPop = By.XPath("/html/body/div[1]/div");
        private readonly By FailedVerification = By.XPath("/html/body/div[1]");
        public void NavigateToPage(IWebDriver driver)

        {

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            IWebElement signInButtonElement = driver.FindElement(SignInButton);
            signInButtonElement.Click();
        }

        public void LoginActions(IWebDriver driver)
        {

            IWebElement emailFieldElement = driver.FindElement(EmailField);
            emailFieldElement.SendKeys(emailAddress);
            IWebElement passwordFieldElement = driver.FindElement(PasswordField);
            passwordFieldElement.SendKeys(password);
            IWebElement loginButtonElement = driver.FindElement(LoginButton);
            loginButtonElement.Click();

        }

        public void SuccessfulLogin(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement profileNameElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ProfileName));
            Assert.That(profileNameElement.Text == "Hi Roshini", Is.True, "Test Failed: Login was not successful.");
        }

        public void InvalidLogin(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement emaillFieldElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(EmailField));
            emaillFieldElement.SendKeys("roshini@duranit.lk");
            IWebElement passwordFieldElement = driver.FindElement(PasswordField);
            passwordFieldElement.SendKeys("Roshini123");

        }

        public void IncorrectUsername(IWebDriver driver)
        {
            IWebElement emailFieldElement = driver.FindElement(EmailField);
            emailFieldElement.SendKeys("roshini@duranit.lk");
            IWebElement passwordFieldElement = driver.FindElement(PasswordField);
            passwordFieldElement.SendKeys(password);
            IWebElement loginButtonElement = driver.FindElement(LoginButton);
            loginButtonElement.Click();

        }
        public void IncorrectPassword(IWebDriver driver)
        {
            IWebElement emailFieldElement = driver.FindElement(EmailField);
            emailFieldElement.SendKeys(emailAddress);
            IWebElement passwordFieldElement = driver.FindElement(PasswordField);
            passwordFieldElement.SendKeys("roshini123");
            IWebElement loginButtonElement = driver.FindElement(LoginButton);
            loginButtonElement.Click();
        }

        public void EmptyFields(IWebDriver driver)
        {

            IWebElement loginButtonElement = driver.FindElement(LoginButton);
            loginButtonElement.Click();
        }

        public void EmptyUsername(IWebDriver driver)
        {
            IWebElement passwordFieldElement = driver.FindElement(PasswordField);
            passwordFieldElement.SendKeys(password);
            IWebElement loginButtonElement = driver.FindElement(LoginButton);
            loginButtonElement.Click();
        }
        public void EmptyPassword(IWebDriver driver)
        {
            IWebElement emailFieldElement = driver.FindElement(EmailField);
            emailFieldElement.SendKeys(emailAddress);
            IWebElement loginButtonElement = driver.FindElement(LoginButton);
            loginButtonElement.Click();
        }

        public void ErrorMessage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement errorMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ConfirmEmailPop));
            Assert.That(errorMessageElement.Text == "Confirm your email", Is.True, "Test Failed: Error message not displayed as expected.");


        }
        public void ErrorNotification(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement errorNotificationElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(SendVerification));
            Assert.That(errorNotificationElement.Text == "Send Verification Email", Is.True, "Test Failed: Error notification not displayed as expected.");
        }

        public void ClickVerifyButton(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            IWebElement verifyButtonElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(SendVerification));
            verifyButtonElement.Click();
        }

        public void VerifyEmailFailed(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement verifyEmailElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(FailedVerification));
            Assert.That(verifyEmailElement.Text == "Email Verification Failed", Is.True, "Test Failed: Email verification failed.");
        }

        public void VerifyEmailSuccess(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement verifyEmailElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ConfirmEmailPop));
            Assert.That(verifyEmailElement.Text == "Email Verification Sent", Is.True, "Test Failed: Email verification was not successful.");
        }
        public void VerifyEmail(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement errorMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/div")));
            Assert.That(errorMessageElement.Text == "Please enter a valid email address", Is.True, "Test Failed: Error message not displayed as expected.");
        }

        public void VerifyPassword(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement errorMessageElement1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/div")));
            Assert.That(errorMessageElement1.Text == "Password must be at least 6 characters", Is.True, "Test Failed: Error message not displayed as expected.");
        }
    }
    
}

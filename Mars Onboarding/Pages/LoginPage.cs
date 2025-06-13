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

        public string GetSuccessfulLogin(IWebDriver driver)
        {
            return driver.FindElement(ProfileName).Text;

        }

        public void InvalidLogin(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement emaillFieldElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(EmailField));
            emaillFieldElement.SendKeys("roshini@duranit.lk");
            IWebElement passwordFieldElement = driver.FindElement(PasswordField);
            passwordFieldElement.SendKeys("Roshini123");
            IWebElement loginButton= driver.FindElement(LoginButton);
            loginButton.Click();

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

        public string ErrorMessage(IWebDriver driver)
        {
            return driver.FindElement(ConfirmEmailPop).Text;
            
        }
        public string ErrorNotification(IWebDriver driver)
        {
            return driver.FindElement(SendVerification).Text;
        }
       
        public void ClickVerifyButton(IWebDriver driver)
        {

            IWebElement verifyButton = driver.FindElement(By.XPath("//*[@id=\"submit-btn\"]"));
            verifyButton.Click();
        }

        public string VerifyEmailFailed(IWebDriver driver)
        {
            return driver.FindElement(FailedVerification).Text;
            
        }

        public string VerifyEmailSuccess(IWebDriver driver)
        {
            return driver.FindElement(ConfirmEmailPop).Text;
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

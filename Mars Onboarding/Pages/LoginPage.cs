using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Onboarding.Pages
{
    public class LoginPage
    {
        public void LoginActions(IWebDriver driver) 
        {
            driver.Navigate().GoToUrl("http://localhost:5003/");
            driver.Manage().Window.Maximize();

            IWebElement signInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signInButton.Click();
            IWebElement emailField = driver.FindElement(By.Name("email"));
            emailField.SendKeys("roshini04@hotmail.com");
            IWebElement passwordField = driver.FindElement(By.Name("password"));
            passwordField.SendKeys("Westlake123");
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();


        }
    }
}

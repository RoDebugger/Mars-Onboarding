using Mars_Onboarding.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Onboarding.Support
{
    public class CommonDriver
    {
         
        public static IWebDriver? driver;

        public static void Initialize()
        {
            // Initialize the WebDriver here
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}


using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Onboarding.Pages
{
    public class LanguagesPage
    {

        //locators
        private readonly By LanguageTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]");
        private readonly By AddLanguageButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
        private readonly By LanguageField = By.Name("name");
        private readonly By LevelDropdown = By.Name("level");
        private readonly By AddButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]");
        private readonly By EditButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i");
        private readonly By SaveButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]");
        private readonly By DeleteButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i");

        public void AddLanguage(IWebDriver driver, string language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            IWebElement addLanguageButtonElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AddLanguageButton));
            addLanguageButtonElement.Click();
            IWebElement languageField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(LanguageField));
            languageField.SendKeys(language);
            IWebElement levelDropdown = driver.FindElement(LevelDropdown);
            levelDropdown.Click();
            SelectElement selectElement = new SelectElement(levelDropdown);
            selectElement.SelectByText("Basic");
            IWebElement addButton = driver.FindElement(AddButton);
            addButton.Click();

        }

        public void GetLanguage(IWebDriver driver, string language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement languageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")));
            Assert.That(languageElement.Text == language, Is.True, "Test Failed: Language not found.");
        }

        public void EditLanguage(IWebDriver driver, string language, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            Thread.Sleep(2000); // Wait for the page to load
            IWebElement editLanguageButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(EditButton));
            editLanguageButton.Click();
            IWebElement languageField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(LanguageField));
            languageField.Clear();
            languageField.SendKeys(language);
            IWebElement levelDropdown = driver.FindElement(LevelDropdown);
            levelDropdown.Click();
            SelectElement selectElement = new SelectElement(levelDropdown);
            selectElement.SelectByText(level);
            IWebElement saveButton = driver.FindElement(SaveButton);
            saveButton.Click();

        }
        public void GetEditedLanguage(IWebDriver driver, string language, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement editedLanguage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")));
            Assert.That(editedLanguage.Text == language, Is.True, "Test Failed: Language not found.");
        }
        public void GetEditedLanguageLevel(IWebDriver driver, string language, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement editedLanguageLevel = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]")));
            Assert.That(editedLanguageLevel.Text == level, Is.True, "Test Failed: Language not found.");
        }
        public void DeleteLanguage(IWebDriver driver, string language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            try
            {
                IWebElement deleteLanguageButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(DeleteButton));
                deleteLanguageButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Language '{language}' not found for deletion.");


            }
        }

        public void VerifyLanguageDeleted(IWebDriver driver, string language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement deletedLanguage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")));
            Assert.That(deletedLanguage.Text != language, Is.True, "Test Failed: Language not deleted.");
        }

        public void AddLanguageWithEmptyLevel(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement addLanguageButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AddLanguageButton));
            addLanguageButton.Click();
            IWebElement languageField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(LanguageField));
            languageField.SendKeys("abc");
            IWebElement addButton = driver.FindElement(AddButton);
            addButton.Click();
        }

        public void AddLanguageWithEmptyField(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement addLanguageButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AddLanguageButton));
            addLanguageButton.Click();
            IWebElement levelDropdown = driver.FindElement(LevelDropdown);
            levelDropdown.Click();
            SelectElement selectElement = new SelectElement(levelDropdown);
            selectElement.SelectByText("Basic");
            IWebElement addButton = driver.FindElement(AddButton);
            addButton.Click();


        }

        public void AddLanguagewithBothEmptyFields(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement addLanguageButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AddLanguageButton));
            addLanguageButton.Click();
            IWebElement addButton = driver.FindElement(AddButton);
            addButton.Click();
        }

        public string GetEmptyFieldsError(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("/html/body/div[1]")).Text;

        }
        public void AddSameLanguage(IWebDriver driver, string language, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement addLanguageButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AddLanguageButton));
            addLanguageButton.Click();
            IWebElement languageField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(LanguageField));
            languageField.SendKeys(language);
            IWebElement levelDropdown = driver.FindElement(LevelDropdown);
            levelDropdown.Click();
            SelectElement selectElement = new SelectElement(levelDropdown);
            selectElement.SelectByText("Basic");
            IWebElement addButton = driver.FindElement(AddButton);
            addButton.Click();
        }

        public string GetSameLanguageError(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("/html/body/div[1]")).Text;
        }
    }
}

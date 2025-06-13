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
    public class SkillsPage
    {
        //locators
        private readonly By SkillsTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]");
        private readonly By AddSkillButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div");
        private readonly By SkillField = By.Name("name");
        private readonly By SkillLevelDropdown = By.Name("level");
        private readonly By AddButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]");
        private readonly By EditButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i");
        private readonly By SaveButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]");
        private readonly By DeleteButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i");
        private readonly By AddedSkill = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]");

        public void AddSkill(IWebDriver driver, string skill)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement skillsTab = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SkillsTab));
            skillsTab.Click();
            IWebElement addSkillButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AddSkillButton));
            addSkillButton.Click();
            IWebElement skillField = driver.FindElement(SkillField);
            skillField.SendKeys(skill);
            IWebElement skillLevelDropdown = driver.FindElement(SkillLevelDropdown);
            skillLevelDropdown.Click();
            SelectElement selectSkillLevel = new SelectElement(skillLevelDropdown);
            selectSkillLevel.SelectByText("Beginner");

            IWebElement addSkillButton1 = driver.FindElement(AddButton);
            addSkillButton1.Click();

        }

        public void GetSkill(IWebDriver driver, string skill)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            IWebElement newSkill = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(AddedSkill));

            Assert.That(newSkill.Text == skill, Is.True, "Test Failed: Skill not added.");

        }

        public void EditSkill(IWebDriver driver, string skill, string level)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            IWebElement skillsTab = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SkillsTab));
            skillsTab.Click();

            IWebElement editSkillButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(EditButton));
            editSkillButton.Click();
            IWebElement skillField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(SkillField));
            skillField.Clear();
            skillField.SendKeys(skill);
            IWebElement skillLevelDropdown = driver.FindElement(SkillLevelDropdown);
            skillLevelDropdown.Click();
            SelectElement selectSkillLevel = new SelectElement(skillLevelDropdown);
            selectSkillLevel.SelectByText(level);
            IWebElement saveButton = driver.FindElement(SaveButton);
            saveButton.Click();

        }

        public void GetEditedSkill(IWebDriver driver, string skill, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement updatedSkill = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(AddedSkill));
            Assert.That(updatedSkill.Text == skill, Is.True, "Test Failed: Skill not updated.");

        }
        public void GetUpdatedSkillLevel(IWebDriver driver, string skill, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            IWebElement updatedSkillLevel = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]")));
            Assert.That(updatedSkillLevel.Text == level, Is.True, "Test Failed: Skill level not updated.");
        }

        public void DeleteSkill(IWebDriver driver, string skill)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement skillsTab = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SkillsTab));
            skillsTab.Click();
            IWebElement deleteSkillButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(DeleteButton));
            deleteSkillButton.Click();


        }

        public void VerifySkillDeleted(IWebDriver driver, string skill)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            IWebElement deletedSkill = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(AddedSkill));
            Assert.That(deletedSkill.Text != skill, Is.True, "Test Failed: Skill not deleted.");
        }
        public void AddSkillWithEmptyLevel(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement skillsTab = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SkillsTab));
            skillsTab.Click();
            IWebElement addSkillButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AddSkillButton));
            addSkillButton.Click();
            IWebElement skillField = driver.FindElement(SkillField);
            skillField.SendKeys("Testing");
            IWebElement addSkillButton1 = driver.FindElement(AddButton);
            addSkillButton1.Click();
        }

        public string GetEmptyFieldsError(IWebDriver driver)
        {
           
            return driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;

        }

        public void AddSkllWithEmptySkill(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement skillsTab = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            skillsTab.Click();
            IWebElement addSkillButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")));
            addSkillButton.Click();
            IWebElement skillLevelDropdown = driver.FindElement(By.Name("level"));
            skillLevelDropdown.Click();
            SelectElement selectSkillLevel = new SelectElement(skillLevelDropdown);
            selectSkillLevel.SelectByText("Beginner");
            IWebElement addSkillButton1 = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addSkillButton1.Click();
        }
        public string GetEmptySkillError(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;
        }
        public void AddSkillWithEmptyFields(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement skillsTab = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            skillsTab.Click();
            IWebElement addSkillButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")));
            addSkillButton.Click();
            IWebElement addSkillButton1 = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addSkillButton1.Click();
        }

       
        public void AddSameSkillWithDifferentLevel(IWebDriver driver, string skill, string level)

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement skillsTab = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SkillsTab));
            skillsTab.Click();
            IWebElement addSkillButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AddSkillButton));
            addSkillButton.Click();
            IWebElement skillField = driver.FindElement(SkillField);
            skillField.SendKeys(skill);
            IWebElement skillLevelDropdown = driver.FindElement(SkillLevelDropdown);
            skillLevelDropdown.Click();
            SelectElement selectSkillLevel = new SelectElement(skillLevelDropdown);
            selectSkillLevel.SelectByText(level);

            IWebElement addSkillButton1 = driver.FindElement(AddButton);
            addSkillButton1.Click();


        }

        public string VerifyAddedSkill(IWebDriver driver, string message)
        {
            return driver.FindElement(By.XPath("/html/body/div[1]/div")).Text;

        }

        public void RemoveSkill(IWebDriver driver, string skill)
        {
           var skillRow = driver.FindElement(AddedSkill);
            if (skillRow != null)
            {
                var deleteButton = skillRow.FindElement(DeleteButton);
                deleteButton.Click();
            }
            else
            {
                throw new NoSuchElementException($"Skill '{skill}' not found for deletion.");
            }
        }
    }
}

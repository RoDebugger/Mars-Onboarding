using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace Mars_Onboarding.Hooks
{
    [Binding]
    public sealed class LangAndSkillHooks
    {
        private  IWebDriver? driver;

        [BeforeScenario("@tag1")]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            driver = new ChromeDriver();
            scenarioContext["WebDriver"] = driver;

        }
        
       
      

        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Quit();
        }
    }
}
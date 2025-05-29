using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;

namespace Mars_Onboarding.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }


        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();

            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }


        [AfterScenario("@AddLang")]

        public void CleanUpAddedLanguage()
        {
            if (_scenarioContext.TryGetValue("AddedLanguage", out string addedLanguage))
            {
                var driver = _objectContainer.Resolve<IWebDriver>();
                var languagesPage = new Pages.LanguagesPage();
                languagesPage.DeleteLanguage(driver, addedLanguage);
            }
        }

        [AfterScenario("@EditLang")]

        public void CleanUpEditedLanguage()
        {
            if (_scenarioContext.TryGetValue("EditedLanguage", out string editedLanguage))
            {
                var driver = _objectContainer.Resolve<IWebDriver>();
                var languagesPage = new Pages.LanguagesPage();
                languagesPage.DeleteLanguage(driver, editedLanguage);
            }

        }

        [AfterScenario("@AddSkill")]

        public void CleanUpAddedSkill()
        {
            if (_scenarioContext.TryGetValue("AddedSkill", out string addedSkill))
            {
                var driver = _objectContainer.Resolve<IWebDriver>();
                var skillsPage = new Pages.SkillsPage();
                skillsPage.DeleteSkill(driver, addedSkill);
            }
        }

        [AfterScenario("@EditSkill")]

        public void CleanUpEditedSkill()
        { if (_scenarioContext.TryGetValue("EditedSkill", out string editedSkill))
            {
                var driver = _objectContainer.Resolve<IWebDriver>();
                var skillsPage = new Pages.SkillsPage();
                skillsPage.DeleteSkill(driver, editedSkill);

            }
            }






            [AfterScenario]


            public void TearDown()
            {
                var driver = _objectContainer.Resolve<IWebDriver>();
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }
    } 
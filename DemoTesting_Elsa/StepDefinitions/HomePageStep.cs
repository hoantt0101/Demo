using NUnit.Framework;
using PageObjects.PageObject;
using TechTalk.SpecFlow;

namespace TestSpecs.StepDefinitions
{
    [Binding]
    public class HomePageStep
    {
        private readonly HomePage _homePage;

        public HomePageStep(HomePage homePage)
        {
            _homePage = homePage;

        }

        [Given(@"I go to elsa speech analyzer")]
        public void GivenIGoToElsaSpeechAnalyzer()
        {
            _homePage.GoToHomePage();
        }

        [When(@"I click sign in button")]
        public void WhenIClickSignInButton()
        {
            _homePage.ClickLoginBtn();
        }

        [When(@"I click create new account button")]
        public void WhenIClickCreateNewAccountButton()
        {
            _homePage.ClickCreateAnAccBtn();
        }

        [Then(@"I see welcome page is displayed")]
        public void ThenISeeWelcomePageIsDisplayed()
        {
            _homePage.WaitForLoader();
            string url = _homePage.GetUrl();
            Assert.Multiple(() =>
            {
                Assert.That(url.Contains("welcome"), "Welcome page is NOT displayed");
                Assert.That(_homePage.IsLogoutBtnDisplayed(), "Log out btn is NOT displayed");
            });
        }
    }
}

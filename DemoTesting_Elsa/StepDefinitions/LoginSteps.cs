using NUnit.Framework;
using PageObjects.PageObject;
using TechTalk.SpecFlow;

namespace TestSpecs.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;
        public LoginSteps(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }
        [Then(@"I see sign in page is displayed correctly")]
        public void ThenISeeSignInPageIsDisplayedCorrectly()
        {
            string url = _loginPage.GetUrl();
            Assert.Multiple(() =>
            {
                Assert.That(url.Contains("sign-in"), "Does NOT redirect to sign in page");
                Assert.That(_loginPage.IsSignInFormDisplayed(), "Sign in form is NOT displayed");
            });
            
        }

        [When(@"I input email '([^']*)'")]
        public void WhenIInputEmail(string email)
        {
            _loginPage.InputEmail(email);
        }

        [When(@"I input password '([^']*)'")]
        public void WhenIInputPassword(string pwd)
        {
            _loginPage.InputPassword(pwd);
        }

        [When(@"I click Login btn")]
        public void WhenIClickSignInBtn()
        {
            _loginPage.ClickSignUpBtn();
        }


    }
}

using NUnit.Framework;
using PageObjects.Common;
using PageObjects.PageObject;
using TechTalk.SpecFlow;

namespace TestSpecs.StepDefinitions
{
    [Binding]
    public class CreateNewAccSteps
    {
        private readonly CreateNewAcc _createNewAcc;
        private readonly CreateAccountSubmission _createAccountSubmission;
        public CreateNewAccSteps(CreateNewAcc createNewAcc, CreateAccountSubmission createAccountSubmission)
        {
            _createNewAcc = createNewAcc;
            _createAccountSubmission = createAccountSubmission;
        }

        [Then(@"I see sign up page is displayed correctly")]
        public void ThenISeeSignUpPageIsDisplayedCorrectly()
        {
            string url = _createNewAcc.GetUrl();
            Assert.Multiple(() =>
            {
                Assert.That(url.Contains("sign-up"), "URL does not contain sign-up");
                Assert.That(_createNewAcc.IsUnauthorizePageDisplayed(), "Unauthorize page is NOT displayed");
            });
        }

        [When(@"I click create new account btn")]
        public void WhenIClickCreateNewAccountBtn()
        {
            _createNewAcc.ClickCreateNewAccBtn();
        }

        [Then(@"I see Sign up form is displayed")]
        public void ThenISeeSignUpFormIsDisplayed()
        {
            Assert.That(_createNewAcc.IsSignUpFormDisplayed(), "Sign up form is NOT displayed");
        }

        [When(@"I fill valid account details")]
        public void WhenIFillValidAccountDetails()
        {
            var validAccountInfo = _createAccountSubmission.SetValidValues();
            _createNewAcc.InputName(validAccountInfo.Name);
            _createNewAcc.InputEmail(validAccountInfo.Email);
            _createNewAcc.InputPassword(validAccountInfo.Password);
        }

        [When(@"I click create an account btn")]
        public void WhenIClickCreateAnAccountBtn()
        {
            _createNewAcc.ClickSignUpBtn();
        }

    }
}

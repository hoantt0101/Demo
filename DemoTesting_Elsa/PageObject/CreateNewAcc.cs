using OpenQA.Selenium;
using PageObjects.PageObject.Base;

namespace PageObjects.PageObject
{
    public class CreateNewAcc : Page
    {
        #region PageObject
        private readonly By _unauthorizePage = By.ClassName("unauthorized-page");
        private readonly By _createNewAccBtn = By.CssSelector(".login-selection__footer button:first-child");
        private readonly By _signUpForm = By.ClassName("sign-up");
        private readonly By _fullName = By.Id("name");
        private readonly By _email = By.Id("email");
        private readonly By _pwd = By.Id("password");
        private readonly By _SignUpBtn = By.CssSelector(".sign-up .btn");
        #endregion

        #region Method
        public CreateNewAcc(IWebDriver driver) : base(driver)
        {
        }

        public bool IsUnauthorizePageDisplayed()
        {
            return IsElementDisplayed(_unauthorizePage);
        }

        public void ClickCreateNewAccBtn()
        {
            ClickElement(_createNewAccBtn);
        }

        public bool IsSignUpFormDisplayed()
        {
            return IsElementDisplayed(_signUpForm);
        }

        public void InputName(string name)
        {
            TextInput(_fullName, name);
        }

        public void InputEmail(string email)
        {
            TextInput(_email, email);
        }

        public void InputPassword(string pwd)
        {
            TextInput(_pwd, pwd);
        }

        public void ClickSignUpBtn()
        {
            ClickElement(_SignUpBtn);
        }

        #endregion
    }
}

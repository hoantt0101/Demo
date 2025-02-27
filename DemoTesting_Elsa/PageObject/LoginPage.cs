using OpenQA.Selenium;
using PageObjects.PageObject.Base;

namespace PageObjects.PageObject
{
    public class LoginPage : Page
    {
        #region PageObject
        private readonly By _signInForm = By.ClassName("sign-in");
        private readonly By _emailField = By.CssSelector("[name='email']");
        private readonly By _pwdField = By.CssSelector("[type='password']");
        private readonly By _signInBtn = By.CssSelector(".sign-in .btn");

        #endregion

        #region Method
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsSignInFormDisplayed()
        {
            return IsElementDisplayed(_signInForm);
        }
        public void InputEmail(string email)
        {
            TextInput(_emailField, email);
        }

        public void InputPassword(string password)
        {
            TextInput(_pwdField, password);
        }

        public void ClickSignUpBtn()
        {
            ClickElement(_signInBtn);
        }
        #endregion
    }
}

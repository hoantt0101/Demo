using OpenQA.Selenium;
using PageObjects.PageObject.Base;

namespace PageObjects.PageObject
{
    public class HomePage : Page
    {
        #region PageObject
        private readonly By _loginBtn = By.CssSelector(".header__wrapper [href='/sign-in']");
        private readonly By _creatAnAccBtn = By.CssSelector(".header__wrapper .btn");
        private readonly By _logoutBtn = By.CssSelector("[class*='button--logout']");
        #endregion

        #region Method

        private readonly string _url = "https://speechanalyzer.elsaspeak.com/";
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToHomePage()
        {
            NavigateToUrl(_url);
        }

        public void ClickLoginBtn()
        {
            ClickElement(_loginBtn);
            Sleep(500);
        }

        public void ClickCreateAnAccBtn()
        {
            ClickElement(_creatAnAccBtn);
        }

        public bool IsLogoutBtnDisplayed()
        {
            return IsElementDisplayed(_logoutBtn);
        }
        #endregion
    }
}

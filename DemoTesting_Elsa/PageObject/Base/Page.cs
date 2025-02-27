using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using PageObjects.Common.Helps;
using SeleniumExtras.WaitHelpers;

namespace PageObjects.PageObject.Base
{
    public class Page : GeneralHelper
    {
        #region PageObject
        private readonly By _loader = By.CssSelector(".loading__icon");
        #endregion

        private readonly IWebDriver _driver;
        private int longTimeOut = 30;
        public Page(IWebDriver driver)
        {
            _driver = driver;
        }

        public Page ClickElement(By elementLocator)
        {
            FindElement(elementLocator).Click();
            return this;
        }

        public IWebElement FindElement(By elementLocator)
        {
            return _driver.FindElement(elementLocator);
        }

        public string GetUrl()
        {
            var url = _driver.Url;
            Log.Info("Current url is: " + url);
            return url;
        }

        public Page TextInput(IWebElement element, string value)
        {
            element.SendKeys(value);
            Log.Info($"Entered '{value}' in field {element}");
            return this;
        }

        public Page TextInput(By element, string value)
        {
            FindElement(element).SendKeys(value);
            Log.Info($"Entered '{value}' in field {element}");
            return this;
        }

        public bool IsElementDisplayed(By element, int timeout = 30)
        {
            try
            {
                var elements = FindElements(element, timeout);
                var isDisplayed = elements.Any(elem => elem.Displayed);
                Log.Info($"Element {element} displayed: {isDisplayed}");
                return isDisplayed;
            }
            catch (NoSuchElementException)
            {
                Log.Info("No element found with locator: " + element);
                return false;
            }
            catch (StaleElementReferenceException)
            {
                Log.Info("Stale element with locator: " + element);
                return false;
            }
        }

        public ReadOnlyCollection<IWebElement> FindElements(By elementLocator, int timeoutInSeconds = 30)
        {
            if (timeoutInSeconds <= 0)
            {
                return _driver.FindElements(elementLocator);
            }

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            var elements = wait.Until(drv => drv.FindElements(elementLocator));
            Log.Info($"{elements.Count} elements found with locator: {elementLocator}");
            return elements;
        }

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            Log.Info("Navigated to: " + url);
        }

        public void waitForElementVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(longTimeOut));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
        public void waitForElementClickable(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(longTimeOut));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        public string GetElementText(By locator)
        {
            waitForElementVisible(locator);
            IWebElement element = _driver.FindElement(locator);
            return element.Text;

        }
        public void InputText(string str, By locator)
        {
            waitForElementVisible(locator);
            _driver.FindElement(locator).SendKeys(str);

        }

        public string GetURL()
        {
            return _driver.Url;
        }

        public Page Sleep(int ms)
        {
            Thread.Sleep(ms);
            Log.Info($"Sleep executed for {ms}ms");
            return this;
        }

        public Page WaitForLoader(int timeout = 30)
        {
            Sleep(500)
                .WaitUntilElementNotVisible(_loader, timeout);
            return this;
        }

        public Page WaitUntilElementNotVisible(By element, int timeout = 30, int initialWait = 0)
        {
            // This only waits until first element found is not visible
            var elementDisplayed = IsElementDisplayed(element, initialWait);
            if (!elementDisplayed) return this;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));

            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(element));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Element still visible after {timeout}s: {element}\n{e}");
            }

            Log.Info("Element no longer visible: " + element);
            return this;
        }

    }
}

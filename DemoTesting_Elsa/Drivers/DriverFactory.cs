using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Configuration;

namespace TestSpecs.Driver
{
    public class DriverFactory
    {
        public IWebDriver CreateDriver()
        {
            string browser = ConfigurationManager.AppSettings["Browser"];
            string isHeadless = ConfigurationManager.AppSettings["IsHeadless"];

            switch (browser.ToLower())
            {
                case "chrome":
                    {
                        if (isHeadless.Equals("true"))
                        {
                            ChromeOptions options = new ChromeOptions();
                            options.AddArgument("--headless");
                        }
                        return new ChromeDriver();
                    }

                case "firefox":
                    {
                        if (isHeadless.Equals("true"))
                        {
                            FirefoxOptions options = new FirefoxOptions();
                            options.AddArgument("--headless");
                        }

                        return new FirefoxDriver();
                    }

                default:
                    throw new ArgumentException($"Browser not yet implemented: {browser}");
            }
        }
    }
}
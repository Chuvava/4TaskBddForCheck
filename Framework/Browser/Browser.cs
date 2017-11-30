using System;
using OpenQA.Selenium;

namespace Framework.Browser
{
    public class Browser
    {
        private readonly IWebDriver driver = BrowserFactory.GetDriver();
        private static Browser browser;
        private Browser()
        {
        }

        public static Browser GetInstance()
        {
            if (browser == null)
            {
                browser = new Browser();
                browser.SetImplicitWait(Configuration.GetTimeWait());
                browser.WindowMaximize();
            }
            return browser;
        }

        public IWebDriver GetBrowser()
        {
            return driver;
        }

        public void SetImplicitWait(int timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }

        public void WindowMaximize()
        {
            driver.Manage().Window.Maximize();
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void SetPageLoadTimeout(int timeout)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);
        }

        public void Quit()
        {
            driver.Quit();
        }

        public static void CloseBrowser()
        {
            browser.Quit();
        }

        public static void NavigateUrl(string url)
        {
            browser.NavigateToUrl(url);
        }
    }
}

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace Framework.Elements
{
    public abstract class BaseElement
    {
        protected IWebDriver driver = Browser.Browser.GetInstance().GetBrowser();
        protected IWebElement element;
        protected By locator;
        protected WebDriverWait wait;

        protected BaseElement(By locator)
        {
            this.locator = locator;
        }

        public void WaitElement()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Configuration.GetTimeWait()));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            wait.Until((driver) =>
            {
                element = driver.FindElement(locator);
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
                return element.Enabled;
            });
        }

        public void Click()
        {
            WaitElement();
            driver.FindElement(locator).Click();
        }

        public string GetText()
        {
            WaitElement();
            return driver.FindElement(locator).Text;
        }

        public bool IfExist()
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException e)
            {
                e.GetBaseException();
                return false;
            }
        }

        public void MoveToElement()
        {
            WaitElement();
            IWebElement element = driver.FindElement(locator);
            new Actions(driver).MoveToElement(element).Perform();
        }
    }
}

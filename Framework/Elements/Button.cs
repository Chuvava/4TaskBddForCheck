using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator)
            : base(locator)
        {            
        }

        public void WaitElementExist()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Configuration.GetTimeWait()));
            element = wait.Until(ExpectedConditions.ElementExists(locator));
        }
    }
}

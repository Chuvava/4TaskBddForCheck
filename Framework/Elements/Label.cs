using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Elements
{
    public class Label: BaseElement
    {
        public Label(By locator)
            : base(locator)
        {            
        }

        public string GetLocatorString()
        {
            string strLocator = locator.ToString().Replace("By.XPath: ", "");
            return strLocator;
        }

        public List<Label> FindElements(string locatorXpath)
        {
            int count = driver.FindElements(By.XPath(locatorXpath)).Count;
            List<Label> elements = new List<Label>();
            for (int i = 1; i <= count; i++)
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Configuration.GetTimeWait()));
                By locatorEl = By.XPath(locatorXpath.Replace("/a", "/a[" + i + "]"));
                WaitElement();
                IWebElement el = wait.Until(ExpectedConditions.ElementExists(locatorEl));
                Label lblEl = new Label(By.XPath(locatorXpath.Replace("/a", "/a[" + i + "]")));
                elements.Add(lblEl);
            }
            return elements;
        }

        public int GetCountOfElements(string locatorXpath)
        {
            int count = driver.FindElements(By.XPath(locatorXpath)).Count;
            return count;
        }

        public List<Label> FindElementsInParagraph(string locatorXpath)
        {
            int count = driver.FindElements(By.XPath(locatorXpath)).Count;
            List<Label> lblElements = new List<Label>();
            for (int i = 1; i <= count; i++)
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Configuration.GetTimeWait()));
                By locatorEl = By.XPath(locatorXpath.Replace("/p", "/p[" + i + "]"));
                WaitElement();
                Label lblEl = new Label(locatorEl);
                lblElements.Add(lblEl);
            }
            return lblElements;
        }

        public string GetTextFromParagraph(Label el)
        {
            string text = null;
            if (el.GetCountOfElements(el.GetLocatorString()) == 1)
            {
                text = el.GetText();
                return text;
            }
            else
            {
                List<Label> listEl = new List<Label>();
                listEl = el.FindElementsInParagraph(el.GetLocatorString());
                int count = listEl.Count;
                for (int i = 0; i < count; i++)
                {
                    text += listEl[i].GetText();
                }
                return text;
            }
        }

    }
}

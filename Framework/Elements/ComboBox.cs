using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Elements
{
    public class ComboBox : BaseElement
    {
        private IWebElement select;
        private readonly SelectElement cmbBox;
        private readonly Random rand = new Random();

        public ComboBox(By locator)
            :base(locator)
        {
            WaitElement();
            select = driver.FindElement(locator);
            cmbBox = new SelectElement(select);
        }

        public new void WaitElement()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Configuration.GetTimeWait()));
            select = wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public void SelectOptionByIndex(int index)
        {
            WaitElement();
            cmbBox.SelectByIndex(index);
        }

        public void SelectOptionByText(string text)
        {
            WaitElement();
            cmbBox.SelectByText(text);
        }

        private int GetQuantityOfOptions()
        {
            int quantityOfOptions = cmbBox.Options.Count;
            return quantityOfOptions;
        }

        public int GetRandomOptionIndex()
        {
            int quantityOfOptions = GetQuantityOfOptions();
            int indexOfRandomOptions = rand.Next(1, quantityOfOptions);
            return indexOfRandomOptions;
        }

        public string GetRandomOptionText()
        {
            int index = GetRandomOptionIndex();
            string randomOptionString = cmbBox.Options[index].Text;
            return randomOptionString;
        }

        public void SelectRandomOptionByIndex()
        {
            int quantity = GetQuantityOfOptions();
            int indexOfRandomOption = GetRandomOptionIndex();
            WaitElement();
            cmbBox.SelectByIndex(indexOfRandomOption);
        }

    }
}

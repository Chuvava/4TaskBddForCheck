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

        public void SelectRandomOption()
        {
            int max = GetQuantityOfOptions();
            int indexOfRandomOptions = rand.Next(1, max);
            WaitElement();
            cmbBox.SelectByIndex(indexOfRandomOptions);
        }

        public new string GetText()
        {
            return cmbBox.SelectedOption.Text;
        }

        public new void WaitElement()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Configuration.GetTimeWait()));
            select = wait.Until(ExpectedConditions.ElementExists(locator));
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

    }
}

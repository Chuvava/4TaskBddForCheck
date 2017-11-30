using System;
using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CarsPages.Pages
{
    public class ComparePage : BaseForm
    {
        private string locPattern = "//div/select[@id='{0}-dropdown']";
        private readonly Button btnStartCompare = new Button(By.XPath("//button[contains(text(), 'Start Comparing')]"));
        //В данном случае специально указано точное совпадение класса @class='cui-alpha'
        private readonly Label lblH1 = new Label(By.XPath("//h1[@class='cui-alpha']"));
        private readonly string paritalTextFromH1 = "Compare Cars";

        public ComparePage()
        {
            Assert.IsTrue(lblH1.GetText().Contains(paritalTextFromH1), "Compare Page is opened");
        }

        public void SelectCarForComparing(string brandText, string modelText, string yearText)
        {
            ComboBox cmbBrand = new ComboBox(By.XPath(String.Format(locPattern, make)));
            ComboBox cmbModel = new ComboBox(By.XPath(String.Format(locPattern, model)));
            ComboBox cmbYear = new ComboBox(By.XPath(String.Format(locPattern, year)));
            cmbBrand.SelectOptionByText(brandText);
            cmbModel.SelectOptionByText(modelText);
            cmbYear.SelectOptionByText(yearText);
            btnStartCompare.Click();
        }
    }
}

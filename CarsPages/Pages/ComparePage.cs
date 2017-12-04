using System;
using CarsPages.Objects;
using Framework.Elements;
using OpenQA.Selenium;


namespace CarsPages.Pages
{
    public class ComparePage : BaseForm
    {
        private string make = "make";
        private string model = "model";
        private string year = "year";
        private string locPattern = "//div/select[@id='{0}-dropdown']";
        private readonly Button btnStartCompare = new Button(By.XPath("//button[contains(text(), 'Start Comparing')]"));
        //В данном случае специально указано точное совпадение класса @class='cui-alpha'
        private readonly Label lblH1 = new Label(By.XPath("//h1[@class='cui-alpha']"));
        private readonly string textFromH1 = "Compare Cars Side-by-Side";

        public ComparePage()
        {
            AreEqualStrings(textFromH1, btnStartCompare);
        }

        public void SelectCarForComparing(string numberCar)
        {
            ComboBox cmbBrand = new ComboBox(By.XPath(String.Format(locPattern, make)));
            ComboBox cmbModel = new ComboBox(By.XPath(String.Format(locPattern, model)));
            ComboBox cmbYear = new ComboBox(By.XPath(String.Format(locPattern, year)));
            cmbBrand.SelectOptionByText(CarsCatalog.GetBrand(numberCar));
            cmbModel.SelectOptionByText(CarsCatalog.GetModel(numberCar));
            cmbYear.SelectOptionByText(CarsCatalog.GetYear(numberCar));
            btnStartCompare.Click();
        }
    }
}

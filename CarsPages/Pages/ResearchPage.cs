using System;
using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CarsPages.Pages
{
    public class ResearchPage : BaseForm
    {
        private string locPattern = "//div[contains(@class, 'hsw-{0}s')]//select";
        private readonly Button btnSearch = new Button(By.XPath("//div[contains(@class, 'submit')]"));
        private readonly Label lblResearchForm = new Label(By.XPath("//section[@id='research-search-widget']"));
        private readonly Button btnSideBySideComparison = new Button(By.XPath("//a/h4[contains(text(), 'Side-by-side')]"));
        private string brandText;
        private string modelText;
        private string yearText;

        public ResearchPage()
        {
            Assert.IsTrue(lblResearchForm.IfExist(), "Research Page is opened");
        }

        private void SelectRandomBrand()
        {         
            ComboBox cmbBrand = new ComboBox(By.XPath(String.Format(locPattern, make)));
            brandText = cmbBrand.GetRandomOptionText();
            cmbBrand.SelectOptionByText(brandText);
        }

        private void SelectRandomModel()
        {
            ComboBox cmbModel = new ComboBox(By.XPath(String.Format(locPattern, model)));
            modelText = cmbModel.GetRandomOptionText();
            cmbModel.SelectOptionByText(modelText);
        }

        private void SelectRandomYear()
        {
            ComboBox cmbYear = new ComboBox(By.XPath(String.Format(locPattern, year)));
            yearText = cmbYear.GetRandomOptionText();
            cmbYear.SelectOptionByText(yearText);
        }

        public void SelectRandomCar()
        {
            SelectRandomBrand();
            SelectRandomModel();
            SelectRandomYear();
        }

        public void SubmitSearchOfSelectedCar()
        {
            btnSearch.Click();
        }

        public void NavigateToComparePage()
        {
            btnSideBySideComparison.Click();
        }

        public string[] GetRandomCarChoice()
        {
            return new[] {brandText, modelText, yearText};
        }
    }
}

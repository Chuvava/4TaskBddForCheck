using System;
using Framework.Elements;
using OpenQA.Selenium;


namespace CarsPages.Pages
{
    public class ResearchPage : BaseForm
    {
        private string make = "make";
        private string model = "model";
        private string year = "year";
        private string locPattern = "//div[contains(@class, 'hsw-{0}s')]//select";
        private readonly Button btnSearch = new Button(By.XPath("//div[contains(@class, 'submit')]"));
        private readonly Label lblResearchForm = new Label(By.XPath("//section[@id='research-search-widget']"));
        private readonly Button btnSideBySideComparison = new Button(By.XPath("//a/h4[contains(text(), 'Side-by-side')]"));
        private string brandText;
        private string modelText;
        private string yearText;

        public ResearchPage()
        {
            IsRightPage(lblResearchForm);
        }

        private string SelectRandom(string type)
        {
            ComboBox cmbType = new ComboBox(By.XPath(String.Format(locPattern, type)));
            cmbType.SelectRandomOption();
            return cmbType.GetText();
        }

        public void SelectRandomCar()
        {
            brandText = SelectRandom(make);
            modelText = SelectRandom(model);
            yearText = SelectRandom(year);
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

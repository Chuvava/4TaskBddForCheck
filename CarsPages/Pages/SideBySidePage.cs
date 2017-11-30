using System;
using Framework.Elements;
using OpenQA.Selenium;

namespace CarsPages.Pages
{
    public class SideBySidePage : BaseForm
    {
        private readonly Label btnAddCar = new Label(By.Id("icon-div"));
        private string locPatternCmb = "{0}-dropdown";
        private string doneXpath = "//button[contains(text(), 'Done')]";
        public string EngineFirst { get; set; }
        public string TransmissionFirst { get; set; }
        public string EngineSecond { get; set; }
        public string TransmissionSecond { get; set; }
        private string locPattern = "//cars-compare-compare-info[@header='{0}']//span[@index='{1}']//p";
        private Label engineFirst;
        private Label transmissionFirst;
        private Label engineSecond;
        private Label transmissionSecond;

        public void AddAnotherCarForCompare(string brandText, string modelText, string yearText)
        {
            btnAddCar.Click();
            ComboBox cmbBrand = new ComboBox(By.Id(String.Format(locPatternCmb, make)));
            ComboBox cmbModel = new ComboBox(By.Id(String.Format(locPatternCmb, model)));
            ComboBox cmbYear = new ComboBox(By.Id(String.Format(locPatternCmb, year)));
            Button btnDone = new Button(By.XPath(doneXpath));

            cmbBrand.SelectOptionByText(brandText);
            cmbModel.SelectOptionByText(modelText);
            cmbYear.SelectOptionByText(yearText);
            btnDone.Click();
        }

        private void InitializeCharacteristicsElements(string engine, string transmission, string firstIndex, string secondIndex)
        {
            engineFirst = new Label(By.XPath(String.Format(locPattern, engine, firstIndex)));
            engineSecond = new Label(By.XPath(String.Format(locPattern, engine, secondIndex)));
            transmissionFirst = new Label(By.XPath(String.Format(locPattern, transmission, firstIndex)));
            transmissionSecond = new Label(By.XPath(String.Format(locPattern, transmission, secondIndex)));
        }

        public void CopyCharacteristicsFromPage(string engine, string transmission, string firstIndex, string secondIndex)
        {
            InitializeCharacteristicsElements(engine, transmission, firstIndex, secondIndex);

            EngineFirst = engineFirst.GetTextFromParagraph(engineFirst).Replace("liter", "L");
            TransmissionFirst = transmissionFirst.GetTextFromParagraph(transmissionFirst);
            EngineSecond = engineSecond.GetTextFromParagraph(engineSecond).Replace("liter", "L");
            TransmissionSecond = transmissionSecond.GetTextFromParagraph(transmissionSecond);
        }       

    }
}

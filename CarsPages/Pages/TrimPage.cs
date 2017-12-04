using CarsPages.Objects;
using Framework.Elements;
using OpenQA.Selenium;


namespace CarsPages.Pages
{
    public class TrimPage : BaseForm
    {
        private readonly Label lblFieldEngine = new Label(By.XPath("//div[contains(@class, 'cell cell-bg grow')]"));
        private readonly Label lblFieldTransmission = new Label(By.XPath("//div[contains(@class, 'cell grow')]"));
        private readonly Label lblH1 = new Label(By.XPath("//h1"));
        private string extraLine = " Configurations";

        public TrimPage(string numberCar)
        {
            string choosenCar = string.Format("{0} {1} {2}", CarsCatalog.GetYear(numberCar), CarsCatalog.GetBrand(numberCar),
                CarsCatalog.GetModel(numberCar));
            AreEqualStrings(choosenCar, lblH1, extraLine);
        }

        public string GetEngine()
        {
            return lblFieldEngine.GetText();
        }

        public string GetTransmission()
        {
            return lblFieldTransmission.GetText();
        }
    }
}

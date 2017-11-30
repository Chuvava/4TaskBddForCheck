using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CarsPages.Pages
{
    public class TrimPage : BaseForm
    {
        private Label lblFieldEngine = new Label(By.XPath("//div[contains(@class, 'cell cell-bg grow-2')]"));
        private Label lblFieldTransmission = new Label(By.XPath("//div[contains(@class, 'cell grow-2')]"));
        private Label lblH1 = new Label(By.XPath("//h1"));

        public TrimPage(string model, string year)
        {
            Assert.IsTrue(lblH1.GetText().Contains(model) && lblH1.GetText().Contains(year), "Trim Page of right car is opened");
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

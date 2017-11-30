using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CarsPages.Pages
{
    public class ModelOfCarPage : BaseForm
    {
        private readonly Label lblTrimComparison;
        private readonly Menu menu = new Menu();
        private readonly Label lblH1 = new Label(By.XPath("//h1"));

        public ModelOfCarPage(string partialText, string model, string year)
        {
            Assert.IsTrue(lblH1.GetText().Contains(model) && lblH1.GetText().Contains(year), "The page of the rigth model " +
                                                                                             "of car is opened");
            lblTrimComparison = new Label(By.PartialLinkText(partialText));
        }

        public void NavigateToTrimComparison()
        {
                lblTrimComparison.Click();
        }

        public void NavigateItemMenu(string itemMenu)
        {
            menu.NavigateItemOfMenu(itemMenu);
        }

        public bool IsTrimComparisonLinkAvailable()
        {
            if (lblTrimComparison.IfExist())
                return true;

            return false;
        }

    }
}

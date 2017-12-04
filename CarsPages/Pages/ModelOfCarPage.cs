using Framework.Elements;
using OpenQA.Selenium;


namespace CarsPages.Pages
{
    public class ModelOfCarPage : BaseForm
    {
        private readonly Label lblTrimComparison;
        private readonly Menu menu = new Menu();

        public ModelOfCarPage(string partialText)
        {
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
            return lblTrimComparison.IfExist();
        }

    }
}

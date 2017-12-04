using OpenQA.Selenium;
using Framework.Elements;


namespace CarsPages.Pages
{
    public class MainPage : BaseForm
    {
        private readonly Menu menu = new Menu();
        private readonly Label lblSearchInventory = new Label(By.XPath("//div[contains(@class, 'cars-entry')]"));

        public MainPage()
        {
            IsRightPage(lblSearchInventory);
        }

        public void NavigateItemMenu(string itemMenu)
        {
            menu.NavigateItemOfMenu(itemMenu);
        }
    }
}

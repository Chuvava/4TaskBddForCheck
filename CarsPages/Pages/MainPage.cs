using OpenQA.Selenium;
using Framework.Elements;
using NUnit.Framework;

namespace CarsPages.Pages
{
    public class MainPage : BaseForm
    {
        private readonly Menu menu = new Menu();
        private readonly Label lblSearchInventory = new Label(By.XPath("//div[contains(@class, 'cars-entry-homepage-search-inventory')]"));

        public MainPage()
        {
            Assert.IsTrue(lblSearchInventory.IfExist(), "Main Page is opened");            
        }

        public void NavigateItemMenu(string itemMenu)
        {
            menu.NavigateItemOfMenu(itemMenu);
        }
    }
}

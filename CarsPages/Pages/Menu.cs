using System;
using Framework.Elements;
using OpenQA.Selenium;


namespace CarsPages.Pages
{
    public class Menu : BaseForm
    {
        private Label lblMenuItem;
        private string menuLocator = "//ul[contains(@class, 'global-nav__menu')]//a[contains(text(), '{0}')]";

        public void NavigateItemOfMenu(string menuItem)
        {
            lblMenuItem = new Label(By.XPath(String.Format(menuLocator, menuItem)));
            lblMenuItem.Click();
        }
    }
}

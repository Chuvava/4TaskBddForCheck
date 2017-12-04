using Framework.Browser;
using Framework.Elements;


namespace CarsPages.Pages
{
    public abstract class BaseForm
    {
        protected BaseForm()
        {
            Browser.GetInstance().GetBrowser();
        }

        protected bool IsRightPage(BaseElement element)
        {
            if (element.IfExist())
                return true;

                return false;
        }

        protected bool AreEqualStrings(string expected, BaseElement element, string extraLine)
        {
            string elementActualText = element.GetText().Replace(extraLine, "");
            if (expected == elementActualText)
                return true;

            return false;
        }

        protected bool AreEqualStrings(string expected, BaseElement element)
        {
            if (expected == element.GetText())
                return true;

            return false;
        }
    }
}

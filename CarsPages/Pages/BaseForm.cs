using Framework.Browser;

namespace CarsPages.Pages
{
    public class BaseForm
    {
        protected string make = "make";
        protected string model = "model";
        protected string year = "year";


        public BaseForm()
        {
            Browser.GetInstance().GetBrowser();
        }
    }
}

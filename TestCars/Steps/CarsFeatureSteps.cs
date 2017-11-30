using CarsPages.Objects;
using CarsPages.Pages;
using Framework;
using Framework.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace TestCars.Steps
{
    [Binding]
    public class CarsFeatureSteps
    {
        private ResearchPage researchPage;
        private ModelOfCarPage modelOfCarPage;
        private TrimPage trimPage;
        private ComparePage comparePage;
        private SideBySidePage sideBySidePage;
        private MainPage mainPage;
        private readonly CarsCatalog Catalog = new CarsCatalog();

        [BeforeScenario]
        public void TesInitialize()
        {
            Browser.GetInstance().GetBrowser();
        }

        [Given(@"Navigate to Main Page of Cars\.com")]
        public void GivenNavigateToMainPageOfCars_Com()
        {
            Browser.NavigateUrl(Configuration.GetUrl());
            mainPage = new MainPage();
        }

        [When(@"Navigate to (.*) Page")]
        public void WhenNavigateToResearchPage(string menuItem)
        {
            mainPage.NavigateItemMenu(menuItem);
        }

        [When(@"Select the (.*) Car by random values")]
        public void WhenSelectTheCarByRandomValues(string numberCar)
        {
            researchPage = new ResearchPage();
            researchPage.SelectRandomCar();
            string[] newRandomCar = researchPage.GetRandomCarChoice();
            Car newCar = new Car(newRandomCar[0], newRandomCar[1], newRandomCar[2]);
            Catalog.AddCar(numberCar, newCar);
        }

        [When(@"Click button Search")]
        public void WhenClickButtonSearch()
        {
            researchPage.SubmitSearchOfSelectedCar();
        }

        [When(@"Click on (.*) link of (.*) Page")]
        public void WhenClickOnTrimComparisonLinkOfCarPage(string partialText, string numberCar)
        {
            modelOfCarPage = new ModelOfCarPage(partialText, Catalog.GetModel(numberCar), Catalog.GetYear(numberCar));
            for (int i = 0; i <= 5; i++)
            {
                if (modelOfCarPage.IsTrimComparisonLinkAvailable())
                {
                    modelOfCarPage.NavigateToTrimComparison();
                    break;
                }
                if (i == 5)
                {
                    Assert.Fail("The car with available trim comparison link wasn't found." +
                                "Five attempts are finished.");
                }
                Catalog.DeleteCar(numberCar);
                modelOfCarPage.NavigateItemMenu(MenuEnum.Research);
                WhenSelectTheCarByRandomValues(numberCar);
                WhenClickButtonSearch();
                WhenClickOnTrimComparisonLinkOfCarPage(partialText, numberCar);
                break;
            }
        }

        [When(@"Save (.*) characteristics\(Engine and Transmission\) from base complectation")]
        public void WhenSaveCharacteristicsEngineAndTransmissionFromBaseComplectation(string numberCar)
        {
            trimPage = new TrimPage(Catalog.GetModel(numberCar), Catalog.GetModel(numberCar));
            Catalog.SetEngine(numberCar, trimPage.GetEngine());
            Catalog.SetTransmission(numberCar, trimPage.GetTransmission());
        }

        [When(@"Navigate To Compare Page")]
        public void WhenNavigateToComparePage()
        {
            researchPage.NavigateToComparePage();
            comparePage = new ComparePage();
        }

        [When(@"Select the (.*) Car for comparing")]
        public void WhenSelectTheCarForComparing(string numberCar)
        {
            comparePage.SelectCarForComparing(Catalog.GetBrand(numberCar), Catalog.GetModel(numberCar), 
                Catalog.GetYear(numberCar));
        }

        [When(@"Select another (.*) Car for comparing")]
        public void WhenSelectAnotherCarForComparing(string numberCar)
        {
            sideBySidePage = new SideBySidePage();
            sideBySidePage.AddAnotherCarForCompare(Catalog.GetBrand(numberCar), Catalog.GetModel(numberCar),
                Catalog.GetYear(numberCar));            
        }

        [When(@"Copy car's characteristics \((.*), (.*)\) for first Car: (.*) and second Car: (.*)")]
        public void WhenCopyCarSCharacteristicsEngineTransmissionForFirstCarAndSecondCar(string engine, string transmission,
            string firstIndex, string secondIndex)
        {
            sideBySidePage.CopyCharacteristicsFromPage(engine, transmission, firstIndex, secondIndex);
        }

        [Then(@"Assert the characteristics with data from trim pages for (.*) and (.*)")]
        public void ThenAssertTheCharacteristicsWithDataFromTrimPages(string numberCar, string numberCar2)
        {
            Assert.IsTrue(sideBySidePage.EngineFirst.Contains(Catalog.GetEngine(numberCar)), "Engines are equal");
            Assert.IsTrue(sideBySidePage.TransmissionFirst.Contains(Catalog.GetTransmission(numberCar)), "Transmissions are equal");
            Assert.IsTrue(sideBySidePage.EngineSecond.Contains(Catalog.GetEngine(numberCar2)), "Engines of second car are equal");
            Assert.IsTrue(sideBySidePage.TransmissionSecond.Contains(Catalog.GetTransmission(numberCar2)), "Transmissions of second car are equal");
        }

        [AfterScenario]
        public void AfterTest()
        {
            Browser.CloseBrowser();
        }

    }
}

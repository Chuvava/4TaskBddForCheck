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
            CarsCatalog.AddCar(numberCar, newCar);
        }

        [When(@"Click button Search")]
        public void WhenClickButtonSearch()
        {
            researchPage.SubmitSearchOfSelectedCar();
        }

        [When(@"Click on (.*) link of (.*) Page")]
        public void WhenClickOnTrimComparisonLinkOfCarPage(string partialText, string numberCar)
        {
            modelOfCarPage = new ModelOfCarPage(partialText);
            try
            {
                modelOfCarPage.NavigateToTrimComparison();
            }
            catch
            {
                CarsCatalog.DeleteCar(numberCar);
                modelOfCarPage.NavigateItemMenu(MenuEnum.Research);
                WhenSelectTheCarByRandomValues(numberCar);
                WhenClickButtonSearch();
                WhenClickOnTrimComparisonLinkOfCarPage(partialText, numberCar);
            }
        }

        [When(@"Save (.*) characteristics\(Engine and Transmission\) from base complectation")]
        public void WhenSaveCharacteristicsEngineAndTransmissionFromBaseComplectation(string numberCar)
        {
            trimPage = new TrimPage(numberCar); //**
            CarsCatalog.SetEngine(numberCar, trimPage.GetEngine());
            CarsCatalog.SetTransmission(numberCar, trimPage.GetTransmission());
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
            comparePage.SelectCarForComparing(numberCar);
        }

        [When(@"Select another (.*) Car for comparing")]
        public void WhenSelectAnotherCarForComparing(string numberCar)
        {
            sideBySidePage = new SideBySidePage();
            sideBySidePage.AddAnotherCarForCompare(numberCar);            
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
            string firstEngineActual = sideBySidePage.EngineFirst;
            string firstEngineExpected = CarsCatalog.GetEngine(numberCar);
            Assert.IsTrue(firstEngineActual.Contains(firstEngineExpected), "Engines are equal");

            string firstTransmissionActual = sideBySidePage.TransmissionFirst;
            string firstTransmissionExpected = CarsCatalog.GetTransmission(numberCar);
            Assert.IsTrue(firstTransmissionActual.Contains(firstTransmissionExpected), "Transmissions are equal");

            string secondEngineActual = sideBySidePage.EngineSecond;
            string secondEngineExpected = CarsCatalog.GetEngine(numberCar2);
            Assert.IsTrue(secondEngineActual.Contains(secondEngineExpected), "Engines of second car are equal");

            string secondTransmissionActual = sideBySidePage.TransmissionSecond;
            string secondTransmissionExpected = sideBySidePage.TransmissionSecond;
            Assert.IsTrue(secondTransmissionActual.Contains(secondTransmissionExpected), "Transmissions of second car are equal");
        }

        [AfterScenario]
        public void AfterTest()
        {
            Browser.CloseBrowser();
        }

    }
}

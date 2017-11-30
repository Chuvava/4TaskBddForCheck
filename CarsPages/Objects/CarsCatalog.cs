using System.Collections.Generic;

namespace CarsPages.Objects
{
    public class CarsCatalog
    {
        public Dictionary<string, Car> Catalog = new Dictionary<string, Car>();

        public void AddCar(string numberCar, Car car)
        {
            Catalog.Add(numberCar, car);
        }

        public void SetEngine(string numberCar, string engine)
        {
            Catalog[numberCar].Engine = engine;
        }

        public void SetTransmission(string numberCar, string transmission)
        {
            Catalog[numberCar].Transmission = transmission;
        }

        public string GetBrand(string numberCar)
        {
            return Catalog[numberCar].Brand;
        }

        public string GetModel(string numberCar)
        {
            return Catalog[numberCar].Model;
        }

        public string GetYear(string numberCar)
        {
            return Catalog[numberCar].Year;
        }

        public string GetEngine(string numberCar)
        {
            return Catalog[numberCar].Engine;
        }

        public string GetTransmission(string numberCar)
        {
            return Catalog[numberCar].Transmission;
        }

        public void DeleteCar(string numberCar)
        {
            Catalog.Remove(numberCar);
        }
    }
}

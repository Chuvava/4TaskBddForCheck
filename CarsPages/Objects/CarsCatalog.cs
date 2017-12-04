using System.Collections.Generic;


namespace CarsPages.Objects
{
    public static class CarsCatalog
    {
        public static  Dictionary<string, Car> Catalog = new Dictionary<string, Car>();

        public static void AddCar(string numberCar, Car car)
        {
            Catalog.Add(numberCar, car);
        }

        public static void SetEngine(string numberCar, string engine)
        {
            Catalog[numberCar].Engine = engine;
        }

        public static void SetTransmission(string numberCar, string transmission)
        {
            Catalog[numberCar].Transmission = transmission;
        }

        public static string GetBrand(string numberCar)
        {
            return Catalog[numberCar].Brand;
        }

        public static string GetModel(string numberCar)
        {
            return Catalog[numberCar].Model;
        }

        public static string GetYear(string numberCar)
        {
            return Catalog[numberCar].Year;
        }

        public static string GetEngine(string numberCar)
        {
            return Catalog[numberCar].Engine;
        }

        public static string GetTransmission(string numberCar)
        {
            return Catalog[numberCar].Transmission;
        }

        public static void DeleteCar(string numberCar)
        {
            Catalog.Remove(numberCar);
        }
    }
}

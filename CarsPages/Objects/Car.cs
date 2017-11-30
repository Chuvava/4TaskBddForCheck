namespace CarsPages.Objects
{
    public class Car
    {
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public Car(string brand, string model, string year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }
    }
}

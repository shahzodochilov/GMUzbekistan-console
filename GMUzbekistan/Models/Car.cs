using GMUzbekistan.Enums;

namespace GMUzbekistan.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public CarColor Color { get; set; }

        public int NumberOfSeats { get; set; }

        public CarTransmission Transmission { get; set; }

        public CarSafety Safety { get; set; }
    }
}

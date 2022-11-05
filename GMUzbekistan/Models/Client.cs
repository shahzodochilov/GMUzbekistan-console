using GMUzbekistan.Enums;

namespace GMUzbekistan.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public byte Age { get; set; }

        public Gender Gender { get; set; }

        public string Adress { get; set; }

        public string Pass { get; set; }
    }
}

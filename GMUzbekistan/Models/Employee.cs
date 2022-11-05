using GMUzbekistan.Enums;

namespace GMUzbekistan.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public byte Age { get; set; }

        public Gender Gender { get; set; }

        public double Salary { get; set; }

        public EmployeePosition Position { get; set; }

        public string Address { get; set; }
    }
}

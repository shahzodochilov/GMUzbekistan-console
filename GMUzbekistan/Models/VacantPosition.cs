using GMUzbekistan.Enums;

namespace GMUzbekistan.Models
{
    public class VacantPosition
    {
        public int Id { get; set; }

        public EmployeePosition Position { get; set; }

        public double Salary { get; set; }

        public int Number { get; set; }
    }
}

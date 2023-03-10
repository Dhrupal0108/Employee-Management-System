using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.Model
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Department { get; set; }
    }
}

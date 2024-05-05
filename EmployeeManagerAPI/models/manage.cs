using System;

namespace EmployeeManagerAPI.Models
{
    public class Manage
    {
        public DateTime StartDate { get; set; }

        // Foreign key para Employee
        public string EmployeeSSN { get; set; }
        public virtual Employee? Employee { get; set; }

        // Foreign key para Department
        public string DepartmentName { get; set; }
        public int DepartmentNumber { get; set; }
        public virtual Department? Department { get; set; }
    }
}

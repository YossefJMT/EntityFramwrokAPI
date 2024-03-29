using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoAPI.Models
{
    public class Employee
    {
        [Key]
        public string SSN { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(1)]
        public string MiddleInitial { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public decimal Salary { get; set; }
        
        public string Sex { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string FullName => $"{FirstName} {MiddleInitial} {LastName}";

        // Propiedad de navegación para la relación de supervisión
        public virtual ICollection<Employee> SupervisedEmployees { get; set; }
    

    }
}

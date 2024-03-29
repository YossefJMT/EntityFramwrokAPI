using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoAPI.Models
{
    public class Employee
    {
        [Key]
        [StringLength(9)]
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

        // Clave externa para almacenar el ID del supervisor
        public string SupervisorId { get; set; }

        // Propiedad de navegación para representar al supervisor
        public virtual Employee Supervisor { get; set; }
    

    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string SupervisorSSN { get; set; }

        // Propiedad de navegación para representar al supervisor
        public virtual Employee Supervisor { get; set; }
        

        // Foreign key para la relación WorksFor
        [ForeignKey("Department")]
        public string DepartmentName { get; set; }
        [ForeignKey("Department")]
        public int DepartmentNumber { get; set; }
        // Propiedad de navegación para la relación WorksFor
        public virtual Department Department { get; set; }
    }
}

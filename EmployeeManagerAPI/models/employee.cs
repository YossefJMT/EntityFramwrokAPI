using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagerAPI.Models
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
        [StringLength(150)]
        public string Address { get; set; }

        public DateTime BirthDate { get; set; }
        
        public string FullName => $"{FirstName} {MiddleInitial} {LastName}";

        // Clave externa para almacenar el ID del supervisor
        public string? SupervisorSSN { get; set; }

        // Propiedad de navegación para representar al supervisor
        public virtual Employee? Supervisor { get; set; }

        // Notación de clave compuesta para la relación WorksFor
        public string DepartmentName { get; set; }
        public int DepartmentNumber { get; set; }
        public virtual Department? Department { get; set; }

        // Propiedad de navegación para la relación Manages
        public virtual Manage? Manages { get; set; }

        // Propiedad de navegación para la relación N:N (WorksOn)
        public virtual ICollection<WorksOn>? WorksOns { get; set; }

        // Propiedad de navegación para la relación 1:N con Dependent
        public virtual ICollection<Dependent>? Dependents { get; set; }
    }
}

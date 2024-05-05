using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagerAPI.Models
{
    public class Department
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }

        [StringLength(50)]
        public string Locations { get; set; }


        // Propiedad de navegación para la relación WorksFor
        public virtual ICollection<Employee>? Employees { get; set; }

        // Propiedad calculada para el número de empleados
        public int NumberOfEmployees => Employees?.Count ?? 0;    

        // Propiedad de navegación para la relación Manages
        public virtual Manage? Manages { get; set; }



        // Propiedad de navegación para la relación con Project
        public virtual ICollection<Project>? ControlledProjects { get; set; }
    }
}

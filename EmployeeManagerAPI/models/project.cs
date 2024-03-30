using System.ComponentModel.DataAnnotations;

namespace EmployeeManagerAPI.Models
{
    public class Project
    {
        [StringLength(50)]
        public string Name { get; set; } 

        [StringLength(50)]
        public int Number { get; set; } 
        
        public string Location { get; set; }


        // Propiedades para la relación con Department
        public string ControllingDepartmentName { get; set; }
        public int ControllingDepartmentNumber { get; set; }

        // Propiedad de navegación para la relación con Department
        public virtual Department ControllingDepartment { get; set; }

        // Propiedad de navegación para la relación N:N (WorksOn)
        public virtual ICollection<WorksOn> WorksOns { get; set; }
    }
}

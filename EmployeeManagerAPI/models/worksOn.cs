using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagerAPI.Models
{
    public class WorksOn
    {
        // Claves externas para Employee y Project
        public string EmployeeSSN { get; set; }
        public string ProjectName { get; set; }
        public int ProjectNumber { get; set; }

        // Propiedad de navegación para Employee
        public virtual Employee? Employee { get; set; }

        // Propiedad de navegación para Project
        public virtual Project? Project { get; set; }

        // Atributo de horas
        public int Hours { get; set; }
    }
}

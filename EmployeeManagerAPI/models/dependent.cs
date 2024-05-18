using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagerAPI.Models
{
    public class Dependent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DependentId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Relationship { get; set; }

        public string Sex { get; set; }

        public DateTime BirthDate { get; set; }

        // Clave externa para relacionar con Employee
        [Required]
        public string EmployeeSSN { get; set; }

        // Propiedad de navegación para Employee
        public virtual Employee Employee { get; set; }
    }
}

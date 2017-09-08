using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Departaments
    {   
        [Key]
        [Display(Name="Departamento")]
        public int DepartamentsId { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage ="O campo Nome é requerido!")]
        [Index("Departament_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
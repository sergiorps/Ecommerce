using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Departaments
    {   
        [Key]
        [Display(Name="Departamento")]
        public int DepartamentsId { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage ="O campo Nome é requerido!")]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
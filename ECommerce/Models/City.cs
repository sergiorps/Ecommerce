using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class City
    {
        [Key]
        public int Cityid { get; set; }

        [Required(ErrorMessage ="O campo {0} é requerido!")]
        [Display(Name = "Cidade")]
        public string Name { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "O campo {0} é requerido!")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione um Departamento")]
        public int DepartamentsId { get; set; }

        public virtual Departaments Departament { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class City
    {
        [Key]
        public int Cityid { get; set; }

        [Required(ErrorMessage ="O campo {0} é requerido!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido!")]
        public int DepartamentsId { get; set; }

        public virtual Departaments Departament { get; set; }
    }
}
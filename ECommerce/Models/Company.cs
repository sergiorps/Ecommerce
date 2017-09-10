using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ECommerce.Models
{
    public class Company
    {
        [Key]
        [Display(Name = "Companhia")]
        public int CompanyId { get; set; }

        [Display(Name = "Companhia")]
        [Required(ErrorMessage = "O campo Nome é requerido!")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres permitidos!")]
        [Index("Company_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo é requerido!")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres permitidos!")]
        //[Index("Company_Name_Index", IsUnique = true)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O campo é requerido!")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres permitidos!")]
        public string Address { get; set; }

        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }
        
        [Required(ErrorMessage = "O campo é requerido!")]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O campo é requerido!")]
        [Display(Name = "Cidade")]
        public int Cityid { get; set; }

        public virtual Departaments Departments { get; set; }
        public virtual City Cities { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDenuncias.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
      

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Obrigatorio informar seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar seu E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar seu Cpf")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar seu Telefone")]
        public string Telefone { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Obrigatorio informar sua senha")]
        public string Senha { get; set; }

        [Display(Name = "Administrador")]
        public bool IsAdmin { get; set; } = false;

        [Display(Name = "Em Perigo")]
        public bool EmPerigo { get; set; } = false; // Padrão é 'false'

        [Display(Name = "Latitude")]
        public double? Latitude { get; set; }

        [Display(Name = "Longitude")]
        public double? Longitude { get; set; }
    }
}
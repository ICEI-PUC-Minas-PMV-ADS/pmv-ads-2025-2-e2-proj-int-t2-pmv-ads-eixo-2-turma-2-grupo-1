using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDenuncias.Models
{

    [Table("Usuarios")]
    public class Usuario
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Obrigatorio informar seu nome")]
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



    }
}

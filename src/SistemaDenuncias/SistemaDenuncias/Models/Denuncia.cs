using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDenuncias.Models
{
    [Table("Denuncias")]
    public class Denuncia
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O tipo de denúncia é obrigatório.")]
        [StringLength(100)]
        public string TipoDenuncia { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(1000)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2, ErrorMessage = "Use a sigla do estado (ex: MG, SP).")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(100)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "A rua é obrigatória.")]
        [StringLength(150)]
        public string Rua { get; set; }

        // --- CAMPOS OPCIONAIS CORRIGIDOS ---
        // Adicionado '?' para indicar que estas strings podem ser nulas (opcionais).
        // Isso resolve o problema de validação que exigia o preenchimento.

        [StringLength(100)]
        public string? Bairro { get; set; }

        [StringLength(10)]
        public string? Numero { get; set; }

        [StringLength(200)]
        public string? Complemento { get; set; }

        [StringLength(9)]
        [Display(Name = "CEP")]
        public string? Cep { get; set; }

        // --- CAMPOS GERENCIADOS PELO SISTEMA ---
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }

        [Required]
        [StringLength(20)]
        public string Protocolo { get; set; }

        [Required]
        public StatusDenuncia Status { get; set; }

        // --- RELACIONAMENTO ---
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        // --- CAMPO PREENCHIDO PELO USUÁRIO ---
        [Display(Name = "Denúncia Anônima")]
        public bool DenunciaAnonima { get; set; }
    }

    public enum StatusDenuncia
    {
        Aberta,
        Analise,
        Fechada
    }
}
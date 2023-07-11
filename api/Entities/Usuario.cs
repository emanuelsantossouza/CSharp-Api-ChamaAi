using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiChamaAi.Entities
{
    public class Usuario
    {
        [Key]
        public uint Id { get; set; }

        [Required]
        [StringLength(60)]
        public string NomeCompleto { get; set; }

        [Required]
        [StringLength(11)]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime DataDNascimento { get; set; }

        [Required]
        public TipoUsuario tipo { get; set; }
        
        public string FotoDePerfil { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string ConfirmaSenha { get; set; }

        // public string Token {get; set;}
    }
    public enum TipoUsuario
    {
        Fundador,
        Cliente,
        Motoboy
    }
}

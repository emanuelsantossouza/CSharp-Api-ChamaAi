using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiChamaAi.Entities
{
    [Table("Sedes")]
    public class Sede
    {
        [Key]
        public uint Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public LatLng LocalizacaoSede { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string EnderecoNumero { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        public string SobreNos { get; set; }

        [Required]
        public string Cnpj { get; set; }

        public uint UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}

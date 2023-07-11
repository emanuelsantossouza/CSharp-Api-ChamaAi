using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using apiChamaAi.Entities;

namespace apiChamaAi.Entities
{
    [Table("Motoboys")]
    public class Motoboy : Usuario
    {
        [Required]
        public string NumeroDeIndentificacao { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public int EnderecoNumero { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public string Lincenca { get; set; }
        
        public uint SedeId { get; set; }
        [ForeignKey("SedeId")]
        public Sede Sede { get; set; }

        // public ICollection<Pedido> Pedidos { get; set; }
    }
}
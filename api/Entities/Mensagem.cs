using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiChamaAi.Entities
{
    public class Mensagem
    {
        [Key]
        public uint Id { get; set; }

        [Required]
        public string UsuarioDEnvio { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public string DataDEnvio { get; set; }
    }
}
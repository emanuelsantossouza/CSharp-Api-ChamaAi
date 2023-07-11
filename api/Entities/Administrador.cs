using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiChamaAi.Entities
{
    [Table("Administradores")]
    public class Administrador : Usuario
    {
        [Required]
        [StringLength(20)]
        public string Cpf { get; set; }

        [Required]
        public string Cnpj { get; set; }
    }
}

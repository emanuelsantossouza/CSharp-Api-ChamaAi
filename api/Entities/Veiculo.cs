using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using apiChamaAi.Entities;

namespace apiChamaAi.Entities
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public uint Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public string NumeroDChassis { get; set; }

        public uint MotoboyId { get; set; }
        [ForeignKey("MotoboyId")]
        public Motoboy Motoboy { get; set; }
    }
}
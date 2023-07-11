using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using apiChamaAi.Entities;

namespace apiChamaAi.Entities
{
    [Table("Clientes")]
    public class Cliente : Usuario
    {
        public string HistoricoPedidos { get; set; }

        public bool Favoritos { get; set; }
    }

}
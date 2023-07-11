using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace apiChamaAi.Entities
{
    [Table("Chats")]
    public class Chat
    {
        [Key]
        public uint Id { get; set; }
        public uint ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        public uint SedeId { get; set; }

        [ForeignKey("SedeId")]
        public Sede Sede { get; set; }

        public uint MensagemId { get; set; }

        [ForeignKey("MensagemId")]
        public Mensagem Mensagem { get; set; }
    }
}

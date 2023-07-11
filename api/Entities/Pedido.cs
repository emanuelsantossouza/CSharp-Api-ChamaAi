using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiChamaAi.Entities
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public uint Id { get; set; }

        public string EnderecoAtual { get; set; }

        public string NumeroAtual { get; set; }

        public string EstadoAtual { get; set; }

        public string EnderecoNumeroAtual { get; set; }

        public string EnderecoDestino { get; set; }

        public string NumeroDestino { get; set; }

        public string EstadoDestino { get; set; }

        public string EnderecoNumeroDestino { get; set; }

        public string TamanhoProduto { get; set; }

        public string PesoProduto { get; set; }

        public bool isFragil { get; set; }

        public string DescricaoProduto { get; set; }

        public string FormaDePagamento { get; set; }

        [Required]
        public LatLng LocalizacaoClienteOrigem { get; set; }

        [Required]
        public LatLng LocalizacaoClienteDestino { get; set; }

        [Required]
        public string HoraPedidoCliente { get; set; }

        public string HoraSaidaMotoboySede { get; set; }

        public string HoraChegadaMotoboyCliente { get; set; }

        public string HoraMotoboyEntregaCliente { get; set; }

        public int ValorAproximadoDaCorrida { get; set; }

        public EscolhaPedido QualServico { get; set; }

        public uint SedeId { get; set; }

        [ForeignKey("SedeId")]
        public Sede Sede { get; set; }

        public uint UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }

    public class LatLng
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class EscolhaPedido
    {
        public bool Corrida { get; set; }

        public bool Entrega { get; set; }
    }
}

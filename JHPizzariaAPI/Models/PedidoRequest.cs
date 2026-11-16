
namespace JHPizzariaAPI.Models
{
    public class PedidoRequest
    {
        public string Email { get; set; } = "";
        public List<ItemPedidoRequest> Itens { get; set; } = new();
    }

    public class ItemPedidoRequest
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}

namespace Comex.Models;

public class Pedido
{
    public Cliente Cliente { get; private set; }
    public DateTime DataDoPedido { get; private set; }
    public List<ItemDePedido> ItensDoPedido { get; private set; }
    public double ValorTotal { get; private set; }

    public Pedido(Cliente cliente)
    {
        Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        DataDoPedido = DateTime.Now;
        ItensDoPedido = new List<ItemDePedido>();
    }

    public void AdicionarItemAoPedido(ItemDePedido item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        ItensDoPedido.Add(item);
        ValorTotal += item.Subtotal;
    }

    public override string ToString()
    {
        return $"Cliente: {Cliente.Nome}, Data do Pedido: {DataDoPedido}, Valor Total: {ValorTotal:F2}";
    }
}

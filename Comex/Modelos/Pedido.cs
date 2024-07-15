namespace Comex.Modelos;

public class Pedido
{
    public Cliente Cliente { get; private set; }
    public DateTime Data { get; private set; }
    public List<ItemDePedido> Itens { get; private set; }

    public double Total { get; set; }


    public Pedido(Cliente cliente)
    {
        Cliente = cliente;
        Data = DateTime.Now;
        Itens = new List<ItemDePedido>();
    }

    public void AdicionarItem(ItemDePedido item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));
        Itens.Add(item);
        Total += item.Subtotal;
    }

    public override string ToString()
    {
        return $"Cliente: {Cliente.Nome}, Data: {Data}, Total: {Total:F2}";
    }
}

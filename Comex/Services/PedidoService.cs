using System;
using System.Collections.Generic;
using System.Linq;
using Comex.Models;

namespace Comex.Services
{
    public class PedidoService
    {
        private readonly List<Pedido> _pedidos;

        public PedidoService()
        {
            _pedidos = new List<Pedido>();
        }

        public void CriarPedido(Cliente cliente, List<ItemDePedido> itensDoPedido)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (itensDoPedido == null || !itensDoPedido.Any())
                throw new ArgumentException("A lista de itens do pedido não pode ser nula ou vazia.", nameof(itensDoPedido));

            var pedido = new Pedido(cliente);
            foreach (var item in itensDoPedido)
            {
                pedido.AdicionarItemAoPedido(item);
            }

            _pedidos.Add(pedido);
        }

        public List<Pedido> ListarPedidos()
        {
            return _pedidos;
        }

        public void LimparPedidos()
        {
            _pedidos.Clear();
        }
    }
}

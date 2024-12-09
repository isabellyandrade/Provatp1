using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTP1
{
    internal class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Dictionary<Produto, int> produtos = new Dictionary<Produto, int>();

        public Venda() { }
        public Venda(int id, Cliente cliente)
        {
            Id = id;
            Cliente = cliente;
        }

        public void AdicionarProduto(Produto produto)
        {

            if (produto == null)
            {
                Console.WriteLine("Produto inválido.");
                return;
            }

            if (produtos.ContainsKey(produto))
            {
                produtos[produto] ++;
            }
            else
            {
                produtos.Add(produto, 1);
            }

        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in produtos)
            {
                total += item.Key.Preco * item.Value;
            }
            return total;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTP1
{
    internal class VendaDAO
    {
        private List<Venda> vendaList = new List<Venda>();
        private int proximoId = 1;

        public void AdicionarVenda(Venda venda)
        {
            venda.Id = proximoId++;
            vendaList.Add(venda);
        }

        public Venda BuscarVenda(int idVenda)
        {
            return vendaList.FirstOrDefault(v => v.Id == idVenda);
        }

        public List<Venda> ListarVendas()
        {
            if (vendaList.Count == 0)
            {
                Console.WriteLine("Nenhuma venda cadastrada.");
            }

            Console.WriteLine("\n=== Lista de Vendas ===");
            foreach (var venda in vendaList)
            {
                Console.WriteLine($"Id da Venda: {venda.Id}, Valor Total: {venda.CalcularTotal():C}");
            }
            return vendaList;
        }

        public int TotalizarVendas()
        {
            return vendaList.Count;
        }

        public decimal TotalizarValores()
        {
            return vendaList.Sum(venda => venda.CalcularTotal());
        }
    }
}

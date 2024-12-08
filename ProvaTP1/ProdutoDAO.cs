using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTP1
{
    internal class ProdutoDAO
    {
        private List<Produto> produtoList = new List<Produto>();
        private List<Venda> vendaList = new List<Venda>();
        private int proximoId = 1;

        public void CadastrarProduto(Produto produto)
        {
            produto.Id = proximoId++;
            produtoList.Add(produto);
        }

        public Produto BuscarProduto(int id)
        {
            Produto produto = produtoList.Find(c => c.Id == id);

            if (produto != null)
            {
                return produto;
            }
            return null;
        }

        public List<Produto> ListarProdutos()
        {
            Console.WriteLine("\n=== Lista de Produtos ===");

            foreach (var produto in produtoList)
            {
                Console.WriteLine($"\nId do produto: {produto.Id}, Marca: {produto.Marca}, Modelo: {produto.Modelo}, Descricao: {produto.Descricao}, Preco: {produto.Preco}");
            }
            return produtoList;
        }
        public void DeletarProduto(int id)
        {
            var produto = BuscarProduto(id);
            if (produto != null)
            {
                bool produtoVenda = vendaList.Any(venda => venda.produtos.ContainsKey(produto));

                if (produtoVenda)
                {
                    Console.WriteLine("\nProduto não pode ser removido, pois está associado a uma venda.");
                }
                else
                {
                    produtoList.Remove(produto);
                    Console.WriteLine("\nProduto removido com sucesso.");
                }
            }
            else
            {
                Console.WriteLine("\nProduro não encontrado.");
            }
        }
    }
}

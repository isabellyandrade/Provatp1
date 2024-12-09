using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProvaTP1
{
    internal class Program
    {
        static ClienteDAO clienteDAO = new ClienteDAO();
        static ProdutoDAO produtoDAO = new ProdutoDAO();
        static VendaDAO vendaDAO = new VendaDAO();


        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("\n*** Menu: ***");
                Console.WriteLine("\n1. Cadastrar cliente");
                Console.WriteLine("2. Buscar cliente");
                Console.WriteLine("3. Listar clientes");
                Console.WriteLine("4. Deletar cliente");
                Console.WriteLine("5. Cadastrar produto");
                Console.WriteLine("6. Buscar produto");
                Console.WriteLine("7. Listar produtos");
                Console.WriteLine("8. Deletar produto");
                Console.WriteLine("9. Criar nova venda");
                Console.WriteLine("10. Buscar venda");
                Console.WriteLine("11. Listar vendas");
                Console.WriteLine("12. Totalizar vendas");
                Console.WriteLine("0. Sair");
                Console.WriteLine("\nEscolha uma opcao:");
                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        CadastrarCliente();
                        break;
                    case 2:
                        BuscarCliente();
                        break;
                    case 3:
                        clienteDAO.ListarClientes();
                        break;
                    case 4:
                        DeletarCliente();
                        break;
                    case 5:
                        CadastrarProduto();
                        break;
                    case 6:
                        BuscarProduto();
                        break;
                    case 7:
                        produtoDAO.ListarProdutos();
                        break;
                    case 8:
                        DeletarProduto();
                        break;
                    case 9:
                        CriarVenda();
                        break;
                    case 10:
                        BuscarVenda();
                        break;
                    case 11:
                        vendaDAO.ListarVendas();
                        break;
                    case 12:
                        TotalizarVenda();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opcao invalida");
                        break;
                }
            }
        }

        // CLIENTES
        static void CadastrarCliente()
        {
            Console.WriteLine("\n=== CADASTRO DE CLIENTES ===");
            Console.WriteLine("\nNome: ");
            String nome = Console.ReadLine();

            Console.WriteLine("Idade: ");
            int idade = int.Parse(Console.ReadLine());

            Console.WriteLine("CPF: ");
            double cpf = int.Parse(Console.ReadLine());


            var cliente = new Cliente
            {
                Nome = nome,
                Idade = idade,
                CPF = cpf
            };
            clienteDAO.CadastrarCliente(cliente);
            Console.WriteLine("\nCliente cadastrado com sucesso!");
        }

        static void BuscarCliente()
        {
            Console.WriteLine("\n=== BUSCAR CLIENTE ===");
            Console.WriteLine("\nInforme o ID do cliente: ");
            int id = int.Parse(Console.ReadLine());

            Cliente cliente = clienteDAO.BuscarCliente(id);

            if (cliente != null)
            {
                Console.WriteLine($"\nId do Cliente: {cliente.Id}, Nome: {cliente.Nome}, Idade: {cliente.Idade}, CPF: {cliente.CPF}");
            }
            else
            {
                Console.WriteLine("\nCliente nao encontrado!");
            }
        }

        static void DeletarCliente()
        {
            Console.WriteLine("\n=== DELETAR CLIENTE ===");
            Console.WriteLine("\nInforme o ID do cliente: ");
            int delete = 1;
            int id = int.Parse(Console.ReadLine());
            
            foreach (Venda v in vendaDAO.vendaList)
            {
                if(v.Id == id)
                {
                    delete = 0;
                    Console.WriteLine("\n=== ATENÇAO ===");
                    Console.WriteLine($"Ha uma venda para esse cliente, portanto nao podera ser removido");
                    break;
                }
            }
            if(delete == 1)
            {
                clienteDAO.DeletarCliente(id);
            }

        }

        // PRODUTOS
        static void CadastrarProduto()
        {
            Console.WriteLine("\n=== CADASTRO DE PRODUTOS ===");
            Console.WriteLine("\nMarca: ");
            String marca = Console.ReadLine();

            Console.WriteLine("Modelo: ");
            String modelo = Console.ReadLine();

            Console.WriteLine("Descricao: ");
            String descricao = Console.ReadLine();

            Console.WriteLine("Preco");
            decimal preco = int.Parse(Console.ReadLine());

            var produto = new Produto
            {
                Marca = marca,
                Modelo = modelo,
                Descricao = descricao,
                Preco = preco
            };
            produtoDAO.CadastrarProduto(produto);
            Console.WriteLine("\nProduto cadastrado com sucesso!");
        }

        static void BuscarProduto()
        {
            Console.WriteLine("\n=== BUSCAR PRODUTO ===");
            Console.WriteLine("\nInforme o ID do produto: ");
            int id = int.Parse(Console.ReadLine());

            Produto produto = produtoDAO.BuscarProduto(id);

            if (produto != null)
            {
                Console.WriteLine($"\nId do produto: {produto.Id}, Marca: {produto.Marca}, Modelo: {produto.Modelo}, Descricao: {produto.Descricao}, Preco: {produto.Preco}");
            }
            else
            {
                Console.WriteLine("\nProduto nao encontrado!");
            }
        }

        static void DeletarProduto()
        {
            Console.WriteLine("\n=== DELETAR PRODUTO ===");
            Console.WriteLine("\nInforme o ID do cliente: ");
            int id = int.Parse(Console.ReadLine());
            int delete = 1;

            foreach (Venda v in vendaDAO.vendaList)
            {
                if (v.Id == id)
                {
                    delete = 0;
                    Console.WriteLine("\n=== ATENÇAO ===");
                    Console.WriteLine($"Ha uma venda com esse produto, portanto nao podera ser removido");
                    break;
                }
            }
            if (delete == 1)
            {
                produtoDAO.DeletarProduto(id);
            }
        }

        // VENDAS

        static void CriarVenda()
        {
            Console.WriteLine("\n=== CRIAR VENDA ===");
            Console.Write("\nInforme o ID do cliente: ");
            int clienteId = int.Parse(Console.ReadLine());

            Cliente cliente = clienteDAO.BuscarCliente(clienteId);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            Venda novaVenda = new Venda(0, cliente); 

            Console.WriteLine("\nInforme os produtos:");
            while (true)
            {
                Console.Write("Informe o id do produto ou 0 para finalizar: ");
                int idProduto = int.Parse(Console.ReadLine());

                if (idProduto == 0)
                    break;

                Produto produto = produtoDAO.BuscarProduto(idProduto);
                if (produto == null)
                {
                    Console.WriteLine("Produto não encontrado.");
                    continue;
                }

                novaVenda.AdicionarProduto(produto);
            }
            if (!novaVenda.produtos.Any())
            {
                Console.WriteLine("\nNenhum produto foi selecionado. Venda cancelada.");
                return;
            }
            vendaDAO.AdicionarVenda(novaVenda);

            Console.WriteLine($"\nVenda realizada com sucesso! Id: {novaVenda.Id}, Cliente: {novaVenda.Cliente.Nome}");
            Console.WriteLine($"Total da venda: {novaVenda.CalcularTotal():C}");
        }
        static void BuscarVenda()
        {
            Console.WriteLine("\n=== BUSCAR VENDA ===");
            Console.Write("\nInforme o id da venda: ");
            int idVenda = int.Parse(Console.ReadLine());

            var vendaEncontrada = vendaDAO.BuscarVenda(idVenda);
            if (vendaEncontrada != null)
            {
                Console.WriteLine($"\n=== Detalhes da Venda ===");
                Console.WriteLine($"Id da venda: {vendaEncontrada.Id}");
                Console.WriteLine($"Cliente: {vendaEncontrada.Cliente.Nome}");
                Console.WriteLine("Produtos:");

                foreach (var produto in vendaEncontrada.produtos)
                {
                    Console.WriteLine($"- {produto.Key.Marca} {produto.Key.Modelo} (Quantidade: {produto.Value}, Preço: {produto.Key.Preco:C})");
                }
                Console.WriteLine($"Valor Total: {vendaEncontrada.CalcularTotal():C}");
            }
            else
            {
                Console.WriteLine("Venda não encontrada.");
            }
        }

        static void TotalizarVenda()
        {
            int totalVendas = vendaDAO.TotalizarVendas();
            decimal valorTotal = vendaDAO.TotalizarValores();

            Console.WriteLine("=== RELATORIO DE VENDAS ===");
            Console.WriteLine($"\nTotal de vendas: {totalVendas}");
            Console.WriteLine($"Valor total de vendas: {valorTotal:C}");
        }

    }
}

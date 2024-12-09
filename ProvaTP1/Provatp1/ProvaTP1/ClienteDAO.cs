    using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTP1
{
    internal class ClienteDAO
    {
        private List<Cliente> clienteList = new List<Cliente>();
        private VendaDAO vendaDAO = new VendaDAO();
        private int proximoId = 1;

        public void CadastrarCliente(Cliente cliente)
        {
            cliente.Id = proximoId++;
            clienteList.Add(cliente);
        }

        public Cliente BuscarCliente(int id)
        {
            Cliente cliente = clienteList.Find(c => c.Id == id);

            if (cliente != null)
            {
                return cliente;
            }
            return null;
        }

        public List<Cliente> ListarClientes()
        {

            if (clienteList.Count == 0)
            {
                Console.WriteLine("\nNenhum cliente cadastrado.");
            }

            Console.WriteLine("\n=== Lista de Clientes ===");

            foreach (var cliente in clienteList)
            {
                Console.WriteLine($"\nId do cliente: {cliente.Id}, Nome: {cliente.Nome}, Idade: {cliente.Idade}, CPF: {cliente.CPF}");
            }

            return clienteList;
        }
        public void DeletarCliente(int id)
        {
            var cliente = BuscarCliente(id);
            if (cliente != null)
            {
                clienteList.Remove(cliente);
                Console.WriteLine("Cliente removido com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }
    }
}

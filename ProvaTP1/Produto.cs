using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTP1
{
    internal class Produto
    {
        public int Id { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Descricao { get; set; }
        public decimal Preco { get; set; }

        public Produto() 
        {
            
        }

        public Produto(int id, String marca, String modelo, String descricao, decimal preco)
        {

            this.Id = id;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Descricao = descricao;
            this.Preco = preco;

        }
    }
}

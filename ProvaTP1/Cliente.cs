using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTP1
{
    internal class Cliente
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public int Idade { get; set; }
        public double CPF { get; set; }
        public bool TemVenda { get; set; }

        public Cliente()
        {

        }
        public Cliente(int id, String nome, int idade, double CPF)
        {
            this.Id = id;
            this.Nome = nome;
            this.Idade = idade;
            this.CPF = CPF;
            this.TemVenda = false;

        }
    }
}

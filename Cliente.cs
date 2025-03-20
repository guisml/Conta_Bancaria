using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Cliente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }

        public Cliente(string cpf, string nome)
        {
            Cpf = cpf;
            Nome = nome;
        }
    }
}

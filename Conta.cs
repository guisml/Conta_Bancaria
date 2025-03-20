using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; private set; }
        public Cliente Cliente { get; set; }

        public Conta(int numero, Cliente cliente)
        {
            Numero = numero;
            Cliente = cliente;
            Saldo = 0.0;
        }

        public void Depositar(double valor)
        {
            if (valor > 0)
                Saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if (valor > 0 && Saldo >= valor)
            {
                Saldo -= valor;
                return true;
            }
            return false;
        }

        public bool Transferir(Conta destino, double valor)
        {
            if (Sacar(valor))
            {
                destino.Depositar(valor);
                return true;
            }
            return false;
        }
    }
}

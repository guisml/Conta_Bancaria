using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static List<Conta> contas = new List<Conta>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Sistema Bancário ====");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Criar Conta");
                Console.WriteLine("3 - Depositar");
                Console.WriteLine("4 - Sacar");
                Console.WriteLine("5 - Transferir");
                Console.WriteLine("6 - Consultar Saldo");
                Console.WriteLine("7 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarCliente();
                        break;
                    case "2":
                        CriarConta();
                        break;
                    case "3":
                        Depositar();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Transferir();
                        break;
                    case "6":
                        ConsultarSaldo();
                        break;
                    case "7":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Pressione Enter para tentar novamente.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void CadastrarCliente()
        {
            Console.Write("Digite o CPF do cliente: ");
            string cpf = Console.ReadLine();

            // Verifica se CPF já existe
            if (clientes.Exists(c => c.Cpf == cpf))
            {
                Console.WriteLine("Erro: CPF já cadastrado!");
                Console.ReadLine();
                return;
            }

            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();

            clientes.Add(new Cliente(cpf, nome));
            Console.WriteLine("Cliente cadastrado com sucesso!");
            Console.ReadLine();
        }

        static void CriarConta()
        {
            Console.Write("Digite o CPF do cliente: ");
            string cpf = Console.ReadLine();

            Cliente cliente = clientes.Find(c => c.Cpf == cpf);
            if (cliente == null)
            {
                Console.WriteLine("Erro: Cliente não encontrado!");
                Console.ReadLine();
                return;
            }

            int numeroConta = contas.Count + 1;
            contas.Add(new Conta(numeroConta, cliente));

            Console.WriteLine($"Conta criada com sucesso! Número da conta: {numeroConta}");
            Console.ReadLine();
        }

        static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Conta conta = contas.Find(c => c.Numero == numero);
            if (conta == null)
            {
                Console.WriteLine("Erro: Conta não encontrada!");
                Console.ReadLine();
                return;
            }

            Console.Write("Digite o valor do depósito: ");
            double valor = double.Parse(Console.ReadLine());

            conta.Depositar(valor);
            Console.WriteLine("Depósito realizado com sucesso!");
            Console.ReadLine();
        }

        static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Conta conta = contas.Find(c => c.Numero == numero);
            if (conta == null)
            {
                Console.WriteLine("Erro: Conta não encontrada!");
                Console.ReadLine();
                return;
            }

            Console.Write("Digite o valor do saque: ");
            double valor = double.Parse(Console.ReadLine());

            if (conta.Sacar(valor))
                Console.WriteLine("Saque realizado com sucesso!");
            else
                Console.WriteLine("Erro: Saldo insuficiente!");

            Console.ReadLine();
        }

        static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int origem = int.Parse(Console.ReadLine());

            Conta contaOrigem = contas.Find(c => c.Numero == origem);
            if (contaOrigem == null)
            {
                Console.WriteLine("Erro: Conta de origem não encontrada!");
                Console.ReadLine();
                return;
            }

            Console.Write("Digite o número da conta de destino: ");
            int destino = int.Parse(Console.ReadLine());

            Conta contaDestino = contas.Find(c => c.Numero == destino);
            if (contaDestino == null)
            {
                Console.WriteLine("Erro: Conta de destino não encontrada!");
                Console.ReadLine();
                return;
            }

            Console.Write("Digite o valor da transferência: ");
            double valor = double.Parse(Console.ReadLine());

            if (contaOrigem.Transferir(contaDestino, valor))
                Console.WriteLine("Transferência realizada com sucesso!");
            else
                Console.WriteLine("Erro: Saldo insuficiente!");

            Console.ReadLine();
        }

        static void ConsultarSaldo()
        {
            Console.Write("Digite o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Conta conta = contas.Find(c => c.Numero == numero);
            if (conta == null)
            {
                Console.WriteLine("Erro: Conta não encontrada!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Saldo atual: R$ {conta.Saldo:F2}");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Conta.Banco
{
    class Program
    {
        static List<Conta> ListContas = new List<Conta>();
        static void Main(string[] args)
        {

            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1- Adicionar nova conta");
            Console.WriteLine("2- Listar contas");
            Console.WriteLine("3- Saques");
            Console.WriteLine("4- Transferencias");
            Console.WriteLine("5- Depositos");
            Console.WriteLine("X- Sair");

            string OpcaoDesejada = Console.ReadLine();
            Console.WriteLine();

            while (OpcaoDesejada.ToUpper() != "X")
            {
                switch (OpcaoDesejada)
                {
                    case "1":
                        InserirConta();
                    break;
                        
                    case "2":
                        Listar();
                    break;

                    case "3":
                        Sacar();
                    break;

                    case "4":
                        Transferir();
                    break;

                    case "5":
                       Depositar();
                    break;
                        
                    default:
                        throw new ArgumentOutOfRangeException("Digite uma opção válida");

                }
                Console.WriteLine();
                Console.WriteLine("Digite a opção desejada:");
                Console.WriteLine("1- Adicionar nova conta");
                Console.WriteLine("2- Listar contas");
                Console.WriteLine("3- Saques");
                Console.WriteLine("4- Transferencias");
                Console.WriteLine("5- Depositos");
                Console.WriteLine("X- Sair");

                OpcaoDesejada = Console.ReadLine();
            }
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite a conta para depósito");
            int IndiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o valor a ser depositado");
            double ValorDeposito = Convert.ToDouble(Console.ReadLine());

            ListContas[IndiceConta].Depositar(ValorDeposito);
        }

        private static void Transferir()
        {
            Console.WriteLine("Informe a conta origem");
            int IndiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a conta destino");
            int IndiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o valor a ser transferido");
            double ValorTransferencia = Convert.ToDouble(Console.ReadLine());

            ListContas[IndiceContaOrigem].Transferir(ValorTransferencia, ListContas[IndiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int IndiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double ValorSaque = double.Parse(Console.ReadLine());

            ListContas[IndiceConta].Sacar(ValorSaque);
        }

        private static void Listar()
        {
            if (ListContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            
            for (int i = 0; i < ListContas.Count; i++)
            {
                Conta c = ListContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(c);
            }                       
        }

        private static void InserirConta()
        {
                    Console.WriteLine("Adiciona nova conta");

                    Console.WriteLine("Qual o tipo da conta - 1 para Pessoa Fisica e 2 para Juridico:");
                    int entradaTipoConta = int.Parse(Console.ReadLine());

                    Console.WriteLine("Insira o nome da conta:");
                    string entradaNome = Console.ReadLine();

                    Console.WriteLine("Insira o saldo inicial");
                    double entradaSaldo = double.Parse(Console.ReadLine());

                    Console.WriteLine("Insira o valor de crédito da conta");
                    double entradaCredito = double.Parse(Console.ReadLine());

                    Conta NovaConta = new Conta(nome: entradaNome,
                                                tipoConta: (TipoConta)entradaTipoConta,
                                                saldo: entradaSaldo,
                                                credito: entradaCredito);

            ListContas.Add(NovaConta);
        }   
    }
}

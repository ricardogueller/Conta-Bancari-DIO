using System;
using System.Globalization;

namespace Conta.Banco
{
    public class Conta
    {
        //Atributos
        private string Nome { get; set; }
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
    
        //Métodos
        public Conta(string nome, TipoConta tipoConta, double saldo, double credito)
        {
            this.Nome = nome;
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;

        }
        public bool Sacar (double ValorSaque)
        {
            if (this.Saldo - ValorSaque < (this.Credito * -1))
            {
                Console.WriteLine ($"Seu saldo é insuficiente - Seu saldo atual é: {this.Saldo}");
                return false;
            }
            else
            {
                this.Saldo = Saldo - ValorSaque;

                Console.WriteLine();
                Console.WriteLine("Seu saldo atual é de: {0}", this.Saldo);
                return true;
            }

        }

        public void Depositar (double ValorDeposito)
        {
            this.Saldo = this.Saldo + ValorDeposito;

            Console.WriteLine();
            Console.WriteLine("Seu saldo atual é de: {0}", this.Saldo);
        }
        
        public void Transferir (double ValorTransferencia, Conta Destino)
        {
            if (this.Sacar(ValorTransferencia))
            {
                Destino.Depositar(ValorTransferencia);
            }
        }
        public override string ToString()
		{
            string retorno = "";
            retorno += "Tipo Conta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo.ToString("N2") + " | ";
            retorno += "Crédito " + this.Credito.ToString("N2");
			return retorno;
        }    
    }  
}
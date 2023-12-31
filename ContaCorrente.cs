﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bytebank.Titular;

namespace bytebank
{
    public  class ContaCorrente
    {
        private int numero_agencia;
        public int Numero_agencia
        {
            get
            {
                return numero_agencia;
            }
            private set
            {
                if(value > 0)
                {
                    this.numero_agencia = value;
                }
                
            }
        }

        //private string conta;
        public string Conta {get; set; }

        private double saldo;

        public Cliente Titular { get; set; }
        

        public void Depositar(double valor)
        {
            this.saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if(valor <= this.saldo)
            {
                this.saldo -= valor;
                return true;

            } else
            {
                Console.WriteLine("Saldo insuficiente, transação inválida!");
                return false;
            }
            
        }

        public bool Transferir(double valor, ContaCorrente destino)
        {
            if(this.saldo < valor)
            {
                return false;
            } else
            {
                this.Sacar(valor);
                destino.Depositar(valor);
                return true;
            }
        }   
        
        public void SetSaldo(double valor)
        {
            if(valor < 0)
            {
                return;
            }
            else
            {
                this.saldo = valor;
            }
        }

        public double GetSaldo()
        {
            return this.saldo;
        }

        public ContaCorrente(int numero_agencia, string numero_conta)
        {
            this.Numero_agencia = numero_agencia;
            this.Conta = numero_conta;
        }

    }


}

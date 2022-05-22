using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoCSharp.Enums;

namespace BancoCSharp.Models
{
    public abstract class ContaBancaria
    {
        #region Atributos
        public Titular Titular {get; set;}

        //Private - só a própria class pode aceder
        public double Saldo {get; private set;}

        public DateTime DataAbertura{get; private set;}

        protected List<Movimentacao>Movimentacoes{get; set;}

        protected readonly double VALOR_MINIMO = 0.01;
        #endregion

        #region Construtores
        public ContaBancaria(Titular titular, double saldoAbertura){
            Titular = titular;
            Saldo = saldoAbertura;
            DataAbertura = DateTime.Now;

            Movimentacoes = new List<Movimentacao>()
            {
                new Movimentacao(TipoMovimentacao.ABERTURA_CONTA, saldoAbertura)
            };
            //var movimentacao = new Movimentacao(TipoMovimentacao.ABERTURA_CONTA, saldoAbertura);
            //Movimentacoes.Add(new Movimentacao(TipoMovimentacao.ABERTURA_CONTA, saldoAbertura));
        }

        public ContaBancaria(Titular titular){
            Titular = titular;
            Saldo = 0;
            DataAbertura = DateTime.Now;
            Movimentacoes = new List<Movimentacao>()
            {
                new Movimentacao(TipoMovimentacao.ABERTURA_CONTA, Saldo)
            };
        }
        #endregion

        #region Métodos
        public void Depositar(double valor){
            if (valor < VALOR_MINIMO){
                throw new Exception("O valor mínimo para depósito é €" + VALOR_MINIMO);
            } else {
                Saldo += valor;
                Movimentacoes.Add(new Movimentacao(TipoMovimentacao.DEPOSITO, valor));
            }
        }
        public double Levantar (double valor){
            if (valor < VALOR_MINIMO){
                throw new Exception("O valor mínimo para levantamento é €" + VALOR_MINIMO);
            } else if(valor > Saldo){
                throw new Exception("Saldo Insuficiente para efetuar a operação. O seu saldo atual é de €" + Saldo);
            } else {
                Saldo -= valor;
                Movimentacoes.Add(new Movimentacao(TipoMovimentacao.LEVANTAMENTO, valor));
            }
            return valor;
        }
        public void Transferir(ContaBancaria contaDestino, double valor){
            if (valor < VALOR_MINIMO){
                throw new Exception("O valor mínimo para transferência é de €" + VALOR_MINIMO);
            } else if(valor > Saldo){
                throw new Exception("Saldo Insuficiente para efetuar a operação. O seu saldo atual é de €" + Saldo);
            } else {
                Saldo -= valor; 
                contaDestino.Depositar(valor);
                Movimentacoes.Add(new Movimentacao(TipoMovimentacao.TRANSFERENCIA, valor));
            }
        }
        public virtual void ImprimirExtrato(){
            System.Console.WriteLine("Imprimir Extrato.");
        }
        #endregion
    }
}
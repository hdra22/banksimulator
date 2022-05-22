using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoCSharp.Models
{
    public class ContaInvestimento : ContaBancaria
    {

        public double valorInvestido{get;private set;}
        public ContaInvestimento(Titular titular) 
        : base(titular)
        {
        }

        public ContaInvestimento(Titular titular, double saldoAbertura) 
        : base(titular, saldoAbertura)
        {
        }
        
        public override void ImprimirExtrato(){
            System.Console.WriteLine("*****************************************");
            System.Console.WriteLine("******** EXTRATO CONTA INVESTIMENTO *****");
            System.Console.WriteLine("*****************************************");
            System.Console.WriteLine();

            System.Console.WriteLine("Gerado em" + DateTime.Now);
            System.Console.WriteLine();

            foreach (var movimentacao in Movimentacoes)
            {
            System.Console.WriteLine(movimentacao.ToString());
            }

            System.Console.WriteLine("Saldo atual: €" + Saldo);
            System.Console.WriteLine();

            System.Console.WriteLine();
            System.Console.WriteLine("*****************************************");
            System.Console.WriteLine("************** FIM DO EXTRATO ***********");
            System.Console.WriteLine("*****************************************");
            System.Console.WriteLine();
        }
    }
}
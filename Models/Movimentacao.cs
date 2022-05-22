using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoCSharp.Enums;

namespace BancoCSharp.Models
{
    public class Movimentacao
    {
        private DateTime DataHoraMovimentacao{get;set;}
        private TipoMovimentacao TipoMovimentacao{get;set;} 
        private double Valor {get;set;}
        //22/05/2022 - 10:27 - LEVANTAMENTO -€100.0
        //22/05/2022 - 10:57 - DEPÓSITO      €200.0

        #region Construtor
        public Movimentacao(TipoMovimentacao tipoMovimentacao, double valor){
            DataHoraMovimentacao = DateTime.Now;
            TipoMovimentacao = tipoMovimentacao;
            Valor = valor;
        }
        #endregion

        #region Método
        public override string ToString()
        {
            var valor = (this.TipoMovimentacao == TipoMovimentacao.LEVANTAMENTO || 
                        this.TipoMovimentacao == TipoMovimentacao.TRANSFERENCIA)
                ? "-€" + Valor 
                : " €" + Valor; 
            return $"{DataHoraMovimentacao} | {TipoMovimentacao} | {valor}";
        }
        #endregion
    }
}
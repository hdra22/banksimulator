using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoCSharp.Models
{
    public class Titular
    {
        public string Nome{get; set;}

        public string NIF{get; set;}

        public string Telefone {get;set;}

        //o titular tem morada que é uma outra class
        public Morada Morada {get;set;}


        //CONSTRUTOR - o titular só poderá ser criada se receber os seguintes campos: 
        public Titular (string nome, string nif, string telefone){
            Nome = nome;
            NIF = nif;
            Telefone = telefone;
        }

        public Titular (string nome, string nif, string telefone, Morada morada){
            Nome = nome;
            NIF = nif;
            Telefone = telefone;
            Morada = morada;
        }
    }
}
// See https://aka.ms/new-console-template for more information
using BancoCSharp.Models;
using BancoCSharp.Enums;

System.Console.WriteLine("*******************************");
System.Console.WriteLine("********** BANCO CSHARP *******");
System.Console.WriteLine("*******************************");
System.Console.WriteLine();


var morada01= new Morada{
    Concelho = "Porto",
    Freguesia = "Ramalde",
    Rua = "Rua dos Carvalhos",
    NumeroPorta = 17
};

var titular01 = new Titular("José da Silva", "123456789", "912345678", morada01);
var titular02 = new Titular("Maria da Silva", "123456789", "912345699", morada01);

var conta01 = new ContaCorrente(titular01, 100.0);
var conta02 = new ContaInvestimento(titular02);
var conta03 = new ContaPoupanca(titular02);

conta01.Depositar(50.0);
conta02.Depositar(500.0);
conta02.Levantar(100.0);
conta02.Transferir(conta03, 100.0);
conta03.Levantar(25.0);

conta01.ImprimirExtrato();
conta02.ImprimirExtrato();
conta03.ImprimirExtrato();



/*var movimentacao01 = new Movimentacao(TipoMovimentacao.LEVANTAMENTO, 20);
var movimentacao02 = new Movimentacao(TipoMovimentacao.DEPOSITO, 50);

System.Console.WriteLine(movimentacao01);
System.Console.WriteLine(movimentacao02);

try{
    var valorLevantamento = conta01.Levantar(100);
    System.Console.WriteLine(valorLevantamento);
}
catch(System.Exception ex){
    System.Console.WriteLine(ex.Message);
}

try{
    conta01.Depositar(1);
}
catch(System.Exception ex){
    System.Console.WriteLine((ex.Message));
}

try{
    conta01.Transferir(conta02, 30);
}
catch(System.Exception ex){
    System.Console.WriteLine((ex.Message));
}


System.Console.WriteLine("O saldo da conta do " + titular01.Nome + " é de " + conta01.Saldo);
System.Console.WriteLine("O saldo da conta do " + titular02.Nome + " é de " + conta02.Saldo);

System.Console.WriteLine("Extrato conta01 ");
conta01.ImprimirExtrato();

System.Console.WriteLine("Extrato conta02 ");
conta02.ImprimirExtrato();*/
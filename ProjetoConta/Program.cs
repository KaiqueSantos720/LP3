Conta c1 = new Conta(1);
Conta c2 = new Conta(2);

c1.Depositar(500.00);
c1.Sacar(200.00);
Console.WriteLine("Saldo c1: {0}", c1.Saldo);

c2.Depositar(200.00);
c2.Sacar(150.00);
Console.WriteLine("Saldo c2: {0}", c2.Saldo);

c1.Transferir(300.00, c2);
Console.WriteLine("Saldo c1: {0}", c1.Saldo);
Console.WriteLine("Saldo c2: {0}", c2.Saldo);


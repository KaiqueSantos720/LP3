Console.WriteLine("Escreva seu nome");
string? name = Console.ReadLine();

Console.WriteLine("Escreva sua massa");
double massa = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Escreva sua altura");
double altura = Convert.ToDouble(Console.ReadLine());

Individuo i1 = new Individuo(name, massa, altura);
Console.WriteLine(i1.VerImc);
Console.WriteLine(i1.Classificacao());
Console.WriteLine(i1.PesoIdeal());
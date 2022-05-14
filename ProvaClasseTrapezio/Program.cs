Console.WriteLine("Entre com o lado 1 do Trapézio");
double lado1 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Entre com o lado 2 do Trapézio");
double lado2 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Entre com a altura do Trapézio");
double altura = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Entre com a base maior do Trapézio");
double baseMaior = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Entre com a base menor do Trapézio");
double baseMenor = Convert.ToDouble(Console.ReadLine());

Trapezio t1 = new Trapezio(lado1, lado2, altura, baseMaior, baseMenor);

Console.WriteLine("A área do trapézio é: " + t1.Area);
Console.WriteLine("O perímetro do trapézio é: " + t1.Perimetro);



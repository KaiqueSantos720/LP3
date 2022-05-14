public class Trapezio
{
    public double BaseMaior{get; set; }
    public double BaseMenor{get; set;}
    public double Altura {get; set;}

    public double Lado1 {get; set;}
    public double Lado2 {get; set;}
    
    public double Area{get =>((BaseMaior + BaseMenor) * Altura)/2;}
    public double Perimetro{get => BaseMaior + BaseMenor + Lado1 + Lado2;}

    public Trapezio(double lado1, double lado2, double altura, double baseMaior, double baseMenor)
    {
        Lado1 = lado1;
        Lado2 = lado2;
        Altura = altura;
        BaseMaior = baseMaior;
        BaseMenor = baseMenor;
    }
}
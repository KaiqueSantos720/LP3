public class Individuo
{
    public string? Nome {get; set;}
    public double Massa {get; set;}
    public double Altura {get; set;}
    public Individuo (string? nome, double massa, double altura)
    {
        Nome = nome;
        Massa = massa;
        Altura = altura;
    }
    public double Imc { get => (Massa/(Altura * Altura));}
    public string VerImc { get => "Olá " + Nome + " seu IMC é: " + Imc;}
    public double PerderPeso {get => Massa-(24.9*(Altura*Altura));}
    public double GanharPeso {get => (18.5*(Altura*Altura))-Massa;}

    public String Classificacao()
    {
        if(Imc < 17)
        {
            return "Classificação: Muito Abaixo do Peso";
        }

        else if(Imc >= 17 && Imc < 18.5)
        {
            return "Classificação: Abaixo do Peso";
        }

        else if(18.5 <= Imc && Imc <= 24.9)
        {
            return "Classificação: Peso Normal";
        }
            
        else if(25 <= Imc && Imc <= 29.9)
        {
            return "Classificação: Acima do Peso";
        }

        else if(30 <= Imc && Imc <= 34.9)
        {
            return "Classificação: Obesidade Grau I";
        }

        else if(35 <= Imc && Imc <= 39.9)
        {
            return "Classificação: Obesidade Grau II";
        }

        else
        {
            return "Classificação: Obesidade Mórbida";
        }
    }

    public String PesoIdeal()
    {
        if(Imc < 18.5)
        {
            return "Você precisa ganhar " + GanharPeso + " kg";
        }
        if (Imc >= 25)
        {
            return "Você precisa perder " + PerderPeso + " kg";
        }
        return "Você está com o peso ideal";
    }
}
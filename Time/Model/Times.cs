namespace Time.Model;

public class Times
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Titulos { get; set; }
    public string Estadio { get; set; }

    public Times(int id, string nome, int titulos, string estadio)
    {
        Id = id;
        Nome = nome;
        Titulos = titulos;
        Estadio = estadio;
    }

    public Times()
    {
        
    }
}
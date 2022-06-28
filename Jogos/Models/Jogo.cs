namespace Jogos.Models;
public class Jogo
{
    public int Id { get; set; } 
    public string Nome { get; set; }    
    public string Desenvolvedora { get; set; }
    public double Preco { get; set; }

    public Jogo () {}

    public Jogo (int id, string nome, string desenvolvedora, double preco) 
    {
        Id = id;
        Nome = nome;
        Desenvolvedora = desenvolvedora;
        Preco = preco;
    }
}
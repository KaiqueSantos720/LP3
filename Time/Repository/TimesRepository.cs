using Time.Database;
using Microsoft.Data.Sqlite;
using Time.Model;
namespace Time.Repository;

public class TimesRepository
{
    private readonly DatabaseConfig _databaseConfig;

    public TimesRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public void Criar(Times time)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Times VALUES($ID, $Nome, $Titulos, $Estadio)";

        command.Parameters.AddWithValue("$ID", time.Id);
        command.Parameters.AddWithValue("$Nome", time.Nome);
        command.Parameters.AddWithValue("$Titulos", time.Titulos);
        command.Parameters.AddWithValue("$Estadio", time.Estadio);

        command.ExecuteNonQuery();
        connection.Close();
        
    }

    public List<Times> PegarTudo()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Times";

        var reader = command.ExecuteReader();

        List<Times> times = new List<Times>();

        while (reader.Read())
        {
            Times time = new Times();
            time.Id = reader.GetInt32(0);
            time.Nome = reader.GetString(1);
            time.Titulos = reader.GetInt32(2);
            time.Estadio = reader.GetString(3);
            times.Add(time);
        }

        connection.Close();

        return times;
    }

    public void Update(Times time)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "UPDATE Times SET Nome = $nome, Titulos = $titulos, Estadio = $estadio WHERE ID = $id";

        command.Parameters.AddWithValue("$id", time.Id);
        command.Parameters.AddWithValue("$nome", time.Nome);
        command.Parameters.AddWithValue("$titulos", time.Titulos);
        command.Parameters.AddWithValue("$estadio", time.Estadio);

        command.ExecuteNonQuery();
        connection.Close();
    }

    public void Delete (int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Times WHERE ID = $id";
        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();

        connection.Close();
    }

}
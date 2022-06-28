namespace Jogos.Repositories;
using Jogos.Database;
using Jogos.Models;
using Microsoft.Data.Sqlite;
using Dapper;

public class JogosRepository
{
    
    private readonly DatabaseConfig _databaseConfig;

    public JogosRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public Jogo Save(Jogo jogo)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Jogos VALUES ($id, $nome, $desenvolvedora, $preco)";
        command.Parameters.AddWithValue("$id", jogo.Id);
        command.Parameters.AddWithValue("$nome", jogo.Nome);
        command.Parameters.AddWithValue("$desenvolvedora", jogo.Desenvolvedora);
        command.Parameters.AddWithValue("$preco", jogo.Preco);

        command.ExecuteNonQuery();
        connection.Close();

        return jogo;
    }

    public Jogo SaveDapper(Jogo jogo)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("INSERT INTO Jogos VALUES (@Id, @Nome, @Desenvolvedora, @Preco)", jogo);

        return jogo;
    }

    public List<Jogo> GetAll()
    {
        var jogos = new List<Jogo>();
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Jogos";

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            var jogo = Reader(reader);
            jogos.Add(jogo);
        }

        connection.Close();

        return jogos;

    }

    public IEnumerable<Jogo> GetAllDapper()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();
        
        var jogos = connection.Query<Jogo>("SELECT * FROM Jogos");

        return jogos;

    }

    public Jogo Update(Jogo jogo)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "UPDATE Jogos SET nome = $nome, desenvolvedora = $desenvolvedora, preco = $preco WHERE id = $id";
        command.Parameters.AddWithValue("$id", jogo.Id);
        command.Parameters.AddWithValue("$nome", jogo.Nome);
        command.Parameters.AddWithValue("$desenvolvedora", jogo.Desenvolvedora);
        command.Parameters.AddWithValue("$preco", jogo.Preco);

        command.ExecuteNonQuery();
        connection.Close();

        return jogo;

    }

    public Jogo UpdateDapper(Jogo jogo)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();
        
        connection.Execute("UPDATE Jogos SET nome = @Nome, desenvolvedora = @Desenvolvedora, preco = @Preco WHERE id = @Id", jogo);

        return jogo;

    }

    public Jogo GetById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Jogos WHERE id = $id";
        command.Parameters.AddWithValue("$id", id);

        var reader = command.ExecuteReader();
        reader.Read();
        var jogo = Reader(reader);

        connection.Close();

        return jogo;
    }

    public Jogo GetByIdDapper(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();
        
        var jogo = connection.QuerySingle<Jogo>("SELECT * FROM Jogos WHERE id = @Id", new {Id = id});

        return jogo;
    }

    public void Delete(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Jogos WHERE id = $id";
        command.Parameters.AddWithValue("$id", id);

        command.ExecuteNonQuery();
        connection.Close();

    }

    public void DeleteDapper(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("DELETE FROM Jogos WHERE id = @Id", new {Id = id});

    }

    public int QuantidadeJogos()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(*) FROM Jogos";

        var result = Convert.ToInt32(command.ExecuteScalar());
        connection.Close();

        return result;
    }

    public int QuantidadeJogosDapper()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var result = Convert.ToInt32(connection.ExecuteScalar("SELECT count(*) FROM Jogos"));

        return result;
    }

    public double MediaPreco()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT avg(preco) FROM Jogos";

        var result = Convert.ToDouble(command.ExecuteScalar());
        connection.Close();

        return result;
    }

    public double MediaPrecoDapper()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var result = Convert.ToDouble(connection.ExecuteScalar("SELECT avg(preco) FROM Jogos"));

        return result;
    }

    public double MaisCaro()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT max(preco) FROM Jogos";

        var result = Convert.ToDouble(command.ExecuteScalar());
        connection.Close();

        return result;
    }

    public double MaisCaroDapper()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var result = Convert.ToDouble(connection.ExecuteScalar("SELECT max(preco) FROM Jogos"));

        return result;
    }

    public double MaisBarato()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT min(preco) FROM Jogos";

        var result = Convert.ToDouble(command.ExecuteScalar());
        connection.Close();

        return result;
    }

    public double MaisBaratoDapper()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var result = Convert.ToDouble(connection.ExecuteScalar("SELECT min(preco) FROM Jogos"));

        return result;
    }

    public bool VerificarExistencia(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(id) FROM Jogos WHERE id = $id";
        command.Parameters.AddWithValue("$id", id);

        var result = Convert.ToBoolean(command.ExecuteScalar());
        connection.Close();

        return result;
    }

    public bool VerificarExistenciaDapper(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var result = Convert.ToBoolean(connection.ExecuteScalar("SELECT count(id) FROM Jogos WHERE id = @Id", new{Id = id}));

        return result;
    }

    private Jogo Reader(SqliteDataReader reader)
    {
        var jogo = new Jogo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3));
        return jogo;
    }

}
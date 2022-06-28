namespace Jogos.Database;
using Microsoft.Data.Sqlite;

public class DatabaseSetup
{
    private readonly DatabaseConfig _databaseConfig;
    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
        CriarTabelaJogos();
    }

    private void CriarTabelaJogos()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Jogos(
                id int not null primary key,
                nome varchar(30) not null,
                desenvolvedora varchar(30) not null,
                preco double precision not null
            )
        ";

        command.ExecuteNonQuery();
        connection.Close();
    }
}
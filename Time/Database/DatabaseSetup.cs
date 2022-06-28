using Microsoft.Data.Sqlite;

namespace Time.Database;

public class DatabaseSetup
{
    private readonly DatabaseConfig _databaseConfig;
    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
        CriarTimes();
    }

    private void CriarTimes()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        connection.Open();
        var command = connection.CreateCommand();

        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Times (
                ID INT NOT NULL PRIMARY KEY,
                Nome VARCHAR(100) NOT NULL,
                Titulos INT NOT NULL,
                Estadio VARCHAR(100) NOT NULL
            );
        ";

        command.ExecuteNonQuery();

        connection.Close();
    }
}
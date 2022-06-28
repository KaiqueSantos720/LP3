using Microsoft.Data.Sqlite;
using Time.Database;
using Time.Model;
using Time.Repository;

var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);
var repository = new TimesRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Times")
{
    if(modelAction == "New")
    {
        Times time = new Times(Convert.ToInt32(args[2]), args[3], Convert.ToInt32(args[4]), args[5]);

        repository.Criar(time);

        Console.WriteLine("Time Criado!");
    }

    if(modelAction == "List")
    {
        foreach (var time in repository.PegarTudo())
        {
            Console.WriteLine($"{time.Id}, {time.Nome}, {time.Titulos}, {time.Estadio}");
        }
    }

    if(modelAction == "Update")
    {
        Times time = new Times(Convert.ToInt32(args[2]), args[3], Convert.ToInt32(args[4]), args[5]);

        repository.Update(time);

        Console.WriteLine("Time Atualizado!");
    }

    if(modelAction == "Delete")
    {
        repository.Delete(Convert.ToInt32(args[2]));
        Console.WriteLine("Time Deletado");
    }
}




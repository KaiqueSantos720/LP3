using Jogos.Database;
using Jogos.Models;
using Jogos.Repositories;

var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);

var jogosRepository = new JogosRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];
bool dapper = Convert.ToBoolean(args[2]);

if(modelName == "Jogo")
{
    if(modelAction == "New")
    {
        if (!dapper)
        {
            if(jogosRepository.VerificarExistencia(Convert.ToInt32(args[3])))
            {
                Console.WriteLine("Jogo já foi cadastrado no banco");
            }
            else
            {
                Console.WriteLine("New");
                var jogo = new Jogo(Convert.ToInt32(args[3]), args[4], args[5], Convert.ToDouble(args[6]));
                jogosRepository.Save(jogo);
                Console.WriteLine("Jogo cadastrado no banco");
            }
        }
        else
        {
            if(jogosRepository.VerificarExistenciaDapper(Convert.ToInt32(args[3])))
            {
                Console.WriteLine("Jogo já foi cadastrado no banco - Dapper");
            }
            else
            {
                Console.WriteLine("New - Dapper");
                var jogo = new Jogo(Convert.ToInt32(args[3]), args[4], args[5], Convert.ToDouble(args[6]));
                jogosRepository.SaveDapper(jogo);
                Console.WriteLine("Jogo cadastrado no banco - Dapper");
            }
        }
    }

    if(modelAction == "List")
    {
        if (!dapper)
        {
            Console.WriteLine("List");
            foreach(var jogo in jogosRepository.GetAll())
            {
                Console.WriteLine($"{jogo.Id} - {jogo.Nome} - {jogo.Desenvolvedora} - {jogo.Preco}");
            }
        }
        else
        {
            Console.WriteLine("List - Dapper");
            foreach(var jogo in jogosRepository.GetAllDapper())
            {
                Console.WriteLine($"{jogo.Id} - {jogo.Nome} - {jogo.Desenvolvedora} - {jogo.Preco}");
            }
        }
    }

    if(modelAction == "Show")
    {
        if (!dapper)
        {
            if(jogosRepository.VerificarExistencia(Convert.ToInt32(args[3])))
            {
                Console.WriteLine("Show");
                var jogo = jogosRepository.GetById(Convert.ToInt32(args[3]));
                Console.WriteLine($"{jogo.Id} - {jogo.Nome} - {jogo.Desenvolvedora} - {jogo.Preco}");
            }
            else
            {
                Console.WriteLine("Jogo não existe no banco");
            }
        }
        else
        {
            if(jogosRepository.VerificarExistenciaDapper(Convert.ToInt32(args[3])))
            {
                Console.WriteLine("Show - Dapper");
                var jogo = jogosRepository.GetByIdDapper(Convert.ToInt32(args[3]));
                Console.WriteLine($"{jogo.Id} - {jogo.Nome} - {jogo.Desenvolvedora} - {jogo.Preco}");
            }
            else
            {
                Console.WriteLine("Jogo não existe no banco - Dapper");
            }
        }
    }

    if(modelAction == "Update")
    {
        if(!dapper)
        {
            if(jogosRepository.VerificarExistencia(Convert.ToInt32(args[3])))
            {
                Console.WriteLine("Update");
                var jogo = new Jogo(Convert.ToInt32(args[3]), args[4], args[5], Convert.ToDouble(args[6]));
                jogosRepository.Update(jogo);
                Console.WriteLine("Jogo atualizado no banco");
            }
            else
            {
                Console.WriteLine("Jogo não existe no banco");
            }
        }
        else
        {
            if(jogosRepository.VerificarExistenciaDapper(Convert.ToInt32(args[3])))
            {
                Console.WriteLine("Update - Dapper");
                var jogo = new Jogo(Convert.ToInt32(args[3]), args[4], args[5], Convert.ToDouble(args[6]));
                jogosRepository.UpdateDapper(jogo);
                Console.WriteLine("Jogo atualizado no banco - Dapper");
            }
            else
            {
                Console.WriteLine("Jogo não existe no banco - Dapper");
            }
        }
    }

    if(modelAction == "Delete")
    {
        if (!dapper)
        {
            if(jogosRepository.VerificarExistencia(Convert.ToInt32(args[3])))
            {
                Console.WriteLine("Delete");
                jogosRepository.Delete(Convert.ToInt32(args[3]));
                Console.WriteLine("Jogo deletado");
            }
            else
            {
                Console.WriteLine("Jogo não existe no banco");
            }
        }
        else
        {
            if(jogosRepository.VerificarExistenciaDapper(Convert.ToInt32(args[3])))
            {
                Console.WriteLine("Delete - Dapper");
                jogosRepository.DeleteDapper(Convert.ToInt32(args[3]));
                Console.WriteLine("Jogo deletado - Dapper");
            }
            else
            {
                Console.WriteLine("Jogo não existe no banco - Dapper");
            }
        }
    }

    if(modelAction == "Count")
    {
        if (!dapper)
        {
            Console.WriteLine("Quantidade de Jogos");
            Console.WriteLine(jogosRepository.QuantidadeJogos());
        }
        else
        {
            Console.WriteLine("Quantidade de Jogos - Dapper");
            Console.WriteLine(jogosRepository.QuantidadeJogosDapper());
        }
    }

    if(modelAction == "Avg")
    {
        if (!dapper)
        {
            if(jogosRepository.QuantidadeJogos() == 0)
            {
                Console.WriteLine("Não há dados no banco");
            }
            else
            {
                Console.WriteLine("Média dos Preços");
                Console.WriteLine(jogosRepository.MediaPreco());
            }
        }
        else
        {
            if(jogosRepository.QuantidadeJogosDapper() == 0)
            {
                Console.WriteLine("Não há dados no banco - Dapper");
            }
            else
            {
                Console.WriteLine("Média dos Preços - Dapper");
                Console.WriteLine(jogosRepository.MediaPrecoDapper());
            }
        }
    }

    if(modelAction == "Max")
    {
        if (!dapper)
        {
            if(jogosRepository.QuantidadeJogos() == 0)
            {
                Console.WriteLine("Não há dados no banco");
            }
            else
            {
                Console.WriteLine("Preço Mais Caro");
                Console.WriteLine(jogosRepository.MaisCaro());
            }
        }
        else
        {
            if(jogosRepository.QuantidadeJogosDapper() == 0)
            {
                Console.WriteLine("Não há dados no banco - Dapper");
            }
            else
            {
                Console.WriteLine("Preço Mais Caro - Dapper");
                Console.WriteLine(jogosRepository.MaisCaroDapper());
            }
        }
    }

    if(modelAction == "Min")
    {
        if (!dapper)
        {
            if(jogosRepository.QuantidadeJogos() == 0)
            {
                Console.WriteLine("Não há dados no banco");
            }
            else
            {
                Console.WriteLine("Preço Mais Barato");
                Console.WriteLine(jogosRepository.MaisBarato());
            }
        }
        else
        {
            if(jogosRepository.QuantidadeJogosDapper() == 0)
            {
                Console.WriteLine("Não há dados no banco - Dapper");
            }
            else
            {
                Console.WriteLine("Preço Mais Barato - Dapper");
                Console.WriteLine(jogosRepository.MaisBaratoDapper());
            }
        }
    }

    
}
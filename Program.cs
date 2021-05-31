using System;

namespace DIO.Series
{
  class Program
  {
    static SeriesRepository repository = new SeriesRepository();
    static void Main(string[] args)
    {
      string userOption = getUserOption();

      while (userOption.ToUpper() != "X")
      {
        switch (userOption)
        {
          case "1":
            listSeries();
            break;
          case "2":
            insertSerie();
            break;
          case "3":
            updateSerie();
            break;
          case "4":
            deleteSerie();
            break;
          case "5":
            printSerie();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        userOption = getUserOption();
      }

      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.ReadLine();
    }

    private static void deleteSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());
      repository.Delete(indiceSerie);
    }

    private static void printSerie()
    {
      Console.Write("Digite o id da série: ");
      int indexSerie = int.Parse(Console.ReadLine());
      var serie = repository.GetById(indexSerie);
      Console.WriteLine(serie);
    }

    private static void updateSerie()
    {
      Console.Write("Digite o id da série: ");
      int indexSerie = int.Parse(Console.ReadLine());
      foreach (int i in Enum.GetValues(typeof(Gender)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
      }
      Console.Write("Digite o gênero entre as opções acima: ");
      int inputGender = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      string inputTitle = Console.ReadLine();

      Console.Write("Digite o Ano de Início da Série: ");
      int inputYear = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      string inputDescription = Console.ReadLine();

      Serie changeSeries = new Serie(id: indexSerie,
                    gender: (Gender)inputGender,
                    title: inputTitle,
                    year: inputYear,
                    description: inputDescription);
      repository.Update(indexSerie, changeSeries);
    }
    private static void listSeries()
    {
      Console.WriteLine("Listar séries");
      var serieslist = repository.Show();

      if (serieslist.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada.");
        return;
      }

      foreach (var serie in serieslist)
      {
        var deleted = serie.returnExcluded();
        Console.WriteLine("#ID {0}: - {1} {2}", serie.returnID(), serie.returnTitle(), (deleted ? "*Excluído*" : ""));
      }
    }

    private static void insertSerie()
    {
      Console.WriteLine("Inserir nova série");

      foreach (int i in Enum.GetValues(typeof(Gender)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
      }
      Console.Write("Digite o gênero entre as opções acima: ");
      int inputGender = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      string inputTitle = Console.ReadLine();

      Console.Write("Digite o Ano de Início da Série: ");
      int inputYear = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      string inputDescription = Console.ReadLine();

      Serie newSerie = new Serie(
                    id: repository.NextId(),
                    gender: (Gender)inputGender,
                    title: inputTitle,
                    year: inputYear,
                    description: inputDescription);
      repository.Insert(newSerie);
    }
    private static string getUserOption()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Séries a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar séries");
      Console.WriteLine("2- Inserir nova série");
      Console.WriteLine("3- Atualizar série");
      Console.WriteLine("4- Excluir série");
      Console.WriteLine("5- Visualizar série");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string userOption = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return userOption;
    }
  }
}
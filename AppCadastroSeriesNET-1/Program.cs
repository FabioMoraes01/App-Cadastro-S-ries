using System;

namespace DIO.Series
{
    class Program
    {
      static SerieRepositorio repositorio = new SerieRepositorio();
      

      static void Main(string[] args)
      {
        int totalSeries = 0;

        int continuar=1;
        int escolhaUsuario = ObterOpcaoUsuario2();
			  while (continuar!=0)
			  {
          Console.WriteLine("\nSeries Cadastradas: "+totalSeries);
          //string opcaoUsuario = ObterOpcaoUsuario();
          //int escolhaUsuario = ObterOpcaoUsuario2();          
          continuar=0;
          
				  switch (escolhaUsuario)
				  {
            case 1:
              ListarSeries();
              continuar=1;
              break;
            case 2:
              totalSeries = InserirSerie(totalSeries);
              continuar=1;
              break;
            case 3:
              AtualizarSerie(totalSeries);
              continuar=1;
              break;
            case 4:
              ExcluirSerie(totalSeries
              );
              continuar=1;
              break;
            case 5:
              VisualizarSerie(totalSeries);
              continuar=1;
              break;
            case 6:
              Console.Clear();
              continuar=1;
              break;
            case 7:
              Console.WriteLine("Escolha: "+escolhaUsuario);
              continuar=0;
              break;
            //default:
              //throw new ArgumentOutOfRangeException();
				  }
          //Console.WriteLine("Series Cadastradas: "+totalSeries);

				  escolhaUsuario = ObterOpcaoUsuario2();
			  }

			  Console.WriteLine("Obrigado por utilizar nossos serviços.");
			  Console.ReadLine();
      }

      private static void ExcluirSerie(int totalSeries)
		  {
			  Console.Write("Digite o id da série a ser excluida: ");
			  int indiceSerie = int.Parse(Console.ReadLine());
        if(totalSeries>0 && indiceSerie<totalSeries)
			    repositorio.Exclui(indiceSerie);
        else{
          Console.Write("\nIndice invalido!\n");
        }
		  }

      private static void VisualizarSerie(int totalSeries)
		  {
			  Console.Write("Digite o id (válido) da série: ");
			  int indiceSerie = int.Parse(Console.ReadLine());

        if(totalSeries>0 && indiceSerie<totalSeries){
          var serie = repositorio.RetornaPorId(indiceSerie);
          Console.WriteLine(serie);
        }else{
          Console.WriteLine("\nVocê digitou um id inválido!\n");
        }
		  }

      private static void AtualizarSerie(int totalSeries)
		  {
			  Console.Write("Digite o id (válido) da série: ");
			  int indiceSerie = int.Parse(Console.ReadLine());

			  // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			  // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
        if(totalSeries>0 && indiceSerie<totalSeries)
        {
          foreach (int i in Enum.GetValues(typeof(Genero)))
          {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
          }
          Console.Write("Digite o gênero entre as opções acima: ");
          int entradaGenero = int.Parse(Console.ReadLine());  

          Console.Write("Digite o Título da Série: ");
          string entradaTitulo = Console.ReadLine();

          Console.Write("Digite o Ano de Início da Série: ");
          int entradaAno = int.Parse(Console.ReadLine());

          Console.Write("Digite a Descrição da Série: ");
          string entradaDescricao = Console.ReadLine();

          // Atualizar a série
          Serie atualizaSerie = new Serie(id: indiceSerie,
                      genero: (Genero)entradaGenero,
                      titulo: entradaTitulo,
                      ano: entradaAno,
                      descricao: entradaDescricao);

          repositorio.Atualiza(indiceSerie, atualizaSerie);
        }else{
          Console.WriteLine("\nVocê digitou um id inválido!\n");
        }
		  }

      private static void ListarSeries()
		  {
			  Console.WriteLine("Listar séries");

			  var lista = repositorio.Lista();

			  if (lista.Count == 0)
			  {
				  Console.WriteLine("Nenhuma série cadastrada.");
				  return;
			  }

        foreach (var serie in lista)
        {
                  var excluido = serie.retornaExcluido();
                  
          Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
        }
        //Console.WriteLine("Series Cadastradas: "+totalSeries);
		  }

      private static int InserirSerie(int totalSeries)
      {
        Console.WriteLine("Inserir nova série");

        // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
        // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
          Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título da Série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Início da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da Série: ");
        string entradaDescricao = Console.ReadLine();

        Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                      genero: (Genero)entradaGenero,
                      titulo: entradaTitulo,
                      ano: entradaAno,
                      descricao: entradaDescricao);

        repositorio.Insere(novaSerie);
        return totalSeries+1;
      }

      private static string ObterOpcaoUsuario()
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

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
      }

      private static int ObterOpcaoUsuario2()
      {
        int continuar=0;
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
        Console.WriteLine("Cuidado: certas entradas inválidas podem finalizar o programa!");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();

				switch (opcaoUsuario)
				{
            case "1":
              continuar=1;
              break;
            case "2":
              continuar=2;
              break;
            case "3":
              continuar=3;
              break;
            case "4":
              continuar=4;
              break;
            case "5":
              continuar=5;
              break;
            case "C":
              continuar=6;
              break;
            case "X":
              continuar=7;
              break;
            //default:
              //throw new ArgumentOutOfRangeException();
				}

        Console.WriteLine();
        return continuar;
      }
      
    }
}
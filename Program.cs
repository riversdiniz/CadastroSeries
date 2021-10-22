//Professor: Eliézer Zarpelão
//digital innovation ONE
//https://github.com/elizarp

using System;

namespace CadastroSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("OBRIGADO POR UTILIZAR NOSSOS SERVIÇOS.");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("DIGITE O ID DA SÉRIE: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Excluir(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("DIGITE O ID DA SÉRIE: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("DIGITE O ID DA SÉRIE: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("DIGITE O GÊNERO ENTRE AS OPÇÕES ACIMA: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("DIGITE O TÍTULO DA SÉRIEe: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("DIGITE O ANO DE INÍCIO DA SÉRIE: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("DIGITE A DESCRIÇÃO DA SÉRIE: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("LISTAR SÉRIES");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("NENHUMA SÉRIE CADASTRADA.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();          
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("INSERIR NOVA SÉRIE");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("DIGITE O GÊNERO ENTRE AS OPÇÕES ACIMA: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("DIGITE O TÍTULO DA SÉRIE: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("DIGITE O ANO DE INÍCIO DA SÉRIE: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("DIGITE A DESCRIÇÃO DA SÉRIE: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("SÉRIES. A TELINHA TEM CADA VEZ MAIS DIVERSÃO!!!");
			Console.WriteLine("INFORME A OPÇÃO DESEJADA:");

			Console.WriteLine(" 1 - LISTAR SÉRIES");
			Console.WriteLine(" 2 - INSERIR NOVA SÉRIES");
			Console.WriteLine(" 3 - ATUALIZAR SÉRIE");
			Console.WriteLine(" 4 - EXCLUIR SÉRIE");
			Console.WriteLine(" 5 - VISUALIZAR SÉRIE");
			Console.WriteLine(" C - LIMPAR A TELA");
			Console.WriteLine(" X - SAIR, OBRIGADO!");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}

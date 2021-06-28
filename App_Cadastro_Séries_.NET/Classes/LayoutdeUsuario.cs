using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Cadastro_Séries_.NET
{
    public class LayoutdeUsuario
    {
        static string OpcoesUsuario()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine("Bem vindo InnovationFix!!!");
            Console.WriteLine("Informe a opção desejada: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n\n1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.ResetColor();
            return opcaoUsuario;
        }

        public static void Menu(SerieRepositorio SR)
        {
            do
            {
                switch (OpcoesUsuario())
                {
                    case "1":
                        ListarSeries(SR);
                        break;
                    case "2":
                        InserirSerie(SR);
                        break;
                    case "3":
                        AtualizarSerie(SR);
                        break;
                    case "4":
                        ExcluirSeries(SR);
                        break;
                    case "5":
                        VisualizarSerie(SR);
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }

            }
            while (OpcoesUsuario() != "X");
        }

        static void ListarSeries(SerieRepositorio repositorio)
        {
            Console.WriteLine("Listar séries \n");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            //foreach (var serie in lista)
            //{
            //	var excluido = serie.retornaExcluido();

            //	Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            //}
        }
        static void InserirSerie(SerieRepositorio repositorio)
        {
            Console.WriteLine("Inserir nova série \n");


            ListagemGeneros();
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                descricao: entradaDescricao,
                ano: entradaAno);


            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie(SerieRepositorio repositorio)
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            ListagemGeneros();

            Console.WriteLine("Inserir nova série \n");


            ListagemGeneros();
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                descricao: entradaDescricao,
                ano: entradaAno);


            repositorio.Insere(novaSerie);


            repositorio.Atualiza(indiceSerie,novaSerie);
        }

        static void ExcluirSeries(SerieRepositorio repositorio)
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie(SerieRepositorio repositorio)
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            object serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        static void ListagemGeneros()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
        }



    }
}

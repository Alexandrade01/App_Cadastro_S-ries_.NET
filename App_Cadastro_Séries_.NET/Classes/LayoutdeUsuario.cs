using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Cadastro_Séries_.NET
{

    public class LayoutdeUsuario
    {
        static SerieRepositorio Acervo = new SerieRepositorio();
        static string OpcoesUsuario()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;


            Console.WriteLine("Bem vindo InnovationFix!!!");
            Console.WriteLine("Informe a opção desejada: ");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("6 - Listar séries excluidas");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();



            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.ResetColor();
            return opcaoUsuario;
        }




        public static void Menu()
        {
            string resp = string.Empty;
            do
            {

                try
                {

                    resp = OpcoesUsuario();
                    switch (resp)
                    {
                        case "1":
                            ListarSeries(Acervo, false);
                            break;
                        case "2":
                            InserirSerie(Acervo);
                            break;
                        case "3":
                            AtualizarSerie(Acervo);
                            break;
                        case "4":
                            ExcluirSeries(Acervo);
                            break;
                        case "5":
                            VisualizarSerie(Acervo);
                            break;
                        case "6":
                            ListarSeries(Acervo, true);
                            break;
                        case "C":
                            Console.Clear();
                            break;

                        default:
                            throw new DomainExceptions("Opção Invalida !");

                    }

                }
                catch (DomainExceptions e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("ERRO " + e.Message);
                    Console.WriteLine();
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("ERRO " + e.Message);
                    Console.WriteLine();
                    Console.ResetColor();
                }
                finally
                {

                    Console.ReadKey();
                    Console.Clear();
                }

            }
            while (resp != "X" || string.IsNullOrEmpty(resp));
        }

        static void ListarSeries(SerieRepositorio repositorio, bool utilizaveis)
        {
            Console.WriteLine("Listar séries \n");

            var listagem = repositorio.Lista();

            if (listagem.Count == 0)
            {
                throw new DomainExceptions("Lista Vazia!");
            }

            foreach (var serie in listagem)
            {
                Console.ForegroundColor = (ConsoleColor)serie.RetornaGenero();
                if (serie.ItemExcluido() == utilizaveis) { Console.WriteLine($"#ID {serie.RetornaId()}  Titulo: {serie.RetornaTitulo()}"); }
                Console.ResetColor();
            }
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

            Serie novaSerie = new Serie(Acervo.ProximoId(), 
                genero: (Genero)entradaGenero,
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

            Serie novaSerie = new Serie(Acervo.ProximoId(), 
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                descricao: entradaDescricao,
                ano: entradaAno);


            repositorio.Insere(novaSerie);


            repositorio.Atualiza(indiceSerie, novaSerie);
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

            Serie serie = repositorio.RetornaPorId(indiceSerie);
            Console.ForegroundColor = (ConsoleColor)serie.RetornaGenero();
            Console.WriteLine(serie);
            Console.ResetColor();
        }
        static void ListagemGeneros()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {

                Console.ForegroundColor = (ConsoleColor)i;
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                Console.ResetColor();
            }
        }



    }
}

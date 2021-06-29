using System;
using System.Collections.Generic;
using System.IO;

namespace App_Cadastro_Séries_.NET
{

    public class LayoutdeUsuario
    {
        static SerieRepositorio Acervo = new SerieRepositorio();

        /// <summary>
        /// Inicialização do Layout
        /// </summary>
        public static void Inicializar()
        {
            if (File.Exists("dados.txt"))
            {
                string[] dados = File.ReadAllLines("dados.txt");
                foreach (var dado in dados)
                {
                    string[] items = dado.Split("•");
                    Serie novaSerie = new Serie(Acervo.ProximoId(),
                    genero: (Genero)Enum.Parse(typeof(Genero), items[0]),
                    titulo: items[1],
                    descricao: items[2],
                    ano: Convert.ToInt32(items[3]));
                    if (items[4] == "True") { novaSerie.Excluir(); }
                    Acervo.Insere(novaSerie);
                }
            }
            Menu();

        }
        /// <summary>
        /// Mostra as opções de generos para os usuarios
        /// </summary>
        /// <returns></returns>
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
            Console.WriteLine("X Salvar e Sair");
            Console.WriteLine();



            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.ResetColor();
            return opcaoUsuario;
        }



        /// <summary>
        /// Menu de Operações
        /// </summary>
        static void Menu()
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
                            ListarSeries(false);
                            break;
                        case "2":
                            InserirSerie();
                            break;
                        case "3":
                            AtualizarSerie();
                            break;
                        case "4":
                            ExcluirSeries();
                            break;
                        case "5":
                            VisualizarSerie();
                            break;
                        case "6":
                            ListarSeries(true);
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        case "X":
                            Console.WriteLine("Tchau !");
                            Save();
                            Environment.Exit(-1);
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
        /// <summary>
        /// Listagem das séries cadastradas utilizando laço foreach
        /// </summary>
        /// <param name="utilizaveis"></param>
        static void ListarSeries(bool utilizaveis)
        {


            var listagem = Acervo.Lista();

            if (listagem.Count == 0)
            {
                throw new DomainExceptions("Lista Vazia!");
            }
            if (!utilizaveis) { Console.WriteLine("Listagem de séries ativas ! \n"); }
            else { Console.WriteLine("Listagem de séries excluidas ! \n"); }
           
            foreach (var serie in listagem)
            {
                Console.ForegroundColor = (ConsoleColor)serie.RetornaGenero();
                if (serie.ItemExcluido() == utilizaveis) { Console.WriteLine($"#ID {serie.RetornaId()}  Titulo: {serie.RetornaTitulo()}"); }
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Método static para cadastros de novas séries
        /// </summary>
        static void InserirSerie()
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


            Acervo.Insere(novaSerie);

        }
        /// <summary>
        /// Atualização de cadastros de séries
        /// </summary>
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());



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


            


            Acervo.Atualiza(indiceSerie, novaSerie);
        }
        /// <summary>
        /// Exlusão de série no catalogo deixando-o indisponivel
        /// </summary>
        static void ExcluirSeries()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Acervo.Exclui(indiceSerie);
            Console.WriteLine("Série excluida !");
            
        }
        /// <summary>
        /// Método para visualização completa da série 
        /// </summary>
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Serie serie = Acervo.RetornaPorId(indiceSerie);
            Console.ForegroundColor = (ConsoleColor)serie.RetornaGenero();
            Console.WriteLine(serie);
            Console.ResetColor();
        }

        /// <summary>
        /// Método estatico que retorna a lista de generos cadastrados
        /// </summary>
        static void ListagemGeneros()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {

                Console.ForegroundColor = (ConsoleColor)i;
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                Console.ResetColor();
            }
        }
        static void Save()
        {
            File.WriteAllText("dados.txt", "");
            foreach (var dados in Acervo.Lista())
            {
                File.AppendAllText("dados.txt", dados.TextoParaSalvar());
            }
        }

    }   
}




using System;
using System.Text;


namespace App_Cadastro_Séries_.NET
{
    public class Serie : Entidadebase
    {

        string titulo;
        string descricao;
        int ano;
        //Atributos

        readonly Genero Genero;
        string Titulo
        {
            get => titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                { throw new DomainExceptions("Não é permitido Titulo vazio"); }
                titulo = value;
            }
        }
        string Descricao
        {
            get => descricao;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                { throw new DomainExceptions("Não é permitido descrição vazio"); }
                descricao = value;
            }
        }
        int Ano
        {
            get => ano;
            set
            {
                if (value < 0 || value > DateTime.Now.Year)
                { throw new DomainExceptions("Ano invalido ! "); }
                ano = value;
            }
        }



        private bool Excluido { get; set; }

        // Construtores
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
           
            Ano = ano;
            Excluido = false;
        }



        //Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Gênero:  {Genero}");
            sb.AppendLine($"Titulo:  {Titulo}");
            sb.AppendLine($"Descrição:  {Descricao}");
            sb.AppendLine($"Ano de Início:  {Ano} ");
            sb.AppendLine($"Disponivel ? :" + (Excluido? "Não":"Sim"));

            return sb.ToString();
        }

        public string TextoParaSalvar()
        {
            return Genero.ToString() + "•" + Titulo + "•" + Descricao + "•" + Ano + "•" + (Excluido ? "True" : "False") + Environment.NewLine;
        }
        public string RetornaTitulo() { return Titulo; }
        public int RetornaGenero() { return (int)Enum.Parse(typeof(Genero), this.Genero.ToString()); }
        public int RetornaId() { return Id; }
        public void Excluir() { Excluido = true; }
        public bool ItemExcluido() { return Excluido; }
    }
}






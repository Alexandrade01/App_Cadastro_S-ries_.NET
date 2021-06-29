using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Cadastro_Séries_.NET
{
    public class Serie:Entidadebase
    {


        //Atributos
       
        readonly Genero Genero;
        readonly string Titulo;
        readonly string Descricao;
        readonly int Ano;
        private bool Excluido { get; set; }

        // Construtores
        public Serie(int id,Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            if(ano<0 || ano > DateTime.Now.Year) { throw new DomainExceptions(" Ano de inicio invalido Invalido !"); }
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

            return sb.ToString();
        }

        public string TextoParaSalvar()
        {
            return Genero.ToString() + "•" + Titulo + "•" + Descricao + "•" + Ano + "•" + (Excluido ? "True" : "False") + Environment.NewLine;
        }
        public string RetornaTitulo() { return Titulo; }
        public int RetornaGenero() { return (int)Enum.Parse(typeof(Genero),this.Genero.ToString()); }
        public int RetornaId() { return Id; }
        public void Excluir() { Excluido = true; }
        public bool ItemExcluido() { return Excluido; }
    }
}

           
           



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
        public Serie(Genero genero, string titulo, string descricao, int ano)
        {
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }
       

        //Metodos
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + Genero + Environment.NewLine;
            retorno += "Titulo: " + Titulo + Environment.NewLine;
            retorno += "Descrição: " + Descricao + Environment.NewLine;
            retorno += "Ano de Início: " +  Ano + Environment.NewLine;
           
            return retorno;
        }
        public string RetornaTitulo() { return Titulo; }
        public int RetornaId() { return Id; }
        public void Excluir() { Excluido = true; }
        public bool ItemExcluido() { return Excluido; }
    }
}




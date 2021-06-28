using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Cadastro_Séries_.NET
{
    class Serie:Entidadebase
    {
       

        //Atributos

        public Genero Genero { get; protected set; }
        public string Titulo { get; protected set; }
        public string Descricao { get; protected set; }
        public int Ano { get; protected set; }

        // Construtores
        public Serie(Genero genero, string titulo, string descricao, int ano)
        {
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
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


    }
}

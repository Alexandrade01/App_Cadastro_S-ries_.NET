using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Cadastro_Séries_.NET.IRepositorio;

namespace App_Cadastro_Séries_.NET
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> Listagem = new List<Serie>();
        public void Atualiza(int id, Serie serie) { Listagem[id] = serie; }
        public void Exclui(int id) { Listagem[id].Excluir(); }
        public void Insere(Serie serie) { Listagem.Add(serie); }
        public List<Serie> Lista() { return Listagem; }
        public int ProximoId() { return Listagem.Count; }
        public Serie RetornaPorId(int id) { return Listagem[id]; }
       
    }
}
     
      


       



      


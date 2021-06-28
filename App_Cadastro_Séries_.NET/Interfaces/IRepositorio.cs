using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Cadastro_Séries_.NET.IRepositorio
{
    interface IRepositorio<T>
    {
        List<T> Lista();

        #region CRUD
       //CREATE
        void Insere(T entidade);

        //READ
        T RetornaPorId(int id);
        //DELETE
        void Exclui(int id);
        //UPDATE
        void Atualiza(int id, T entidade);
        #endregion
        int ProximoId();
    }
}

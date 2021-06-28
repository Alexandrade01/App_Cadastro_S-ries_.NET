using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Cadastro_Séries_.NET
{
    class DomainExceptions:ApplicationException
    {
       public DomainExceptions(string msg) : base(msg)
        {

        }
    }
}

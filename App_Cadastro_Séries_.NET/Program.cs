using System;



namespace App_Cadastro_Séries_.NET
{
    class Program
    {
        static SerieRepositorio Acervo = new SerieRepositorio();
        static void Main(string[] args)
        {
          
            LayoutdeUsuario.Menu(Acervo);
        }
    }
}

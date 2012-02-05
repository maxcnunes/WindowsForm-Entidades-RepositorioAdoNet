using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace MDI_Escola.Repositorios
{
    public abstract class RepositorioBase
    {
        /// <summary>
        /// Cria um objeto de conexao com o banco
        /// </summary>
        /// <returns></returns>
        protected SqlConnection CriarConexao()
        {
            return new SqlConnection
                       {
                           //Recupera a string de conexao com o banco
                           ConnectionString = ConfigurationManager.
                               ConnectionStrings["MDI_Escola"].
                               ConnectionString
                       };
        }
    }
}

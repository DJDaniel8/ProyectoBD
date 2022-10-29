using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Services.DAO
{
    public static class DBConection
    {
        public static string CadenaDeConexion { get; } = ConfigurationManager.ConnectionStrings["conexionOracle"].ConnectionString;

    }
}

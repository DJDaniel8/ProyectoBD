using Oracle.ManagedDataAccess.Client;
using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.Services.DAO
{
    public class MarcaCarroDAO
    {
        public static OracleConnection miconexion { get; } = new OracleConnection(DBConection.CadenaDeConexion);

        public static bool Insert(MarcaCarroViewModel marca)
        {
            string consulta = "INSERT INTO MarcasCarros (Nombre) VALUES (:Nombre)";
            OracleCommand comando = new OracleCommand(consulta, miconexion);
            comando.Parameters.Add("Nombre", marca.Nombre);
            miconexion.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            miconexion.Close();
            return true;
        }

        public static List<MarcaCarroViewModel> Get()
        {
            string consulta = "SELECT * FROM MARCASCARROS";
            OracleCommand comando = new OracleCommand(consulta, miconexion);
            List<MarcaCarroViewModel> lista = new();
            miconexion.Open();
            try
            {
                OracleDataReader reader = comando.ExecuteReader();
                using(reader)
                {
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            MarcaCarroViewModel m = new();
                            m.Id = reader.GetInt32(0);
                            m.Nombre = reader.GetString(1);
                            lista.Add(m);
                        }
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            miconexion.Close();
            return lista;
        }
    }
}

using Oracle.ManagedDataAccess.Client;
using ProyectoBD.ViewModels.TiposPagosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.Services.DAO
{
    public class TipoPagoDAO
    {
        public static OracleConnection miconexion { get; } = new OracleConnection(DBConection.CadenaDeConexion);

        public static bool Insert(TipoPagoViewModel tipoPago)
        {
            string consulta = "INSERT INTO TiposPagos (Nombre) VALUES (:Nombre)";
            OracleCommand comando = new(consulta, miconexion);
            comando.Parameters.Add("Nombre", tipoPago.Nombre);
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

        public static List<TipoPagoViewModel> Get()
        {
            string consulta = "SELECT * FROM TiposPagos";
            OracleCommand comando = new(consulta, miconexion);
            List<TipoPagoViewModel> lista = new();
            miconexion.Open();
            try
            {
                OracleDataReader reader = comando.ExecuteReader();
                using (reader)
                {
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            TipoPagoViewModel t = new TipoPagoViewModel();
                            t.Id = reader.GetInt32(0);
                            t.Nombre = reader.GetString(1);
                            lista.Add(t);
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

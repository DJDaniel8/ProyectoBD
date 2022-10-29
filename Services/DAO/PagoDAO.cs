using Oracle.ManagedDataAccess.Client;
using ProyectoBD.ViewModels.PagosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.Services.DAO
{
    public class PagoDAO
    {
        public static OracleConnection miconexion { get; } = new OracleConnection(DBConection.CadenaDeConexion);

        public static bool Insert(PagoViewModel pago)
        {
            string consulta = "INSERT INTO Pagos (Fecha, Monto, NoDoc, TipoPago) VALUES (:Fecha, :Monto, :NoDoc, :TipoPago)";
            OracleCommand comando = new OracleCommand(consulta, miconexion);
            comando.Parameters.Add("Fecha", pago.Fecha);
            comando.Parameters.Add("Monto", pago.Monto);
            comando.Parameters.Add("NoDoc", pago.NoDoc);
            comando.Parameters.Add("TipoPago", pago.TipoPago.Id);
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

        public static List<PagoViewModel> Get()
        {
            string consulta = "SELECT * FROM Pagos p INNER JOIN TiposPagos tp ON p.TipoPago = tp.Id";
            OracleCommand comando = new(consulta, miconexion);
            List<PagoViewModel> lista = new();
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
                            PagoViewModel p = new PagoViewModel();
                            p.Id = reader.GetInt32(0);
                            p.Fecha = reader.GetDateTime(1);
                            p.TipoPago.Id = reader.GetInt32(5);
                            p.TipoPago.Nombre = reader.GetString(6);
                            p.Monto = reader.GetDecimal(2);
                            p.NoDoc = reader.GetString(3);
                            lista.Add(p);
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

        public static List<PagoViewModel> Get2()
        {
            string consulta = "SELECT * FROM Pagos p INNER JOIN TiposPagos tp ON p.TipoPago = tp.Id LEFT JOIN Facturas f ON p.Id = f.PagoId WHERE f.PagoId is null";
            OracleCommand comando = new(consulta, miconexion);
            List<PagoViewModel> lista = new();
            miconexion.Open();

            try
            {
                OracleDataReader reader = comando.ExecuteReader();
                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            PagoViewModel p = new PagoViewModel();
                            p.Id = reader.GetInt32(0);
                            p.Fecha = reader.GetDateTime(1);
                            p.Monto = reader.GetDecimal(2);
                            p.TipoPago.Id = reader.GetInt32(5);
                            p.TipoPago.Nombre = reader.GetString(6);
                            p.NoDoc = reader.GetString(3);
                            lista.Add(p);
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

using Oracle.ManagedDataAccess.Client;
using ProyectoBD.ViewModels.FacturasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.Services.DAO
{
    public class FacturaDAO
    {
        public static OracleConnection miconexion { get; } = new OracleConnection(DBConection.CadenaDeConexion);

        public static bool Insert(FacturaViewModel factura)
        {
            string consulta = "INSERT INTO Facturas (Fecha, NIT, NoDoc, ResidenteId, PagoId) VALUES (:Fecha, :NIT, :NoDoc, :ResidenteId, :PagoId)";
            OracleCommand comando = new OracleCommand(consulta, miconexion);
            comando.Parameters.Add("Fecha", factura.Fecha);
            comando.Parameters.Add("NIT", factura.Nit);
            comando.Parameters.Add("NoDoc", factura.NoDoc);
            comando.Parameters.Add("ResidenteId", factura.Residente.Id);
            comando.Parameters.Add("PagoId", factura.Pago.Id);

            miconexion.Open();
            comando.ExecuteNonQuery();
            miconexion.Close();

            foreach (var item in factura.DetallesFacturas)
            {
                InsertDetalles(item);
            }

            return true;
        }

        public static bool InsertDetalles(DetalleFacturaViewModel detalle)
        {
            string consulta2 = "SELECT id FROM FACTURAS WHERE ROWNUM < 2 ORDER BY ID DESC";
            OracleCommand comando2 = new(consulta2, miconexion);
            miconexion.Open();
            int id = 0;
            OracleDataReader reader = comando2.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    id = reader.GetInt32(0);
                }
            }
            miconexion.Close();
            string consulta = $"INSERT INTO DetalleFacturas (Cantidad, PS, PrecioVenta, FacturaId) VALUES ({detalle.Cantidad}, '{detalle.Descripcion}', {detalle.PrecioVenta}, {id})";
            OracleCommand comando = new OracleCommand(consulta, miconexion);

            miconexion.Open();
            comando.ExecuteNonQuery();
            miconexion.Close();

            return true;
        }

        public static List<FacturaViewModel> Get()
        {
            string consulta = "SELECT * FROM FACTURAS f " +
                "INNER JOIN Residentes r ON f.ResidenteId = r.Id " +
                "INNER JOIN Pagos p ON f.PagoId = p.Id " +
                "INNER JOIN TiposPagos tp ON p.TipoPago = tp.Id";
            OracleCommand comando = new(consulta, miconexion);
            List<FacturaViewModel> lista = new();
            miconexion.Open();
            OracleDataReader reader = comando.ExecuteReader();
            using(reader)
            {
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        FacturaViewModel f = new();
                        f.Id = reader.GetInt32(0);
                        f.Fecha = reader.GetDateTime(1);
                        f.Nit = reader.GetString(2);
                        f.NoDoc = reader.GetString(3);
                        f.Residente.Id = reader.GetInt32(6);
                        f.Residente.PrimerNombre = reader.GetString(7);
                        f.Residente.SegundoNombre = reader.GetString(8);
                        f.Residente.PrimerApellido = reader.GetString(9);
                        f.Residente.SegundoApellido = reader.GetString(10);
                        f.Residente.Calle = reader.GetString(11);
                        f.Residente.Zona = reader.GetString(12);
                        f.Residente.NoCasa = reader.GetString(13);
                        f.Residente.Estatus = reader.GetString(14) == "A" ? true : false;
                        f.Residente.DPI = reader.GetString(15);
                        f.Residente.FechaNacimiento = reader.GetDateTime(16);
                        f.Residente.Telefono = reader.GetString(17);
                        f.Residente.Email = reader.GetString(18);
                        f.Pago.Id = reader.GetInt32(19);
                        f.Pago.Fecha = reader.GetDateTime(20);
                        f.Pago.Monto = reader.GetDecimal(21);
                        f.Pago.NoDoc = reader.GetString(22);
                        f.Pago.TipoPago.Id = reader.GetInt32(24);
                        f.Pago.TipoPago.Nombre = reader.GetString(25);
                        lista.Add(f);
                    }
                }
            }
            miconexion.Close();
            return lista;
        }

        public static List<DetalleFacturaViewModel> GetDetalles(int facturaId)
        {
            string consulta = "SELECT * FROM DetalleFacturas df INNER JOIN Facturas f ON df.FacturaId = f.Id WHERE f.Id = :idf";
            OracleCommand comando = new OracleCommand(consulta, miconexion);
            comando.Parameters.Add("idf", facturaId);
            List<DetalleFacturaViewModel> lista = new();
            miconexion.Open();
            OracleDataReader reader = comando.ExecuteReader();
            using (reader)
            {
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        DetalleFacturaViewModel d = new DetalleFacturaViewModel();
                        d.Id = reader.GetInt32(0);
                        d.Cantidad = reader.GetInt32(1);
                        d.Descripcion = reader.GetString(2);
                        d.PrecioVenta = reader.GetDecimal(3);
                        lista.Add(d);
                    }
                }
            }

            miconexion.Close();
            return lista;
        }
    }
}

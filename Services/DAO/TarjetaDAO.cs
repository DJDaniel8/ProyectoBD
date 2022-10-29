using Oracle.ManagedDataAccess.Client;
using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.TarjetasViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.Services.DAO
{
    public class TarjetaDAO
    {
        public static OracleConnection miconexion { get; } = new OracleConnection(DBConection.CadenaDeConexion);

        public static bool Insert(TarjetaViewModel tarjeta)
        {
            string consulta = "INSERT INTO Tarjetas (Numero, FIVigencia, FFVigencia, Estatus, VehiculoId) VALUES (:Numero, :FIVigencia, :FFVigencia, :Estatus, :VehiculoId)";
            OracleCommand comando = new OracleCommand(consulta, miconexion);
            comando.Parameters.Add("Numero", tarjeta.Numero);
            comando.Parameters.Add("FIVigencia", tarjeta.FechaIVigencia);
            comando.Parameters.Add("FFVigencia", tarjeta.FechaFVigencia);
            comando.Parameters.Add("Estatus", tarjeta.Estatus == true? "A" : "I");
            comando.Parameters.Add("VehiculoId", tarjeta.Carro.Id);
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

        public static List<TarjetaViewModel> Get()
        {
            string consulta = "SELECT *  " +
                                "FROM Vehiculos v  " +
                                "INNER JOIN Residentes r ON v.Dueño = r.Id " +
                                "INNER JOIN MarcasCarros mc ON v.Marca = mc.Id " +
                                "INNER JOIN Tarjetas t ON v.Id = t.VehiculoId ";
            OracleCommand comando = new OracleCommand(consulta, miconexion);
            List<TarjetaViewModel> lista = new();
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
                            TarjetaViewModel t = new TarjetaViewModel();
                            CarroViewModel c = new CarroViewModel();
                            c.Id = reader.GetInt32(0);
                            c.Placa = reader.GetString(1);
                            c.Modelo = reader.GetString(2);
                            c.Dueño.Id = reader.GetInt32(6);
                            c.Dueño.PrimerNombre = reader.GetString(7);
                            c.Dueño.SegundoNombre = reader.GetString(8);
                            c.Dueño.PrimerApellido = reader.GetString(9);
                            c.Dueño.SegundoApellido = reader.GetString(10);
                            c.Dueño.Calle = reader.GetString(11);
                            c.Dueño.Zona = reader.GetString(12);
                            c.Dueño.NoCasa = reader.GetString(13);
                            c.Dueño.Estatus = reader.GetString(14) == "A" ? true : false;
                            c.Dueño.DPI = reader.GetString(15);
                            c.Dueño.FechaNacimiento = reader.GetDateTime(16);
                            c.Dueño.Telefono = reader.GetString(17);
                            c.Dueño.Email = reader.GetString(18);
                            c.Marca.Id = reader.GetInt32(19);
                            c.Marca.Nombre = reader.GetString(20);
                            c.Color = reader.GetString(3);
                            t.Carro = c;
                            t.Id=reader.GetInt32(21);
                            t.Numero = reader.GetString(22);
                            t.FechaIVigencia = reader.GetDateTime(23);
                            t.FechaFVigencia = reader.GetDateTime(24);
                            t.Estatus = reader.GetString(25) == "A" ? true : false;
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

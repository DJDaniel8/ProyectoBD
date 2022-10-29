using Oracle.ManagedDataAccess.Client;
using ProyectoBD.ViewModels.CarrosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.Services.DAO
{
    public class CarroDAO
    {
        public static OracleConnection miconexion { get; } = new OracleConnection(DBConection.CadenaDeConexion);

        public static bool Insert(CarroViewModel carro)
        {
            string consulta = "INSERT INTO Vehiculos (Placa, Modelo, Color, Marca, Dueño) VALUES (:Placa, :Modelo, :Color, :Marca, :Dueño)";
            OracleCommand comando = new(consulta, miconexion);
            comando.Parameters.Add("Placa", carro.Placa);
            comando.Parameters.Add("Modelo", carro.Modelo);
            comando.Parameters.Add("Color", carro.Color);
            comando.Parameters.Add("Marca", carro.Marca.Id);
            comando.Parameters.Add("Dueño", carro.Dueño.Id);
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

        public static List<CarroViewModel> Get()
        {
            string consulta = "SELECT * " +
                                "FROM Vehiculos v " +
                                "INNER JOIN Residentes r ON v.Dueño = r.Id " +
                                "INNER JOIN MarcasCarros mc ON v.Marca = mc.Id";
            OracleCommand comando = new(consulta, miconexion);
            List<CarroViewModel> lista = new();
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
                            lista.Add(c);
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

        public static List<CarroViewModel> Get2()
        {
            string consulta = "SELECT * " +
                                "FROM Vehiculos v " +
                                "INNER JOIN Residentes r ON v.Dueño = r.Id " +
                                "INNER JOIN MarcasCarros mc ON v.Marca = mc.Id " +
                                "LEFT JOIN Tarjetas t ON v.Id = t.VehiculoId " +
                                "WHERE t.VehiculoId is null";
            OracleCommand comando = new(consulta, miconexion);
            List<CarroViewModel> lista = new();
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
                            lista.Add(c);
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

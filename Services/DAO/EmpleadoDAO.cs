using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoBD.ViewModels.TrabajadoresViewModels;
using System.Windows;
using Oracle.ManagedDataAccess.Client;

namespace ProyectoBD.Services.DAO
{
    public class EmpleadoDAO
    {
        public static OracleConnection miconexion { get; } = new OracleConnection(DBConection.CadenaDeConexion);

        public static bool Insert(EmpleadosViewModel empleado)
        {
            string consulta = "INSERT INTO TRABAJADORES (PNombre, SNombre, PApellido, SApellido, Sexo, Usuario, Contraseña, Direccion, Telefono, Email) " +
                "VALUES (:PNombre, :SNombre, :PApellido, :SApellido, :Sexo, :Usuario, :Contraseña, :Direccion, :Telefono, :Email)";
            OracleCommand comando = new OracleCommand(consulta, miconexion);
            comando.Parameters.Add("PNombre", empleado.PrimerNombre);
            comando.Parameters.Add("SNombre", empleado.SegundoNombre);
            comando.Parameters.Add("PApellido", empleado.PrimerApellido);
            comando.Parameters.Add("SApellido", empleado.SegundoApellido);
            comando.Parameters.Add("Sexo", empleado.Sexo);
            comando.Parameters.Add("Usuario", empleado.Usuario);
            comando.Parameters.Add("Contraseña", empleado.Contraseña);
            comando.Parameters.Add("Direccion", empleado.Direccion);
            comando.Parameters.Add("Telefono", empleado.Telefono);
            comando.Parameters.Add("Email", empleado.Email);
            miconexion.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            miconexion.Close();

            return true;
        }

        public static List<EmpleadosViewModel> Get()
        {
            string consulta = "SELECT * FROM TRABAJADORES";
            OracleCommand comando = new OracleCommand(consulta, miconexion);
            List<EmpleadosViewModel> lista = new();
            miconexion.Open();
            OracleDataReader reader = comando.ExecuteReader();
            using (reader)
            {
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        EmpleadosViewModel e = new();
                        e.Id = reader.GetInt32(0);
                        e.PrimerNombre = reader.GetString(1);
                        e.SegundoNombre = reader.GetString(2);
                        e.PrimerApellido = reader.GetString(3);
                        e.SegundoApellido = reader.GetString(4);
                        e.Sexo = reader.GetString(5);
                        e.Usuario = reader.GetString(6);
                        e.Contraseña = reader.GetString(7);
                        e.Direccion = reader.GetString(8);
                        e.Telefono = reader.GetString(9);
                        e.Email = reader.GetString(10);
                        lista.Add(e);
                    }
                }
            }
            miconexion.Close();

            return lista;
        }

    }
}

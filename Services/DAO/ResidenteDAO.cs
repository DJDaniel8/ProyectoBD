using Oracle.ManagedDataAccess.Client;
using ProyectoBD.ViewModels.ResidentesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.Services.DAO
{
    public class ResidenteDAO
    {
        public static OracleConnection miconexion { get; } = new OracleConnection(DBConection.CadenaDeConexion);
        
        public static bool Insert(ResidenteViewModel residente)
        {
            string consulta = "INSERT INTO RESIDENTES (PNombre, SNombre, PApellido, SApellido, Calle, Zona, NoCasa, Estatus, DPI, FechaNac, Telefono, Correo) " +
                                "VALUES (:PNombre, :SNombre, :PApellido, :SApellido, :Calle, :Zona, :NoCasa, :Estatus, :DPI, :FechaNac, :Telefono, :Correo)";
            OracleCommand comando = new OracleCommand(consulta, miconexion);
            comando.Parameters.Add("PNombre", residente.PrimerNombre);
            comando.Parameters.Add("SNombre", residente.SegundoNombre);
            comando.Parameters.Add("PApellido", residente.PrimerApellido);
            comando.Parameters.Add("SApellido", residente.SegundoApellido);
            comando.Parameters.Add("Calle", residente.Calle);
            comando.Parameters.Add("Zona", residente.Zona);
            comando.Parameters.Add("NoCasa", residente.NoCasa);
            comando.Parameters.Add("Estatus", residente.Estatus? "A" : "I");
            comando.Parameters.Add("DPI", residente.DPI);
            comando.Parameters.Add("FechaNac", residente.FechaNacimiento);
            comando.Parameters.Add("Telefono", residente.Telefono);
            comando.Parameters.Add("Correo", residente.Email);
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

        public static List<ResidenteViewModel> Get()
        {
            string consulta = "SELECT * FROM RESIDENTES";
            OracleCommand comando = new(consulta, miconexion);
            List<ResidenteViewModel> lista = new();
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
                            ResidenteViewModel r = new ResidenteViewModel();
                            r.Id = reader.GetInt32(0);
                            r.PrimerNombre = reader.GetString(1);
                            r.SegundoNombre = reader.GetString(2);
                            r.PrimerApellido = reader.GetString(3);
                            r.SegundoApellido = reader.GetString(4);
                            r.Calle = reader.GetString(5);
                            r.Zona = reader.GetString(6);
                            r.NoCasa = reader.GetString(7);
                            r.Estatus = reader.GetString(8) == "A" ? true : false;
                            r.DPI = reader.GetString(9);
                            r.FechaNacimiento = reader.GetDateTime(10);
                            r.Telefono = reader.GetString(11);
                            r.Email = reader.GetString(12);
                            lista.Add(r);
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

using ProyectoBD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace ProyectoBD.Commands.MainWindowCommands
{
    public class IngresarCommand : CommandBase
    {
        private MainWindowViewModel _viewModel;
        public IngresarCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MainWindowViewModel.Usuario) || e.PropertyName == nameof(MainWindowViewModel.Contraseña))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return (!String.IsNullOrEmpty(_viewModel.Usuario)) &&
                    (!String.IsNullOrEmpty(_viewModel.Contraseña)) &&
                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {

            string conexionstring = ConfigurationManager.ConnectionStrings["conexionOracle"].ConnectionString;
            OracleConnection miconexion = new OracleConnection("DATA SOURCE=orcl;USER ID=UsuarioProyecto;PASSWORD=usuarioproyecto;");
            string consulta = $"SELECT * FROM Trabajadores WHERE Usuario = :usuario AND Contraseña = :contraseña";
            using (miconexion)
            {
                OracleCommand comando = new OracleCommand(consulta, miconexion);
                comando.Parameters.Add("usuario", _viewModel.Usuario);
                comando.Parameters.Add("contraseña", _viewModel.Contraseña);
                miconexion.Open();
                OracleDataReader reader = comando.ExecuteReader();
                using (reader)
                {
                    if (reader.HasRows)
                    {
                        HomeView nuevaVentana = new();
                        nuevaVentana.Show();
                        if (parameter != null) ((Window)parameter).Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o Contraseña Erronea");
                    }
                }
                miconexion.Close();
            }
        }
    }
}

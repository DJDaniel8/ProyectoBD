using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using ProyectoBD.ViewModels.ResidentesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.MarcasCarrosCommands
{
    public class GuardarCommand : CommandBase
    {
        private CrearMarcasCarrosViewModel _viewModel;
        public GuardarCommand(CrearMarcasCarrosViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CrearMarcasCarrosViewModel.MarcaCarro))
            {
                _viewModel.MarcaCarro.PropertyChanged += Empleado_PropertyChanged;
            }
        }

        private void Empleado_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return (!String.IsNullOrEmpty(_viewModel.MarcaCarro.Nombre)) &&
                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            MarcaCarroDAO.Insert(_viewModel.MarcaCarro);
            _viewModel.MarcaCarro = new();
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.MarcasCarrosViewModel.VerMarcasCarrosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
            _viewModel.MarcasCarrosViewModel.VerMarcasCarrosViewModel.CargarDatos();
        }
    }
}

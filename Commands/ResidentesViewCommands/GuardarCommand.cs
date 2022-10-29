using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.ResidentesViewModels;
using ProyectoBD.ViewModels.TrabajadoresViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.ResidentesViewCommands
{
    public class GuardarCommand : CommandBase
    {
        private CrearResidentesViewModel _viewModel;
        public GuardarCommand(CrearResidentesViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CrearResidentesViewModel.Residente))
            {
                _viewModel.Residente.PropertyChanged += Empleado_PropertyChanged;
            }
        }

        private void Empleado_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return (_viewModel.Residente != null) &&
                (!String.IsNullOrEmpty(_viewModel.Residente.PrimerNombre)) &&
                (!String.IsNullOrEmpty(_viewModel.Residente.SegundoNombre)) &&
                (!String.IsNullOrEmpty(_viewModel.Residente.PrimerApellido)) &&
                (!String.IsNullOrEmpty(_viewModel.Residente.SegundoApellido)) &&
                (!String.IsNullOrEmpty(_viewModel.Residente.Calle)) &&
                (!String.IsNullOrEmpty(_viewModel.Residente.Zona)) &&
                (!String.IsNullOrEmpty(_viewModel.Residente.NoCasa)) &&
                (!String.IsNullOrEmpty(_viewModel.Residente.DPI)) &&
                (!String.IsNullOrEmpty(_viewModel.Residente.Telefono)) &&
                (!String.IsNullOrEmpty(_viewModel.Residente.Email)) &&
                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            ResidenteDAO.Insert(_viewModel.Residente);
            _viewModel.Residente = new();
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.ResidentesViewModel.VerResidentesViewModel.ControlVisibility = System.Windows.Visibility.Visible;
            _viewModel.ResidentesViewModel.VerResidentesViewModel.CargarDatos();
        }
    }
}

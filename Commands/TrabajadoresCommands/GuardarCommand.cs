using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.TrabajadoresViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.TrabajadoresCommands
{
    public class GuardarCommand : CommandBase
    {
        private CrearEmpleadosViewModel _viewModel;
        public GuardarCommand(CrearEmpleadosViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CrearEmpleadosViewModel.Empleado))
            {
                _viewModel.Empleado.PropertyChanged += Empleado_PropertyChanged;
            }
        }

        private void Empleado_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return (_viewModel.Empleado != null) &&
                (!String.IsNullOrEmpty(_viewModel.Empleado.PrimerNombre)) &&
                (!String.IsNullOrEmpty(_viewModel.Empleado.SegundoNombre)) &&
                (!String.IsNullOrEmpty(_viewModel.Empleado.PrimerApellido)) &&
                (!String.IsNullOrEmpty(_viewModel.Empleado.SegundoApellido)) &&
                (!String.IsNullOrEmpty(_viewModel.Empleado.Sexo)) &&
                (!String.IsNullOrEmpty(_viewModel.Empleado.Email)) &&
                (!String.IsNullOrEmpty(_viewModel.Empleado.Usuario)) &&
                (!String.IsNullOrEmpty(_viewModel.Empleado.Contraseña)) &&
                (!String.IsNullOrEmpty(_viewModel.Empleado.Direccion)) &&
                (!String.IsNullOrEmpty(_viewModel.Empleado.Telefono)) &&
                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            EmpleadoDAO.Insert(_viewModel.Empleado);
            _viewModel.Empleado = new();
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.TrabajadoresViewModel.VerEmpleadosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
            _viewModel.TrabajadoresViewModel.VerEmpleadosViewModel.CargarDatos();
        }
    }
}

using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.CarrosViewCommands
{
    public class GuardarCommand : CommandBase
    {
        private CrearCarrosViewModel _viewModel;
        public GuardarCommand(CrearCarrosViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CrearCarrosViewModel.Carro))
            {
                _viewModel.Carro.PropertyChanged += Empleado_PropertyChanged;
            }
            else if(e.PropertyName == nameof(CrearCarrosViewModel.SelectedMarca) ||
                    e.PropertyName == nameof(CrearCarrosViewModel.SelectedResidente))
            {
                OnCanExecutedChanged();
            }
        }

        private void Empleado_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return (!String.IsNullOrEmpty(_viewModel.Carro.Placa)) &&
                (!String.IsNullOrEmpty(_viewModel.Carro.Modelo)) &&
                (!String.IsNullOrEmpty(_viewModel.Carro.Color)) &&
                (_viewModel.SelectedMarca != null && _viewModel.SelectedMarca.Id > 0) &&
                (_viewModel.SelectedResidente != null && _viewModel.SelectedResidente.Id >0) &&
                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _viewModel.Carro.Dueño = _viewModel.SelectedResidente;
            _viewModel.Carro.Marca = _viewModel.SelectedMarca;
            CarroDAO.Insert(_viewModel.Carro);
            _viewModel.Carro = new();
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.CarrosViewModel.VerCarrosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
            _viewModel.CarrosViewModel.VerCarrosViewModel.CargarDatos();
        }
    }
}

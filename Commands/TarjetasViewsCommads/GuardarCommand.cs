using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.TarjetasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.TarjetasViewsCommads
{
    public class GuardarCommand : CommandBase
    {
        private CrearTarjetaViewModel _viewModel;
        public GuardarCommand(CrearTarjetaViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CrearTarjetaViewModel.Tarjeta))
            {
                _viewModel.Tarjeta.PropertyChanged += Empleado_PropertyChanged;
            }
            else if (e.PropertyName == nameof(CrearTarjetaViewModel.SelectedCarro))
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
            return (!String.IsNullOrEmpty(_viewModel.Tarjeta.Numero)) &&
                (_viewModel.SelectedCarro != null && _viewModel.SelectedCarro.Id >0) &&
                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _viewModel.Tarjeta.Carro = _viewModel.SelectedCarro;
            TarjetaDAO.Insert(_viewModel.Tarjeta);
            _viewModel.Tarjeta = new();
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.TarjetasViewModel.VerTarjetasViewModel.ControlVisibility = System.Windows.Visibility.Visible;
            _viewModel.TarjetasViewModel.VerTarjetasViewModel.CargarDatos();
        }
    }
}

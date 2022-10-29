using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.TiposPagosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.TiposPagosViewsCommands
{
    public class GuardarCommand : CommandBase
    {
        private CrearTiposPagosViewModel _viewModel;
        public GuardarCommand(CrearTiposPagosViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CrearTiposPagosViewModel.TipoPago))
            {
                _viewModel.TipoPago.PropertyChanged += Empleado_PropertyChanged;
            }
        }

        private void Empleado_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return (!String.IsNullOrEmpty(_viewModel.TipoPago.Nombre)) &&
                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            TipoPagoDAO.Insert(_viewModel.TipoPago);
            _viewModel.TipoPago = new();
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.TiposPagosViewModel.VerTiposPagosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
            _viewModel.TiposPagosViewModel.VerTiposPagosViewModel.CargarDatos();
        }
    }
}

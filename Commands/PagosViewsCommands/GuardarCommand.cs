using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.PagosViewModels;
using ProyectoBD.ViewModels.ResidentesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.PagosViewsCommands
{
    public class GuardarCommand : CommandBase
    {
        private CrearPagosViewModel _viewModel;
        public GuardarCommand(CrearPagosViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CrearPagosViewModel.Pago))
            {
                _viewModel.Pago.PropertyChanged += Empleado_PropertyChanged;
            }
            else if(e.PropertyName == nameof(CrearPagosViewModel.SelectedTipoPago))
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
            return (_viewModel.Pago != null) &&
                (_viewModel.Pago.Monto > 0) &&
                (!String.IsNullOrEmpty(_viewModel.Pago.NoDoc)) &&
                (_viewModel.SelectedTipoPago != null && _viewModel.SelectedTipoPago.Id >0) &&
                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _viewModel.Pago.TipoPago = _viewModel.SelectedTipoPago;
            PagoDAO.Insert(_viewModel.Pago);
            _viewModel.Pago = new();
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.PagosViewModel.VerPagosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
            _viewModel.PagosViewModel.VerPagosViewModel.CargarDatos();
        }
    }
}

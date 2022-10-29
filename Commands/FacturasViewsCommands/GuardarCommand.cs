using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.FacturasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.FacturasViewsCommands
{
    public class GuardarCommand : CommandBase
    {
        private CrearFacturasViewModel _viewModel;
        public GuardarCommand(CrearFacturasViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _Detalles_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }

        private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CrearFacturasViewModel.Factura))
            {
                _viewModel.Factura.PropertyChanged += Empleado_PropertyChanged;
            }
            else if (e.PropertyName == nameof(CrearFacturasViewModel.SelectedPago) ||
                    e.PropertyName == nameof(CrearFacturasViewModel.SelectedResidente))
            {
                OnCanExecutedChanged();
            }
            else if(e.PropertyName == nameof(CrearFacturasViewModel._Detalles))
            {
                _viewModel._Detalles.CollectionChanged += _Detalles_CollectionChanged1;
            }
        }

        private void _Detalles_CollectionChanged1(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }

        private void Empleado_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return 
                (!String.IsNullOrEmpty(_viewModel.Factura.Nit)) &&
                (!String.IsNullOrEmpty(_viewModel.Factura.NoDoc)) &&
                (_viewModel.SelectedPago != null && _viewModel.SelectedPago.Id > 0) &&
                (_viewModel.SelectedResidente != null && _viewModel.SelectedResidente.Id > 0) &&
                (_viewModel._Detalles.Count() > 0) &&

                    base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            foreach (var item in _viewModel._Detalles)
            {
                _viewModel.Factura.DetallesFacturas.Add(item);
            }
            _viewModel.Factura.Residente = _viewModel.SelectedResidente;
            _viewModel.Factura.Pago = _viewModel.SelectedPago;
            FacturaDAO.Insert(_viewModel.Factura);
            _viewModel.Factura = new();
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.FacturasViewModel.VerFacturasViewModel.ControlVisibility = System.Windows.Visibility.Visible;
            _viewModel.FacturasViewModel.VerFacturasViewModel.CargarDatos();
        }
    }
}

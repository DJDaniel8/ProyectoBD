using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.TarjetasViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ProyectoBD.Commands.FacturasViewsCommands;

namespace ProyectoBD.ViewModels.FacturasViewModels
{
    public class VerFacturasViewModel : ViewModelBase
    {
        public VerFacturasViewModel()
        {
            _Facturas = new();
            _Detalles = new();
            CrearCommand = new CrearCommand(this);
            CargarDatos();
        }

        private ObservableCollection<FacturaViewModel> _Facturas;
        public IEnumerable<FacturaViewModel> Facturas => _Facturas;

        private ObservableCollection<DetalleFacturaViewModel> _Detalles;
        public IEnumerable<DetalleFacturaViewModel> Detalles => _Detalles;

        public ICommand CrearCommand { get; }

        public FacturasViewModel FacturasViewModel { get; set; }

        private Visibility _ControlVisibility = Visibility.Visible;
        public Visibility ControlVisibility
        {
            get
            {
                return _ControlVisibility;
            }
            set
            {
                _ControlVisibility = value;
                OnPropertyChanged(nameof(ControlVisibility));
            }
        }

        private FacturaViewModel _SelectedFactura;
        public FacturaViewModel SelectedFactura
        {
            get
            {
                return _SelectedFactura;
            }
            set
            {
                _SelectedFactura = value;
                CargarDetalles();
                OnPropertyChanged(nameof(SelectedFactura));
            }
        }

        public void CargarDatos()
        {
            _Facturas.Clear();
            foreach (var item in FacturaDAO.Get())
            {
                _Facturas.Add(item);
            }
            foreach (var item in _Facturas)
            {
                foreach (var item2 in FacturaDAO.GetDetalles(item.Id))
                {
                    item.DetallesFacturas.Add(item2);
                }
            }
        }

        public void CargarDetalles()
        {
            _Detalles.Clear();
            foreach (var item in SelectedFactura.DetallesFacturas)
            {
                _Detalles.Add(item);
            }
        }
    }
}

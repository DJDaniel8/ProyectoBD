using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using ProyectoBD.ViewModels.ResidentesViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ProyectoBD.ViewModels.PagosViewModels;
using ProyectoBD.Commands.FacturasViewsCommands;

namespace ProyectoBD.ViewModels.FacturasViewModels
{
    public class CrearFacturasViewModel : ViewModelBase
    {
        public CrearFacturasViewModel()
        {
            GuardarCommand = new GuardarCommand(this);
            CancelarCommand = new CancelarCommand(this);
            AgregarCommand = new AgregarCommand(this);
            EliminarCommand = new QuitarCommand(this);
            Factura = new();
            _Detalles = new(); OnPropertyChanged(nameof(_Detalles));
            _Residentes = new();
            _Pagos = new();
            CargarDatos();
        }
        public ICommand CancelarCommand { get; set; }
        public ICommand GuardarCommand { get; }
        public ICommand AgregarCommand { get; }
        public ICommand EliminarCommand { get; }

        private ObservableCollection<ResidenteViewModel> _Residentes;
        public IEnumerable<ResidenteViewModel> Residentes => _Residentes;

        public ObservableCollection<DetalleFacturaViewModel> _Detalles;
        public IEnumerable<DetalleFacturaViewModel> Detalles => _Detalles;

        private ObservableCollection<PagoViewModel> _Pagos;
        public IEnumerable<PagoViewModel> Pagos => _Pagos;

        private FacturaViewModel _Factura;
        public FacturaViewModel Factura
        {
            get
            {
                return _Factura;
            }
            set
            {
                _Factura = value;
                OnPropertyChanged(nameof(Factura));
            }
        }
        public FacturasViewModel FacturasViewModel { get; set; }

        private Visibility _ControlVisibility = Visibility.Collapsed;
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

        private PagoViewModel _SelectedPago ;
        public PagoViewModel SelectedPago
        {
            get
            {
                return _SelectedPago;
            }
            set
            {
                _SelectedPago = value;
                OnPropertyChanged(nameof(SelectedPago));
            }
        }

        private ResidenteViewModel _SelectedResidente;
        public ResidenteViewModel SelectedResidente
        {
            get
            {
                return _SelectedResidente;
            }
            set
            {
                _SelectedResidente = value;
                OnPropertyChanged(nameof(SelectedResidente));
            }
        }

        public void CargarDatos()
        {
            _Pagos.Clear();
            _Residentes.Clear();
            foreach (var item in PagoDAO.Get2())
            {
                _Pagos.Add(item);
            }
            foreach (var item in ResidenteDAO.Get())
            {
                _Residentes.Add(item);
            }
        }

        public void Agregar()
        {
            _Detalles.Add(new());
        }

        public void Quitar()
        {
            _Detalles.Remove(_Detalles.Last());
        }
    }
}

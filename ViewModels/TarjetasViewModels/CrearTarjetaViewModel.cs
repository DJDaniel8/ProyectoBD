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
using ProyectoBD.Commands.TarjetasViewsCommads;

namespace ProyectoBD.ViewModels.TarjetasViewModels
{
    public class CrearTarjetaViewModel : ViewModelBase
    {
        public CrearTarjetaViewModel()
        {
            GuardarCommand = new GuardarCommand(this);
            CancelarCommand = new CancelarCommand(this);
            Tarjeta = new();
            _Carros = new();
            CargarDatos();
        }
        public ICommand CancelarCommand { get; set; }
        public ICommand GuardarCommand { get; }

        private ObservableCollection<CarroViewModel> _Carros;
        public IEnumerable<CarroViewModel> Carros => _Carros;

        private TarjetaViewModel _Tarjeta;
        public TarjetaViewModel Tarjeta
        {
            get
            {
                return _Tarjeta;
            }
            set
            {
                _Tarjeta = value;
                OnPropertyChanged(nameof(Tarjeta));
            }
        }

        public TarjetasViewModel TarjetasViewModel { get; set; }

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

        private CarroViewModel _SelectedCarro;
        public CarroViewModel SelectedCarro
        {
            get
            {
                return _SelectedCarro;
            }
            set
            {
                _SelectedCarro = value;
                OnPropertyChanged(nameof(SelectedCarro));
            }
        }

        public void CargarDatos()
        {
            _Carros.Clear();
            foreach (var item in CarroDAO.Get2())
            {
                _Carros.Add(item);
            }
        }
    }
}

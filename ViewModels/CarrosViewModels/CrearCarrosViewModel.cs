using ProyectoBD.ViewModels.TrabajadoresViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using ProyectoBD.ViewModels.ResidentesViewModels;
using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using ProyectoBD.Services.DAO;
using ProyectoBD.Commands.CarrosViewCommands;

namespace ProyectoBD.ViewModels.CarrosViewModels
{
    public class CrearCarrosViewModel : ViewModelBase
    {
        public CrearCarrosViewModel()
        {
            GuardarCommand = new GuardarCommand(this);
            CancelarCommand = new CancelarCommand(this);
            Carro = new();
            _Residentes = new();
            _Marcas = new();
            CargarDatos();
        }
        public ICommand CancelarCommand { get; set; }
        public ICommand GuardarCommand { get; }

        private ObservableCollection<ResidenteViewModel> _Residentes;
        public IEnumerable<ResidenteViewModel> Residentes => _Residentes;

        private ObservableCollection<MarcaCarroViewModel> _Marcas;
        public IEnumerable<MarcaCarroViewModel> Marcas => _Marcas;

        private CarroViewModel _Carro;
        public CarroViewModel Carro
        {
            get
            {
                return _Carro;
            }
            set
            {
                _Carro = value;
                OnPropertyChanged(nameof(Carro));
            }
        }
        public CarrosViewModel CarrosViewModel { get; set; }

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

        private MarcaCarroViewModel _SelectedMarca;
        public MarcaCarroViewModel SelectedMarca
        {
            get
            {
                return _SelectedMarca;
            }
            set
            {
                _SelectedMarca = value;
                OnPropertyChanged(nameof(SelectedMarca));
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
            _Marcas.Clear();
            _Residentes.Clear();
            foreach (var item in MarcaCarroDAO.Get())
            {
                _Marcas.Add(item);
            }
            foreach (var item in ResidenteDAO.Get())
            {
                _Residentes.Add(item);
            }
        }
    }
}

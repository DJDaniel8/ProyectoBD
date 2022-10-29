using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.TrabajadoresViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ProyectoBD.Commands.CarrosViewCommands;

namespace ProyectoBD.ViewModels.CarrosViewModels
{
    public class VerCarrosViewModel : ViewModelBase
    {
        public VerCarrosViewModel()
        {
            _Carros = new();
            CrearCommand = new CrearCommand(this);
            CargarDatos();
        }

        private ObservableCollection<CarroViewModel> _Carros;
        public IEnumerable<CarroViewModel> Carros => _Carros;

        public ICommand CrearCommand { get; }

        public CarrosViewModel CarrosViewModel { get; set; }

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
            foreach (var item in CarroDAO.Get())
            {
                _Carros.Add(item);
            }
        }
    }
}

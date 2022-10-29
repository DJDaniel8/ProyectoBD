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
using ProyectoBD.Commands.ResidentesViewCommands;

namespace ProyectoBD.ViewModels.ResidentesViewModels
{
    public class VerResidentesViewModel : ViewModelBase
    {
        public VerResidentesViewModel()
        {
            _Residentes = new();
            CrearCommand = new CrearCommand(this);
            CargarDatos();
        }

        private ObservableCollection<ResidenteViewModel> _Residentes;
        public IEnumerable<ResidenteViewModel> Residentes => _Residentes;

        public ICommand CrearCommand { get; }

        public ResidentesViewModel ResidentesViewModel { get; set; }

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
            _Residentes.Clear();
            foreach (var item in ResidenteDAO.Get())
            {
                _Residentes.Add(item);
            }
        }
    }
}

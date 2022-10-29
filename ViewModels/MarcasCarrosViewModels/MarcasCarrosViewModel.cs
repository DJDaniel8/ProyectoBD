using ProyectoBD.ViewModels.ResidentesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.ViewModels.MarcasCarrosViewModels
{
    public class MarcasCarrosViewModel : ViewModelBase
    {
        public MarcasCarrosViewModel()
        {
            VerMarcasCarrosViewModel = new();
            VerMarcasCarrosViewModel.MarcasCarrosViewModel = this;
            CrearMarcasCarrosViewModel = new();
            CrearMarcasCarrosViewModel.MarcasCarrosViewModel = this;
        }

        public VerMarcasCarrosViewModel VerMarcasCarrosViewModel { get; set; }
        public CrearMarcasCarrosViewModel CrearMarcasCarrosViewModel { get; set; }

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
    }
}

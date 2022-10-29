using ProyectoBD.ViewModels.ResidentesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.ViewModels.CarrosViewModels
{
    public class CarrosViewModel : ViewModelBase
    {
        public CarrosViewModel()
        {
            VerCarrosViewModel = new();
            VerCarrosViewModel.CarrosViewModel = this;
            CrearCarrosViewModel = new();
            CrearCarrosViewModel.CarrosViewModel = this;
        }

        public VerCarrosViewModel VerCarrosViewModel { get; set; }
        public CrearCarrosViewModel CrearCarrosViewModel { get; set; }

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

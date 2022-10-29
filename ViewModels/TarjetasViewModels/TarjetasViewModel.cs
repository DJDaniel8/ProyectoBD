using ProyectoBD.ViewModels.CarrosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.ViewModels.TarjetasViewModels
{
    public class TarjetasViewModel : ViewModelBase
    {
        public TarjetasViewModel()
        {
            VerTarjetasViewModel = new();
            VerTarjetasViewModel.TarjetasViewModel = this;
            CrearTarjetaViewModel = new();
            CrearTarjetaViewModel.TarjetasViewModel = this;
        }

        public VerTarjetasViewModel VerTarjetasViewModel { get; set; }
        public CrearTarjetaViewModel CrearTarjetaViewModel { get; set; }

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

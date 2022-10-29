using ProyectoBD.ViewModels.TarjetasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.ViewModels.PagosViewModels
{
    public class PagosViewModel : ViewModelBase
    {
        public PagosViewModel()
        {
            VerPagosViewModel = new();
            VerPagosViewModel.PagosViewModel = this;
            CrearPagosViewModel = new();
            CrearPagosViewModel.PagosViewModel = this;
        }

        public VerPagosViewModel VerPagosViewModel { get; set; }
        public CrearPagosViewModel CrearPagosViewModel { get; set; }

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

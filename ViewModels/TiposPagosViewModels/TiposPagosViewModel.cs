using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.ViewModels.TiposPagosViewModels
{
    public class TiposPagosViewModel : ViewModelBase
    {
        public TiposPagosViewModel()
        {
            VerTiposPagosViewModel = new();
            VerTiposPagosViewModel.TiposPagosViewModel = this;
            CrearTiposPagosViewModel = new();
            CrearTiposPagosViewModel.TiposPagosViewModel = this;
        }

        public VerTiposPagosViewModel VerTiposPagosViewModel { get; set; }
        public CrearTiposPagosViewModel CrearTiposPagosViewModel { get; set; }

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

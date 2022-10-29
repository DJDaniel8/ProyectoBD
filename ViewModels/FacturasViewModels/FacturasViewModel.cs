using ProyectoBD.ViewModels.CarrosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.ViewModels.FacturasViewModels
{
    public class FacturasViewModel : ViewModelBase
    {
        public FacturasViewModel()
        {
            VerFacturasViewModel = new();
            VerFacturasViewModel.FacturasViewModel = this;
            CrearFacturasViewModel = new();
            CrearFacturasViewModel.FacturasViewModel = this;
        }

        public VerFacturasViewModel VerFacturasViewModel { get; set; }
        public CrearFacturasViewModel CrearFacturasViewModel { get; set; }

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

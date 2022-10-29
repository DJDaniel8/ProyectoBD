using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.FacturasViewModels;
using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using ProyectoBD.ViewModels.NosotrosViewModels;
using ProyectoBD.ViewModels.PagosViewModels;
using ProyectoBD.ViewModels.ResidentesViewModels;
using ProyectoBD.ViewModels.TarjetasViewModels;
using ProyectoBD.ViewModels.TiposPagosViewModels;
using ProyectoBD.ViewModels.TrabajadoresViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
		public HomeViewModel()
		{
			NosotrosViewModel = new();
			TrabajadoresViewModel = new();
			ResidentesViewModels = new();
			MarcasCarrosViewModel = new();
			CarrosViewModel = new();
			TarjetasViewModel = new();
			TiposPagosViewModel = new();
			PagosViewModel = new();
			FacturasViewModel = new();
		}

        public NosotrosViewModel NosotrosViewModel { get; set; }
        public TrabajadoresViewModel TrabajadoresViewModel { get; set; }
		public ResidentesViewModel ResidentesViewModels { get; set; }
		public MarcasCarrosViewModel MarcasCarrosViewModel { get; set; }
		public CarrosViewModel CarrosViewModel { get; set; }
		public TarjetasViewModel TarjetasViewModel { get; set; }
		public TiposPagosViewModel TiposPagosViewModel { get; set; }
		public PagosViewModel PagosViewModel { get; set; }
		public FacturasViewModel FacturasViewModel { get; set; }


        private bool _IsNosotrosChecked = true;
		public bool IsNosotrosChecked
		{
			get
			{
				return _IsNosotrosChecked;
			}
			set
			{
				_IsNosotrosChecked = value;
				if (value) NosotrosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
				else NosotrosViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
				OnPropertyChanged(nameof(IsNosotrosChecked));
			}
		}

		private bool _IsTrabajadoresChecked;
		public bool IsTrabajadoresChecked
		{
			get
			{
				return _IsTrabajadoresChecked;
			}
			set
			{
				_IsTrabajadoresChecked = value;
				if (value) TrabajadoresViewModel.ControlVisibility = System.Windows.Visibility.Visible;
				else TrabajadoresViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
				OnPropertyChanged(nameof(IsTrabajadoresChecked));
			}
		}

		private bool _IsResidentesChecked;
		public bool IsResidentesChecked
		{
			get
			{
				return _IsResidentesChecked;
			}
			set
			{
				_IsResidentesChecked = value;
                if (value) ResidentesViewModels.ControlVisibility = System.Windows.Visibility.Visible;
                else ResidentesViewModels.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsResidentesChecked));
			}
		}

        private bool _IsMarcasChecked;
        public bool IsMarcasChecked
        {
            get
            {
                return _IsMarcasChecked;
            }
            set
            {
                _IsMarcasChecked = value;
                if (value) MarcasCarrosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else MarcasCarrosViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsMarcasChecked));
            }
        }

		private bool _IsCarrosChecked;
		public bool IsCarrosChecked
		{
			get
			{
				return _IsCarrosChecked;
			}
			set
			{
				_IsCarrosChecked = value;
                if (value) CarrosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else CarrosViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsCarrosChecked));
			}
		}

		private bool _IsTarjetasChecked;
		public bool IsTarjetasChecked
		{
			get
			{
				return _IsTarjetasChecked;
			}
			set
			{
				_IsTarjetasChecked = value;
                if (value) TarjetasViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else TarjetasViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsTarjetasChecked));
			}
		}

		private bool _IsTiposChecked;
		public bool IsTiposChecked
		{
			get
			{
				return _IsTiposChecked;
			}
			set
			{
				_IsTiposChecked = value;
                if (value) TiposPagosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else TiposPagosViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsTiposChecked));
			}
		}

		private bool _IsPagosChecked;
		public bool IsPagosChecked
		{
			get
			{
				return _IsPagosChecked;
			}
			set
			{
				_IsPagosChecked = value;
                if (value) PagosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else PagosViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsPagosChecked));
			}
		}

		private bool _IsFacturasChecked;
		public bool IsFacturasChecked
		{
			get
			{
				return _IsFacturasChecked;
			}
			set
			{
				_IsFacturasChecked = value;
                if (value) FacturasViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else FacturasViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsFacturasChecked));
			}
		}
	}


}

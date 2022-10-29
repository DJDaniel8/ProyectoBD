using ProyectoBD.ViewModels.CarrosViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.ViewModels.TarjetasViewModels
{
    public class TarjetaViewModel : ViewModelBase
    {
        private  NumberFormatInfo nfi = new CultureInfo("es-GT", false).NumberFormat;

        private int _Id;
		public int Id
		{
			get
			{
				return _Id;
			}
			set
			{
				_Id = value;
				OnPropertyChanged(nameof(Id));
			}
		}

		private string _Numero = string.Empty;
		public string Numero
		{
			get
			{
				return _Numero;
			}
			set
			{
				_Numero = value;
				OnPropertyChanged(nameof(Numero));
			}
		}

		private DateTime _FechaIVigencia = DateTime.Now;
		public DateTime FechaIVigencia
		{
			get
			{
				return _FechaIVigencia;
			}
			set
			{
				_FechaIVigencia = value;
				FechaVigencia = FechaIVigencia.ToString("d", nfi) + " - " + FechaFVigencia.ToString("d", nfi);
				OnPropertyChanged(nameof(FechaIVigencia));
			}
		}

		private DateTime _FechaFVigencia = DateTime.Now;
		public DateTime FechaFVigencia
		{
			get
			{
				return _FechaFVigencia;
			}
			set
			{
				_FechaFVigencia = value;
                FechaVigencia = FechaIVigencia.ToString("d", nfi) + " - " + FechaFVigencia.ToString("d", nfi);
                OnPropertyChanged(nameof(FechaFVigencia));
			}
		}

		private bool _Estatus;
		public bool Estatus
		{
			get
			{
				return _Estatus;
			}
			set
			{
				_Estatus = value;
				OnPropertyChanged(nameof(Estatus));
			}
		}

		private CarroViewModel _Carro = new();
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

		private string _FechaVigencia = string.Empty;
		public string FechaVigencia
		{
			get
			{
				return _FechaVigencia;
			}
			set
			{
				_FechaVigencia = value;
				OnPropertyChanged(nameof(FechaVigencia));
			}
		}
	}
}

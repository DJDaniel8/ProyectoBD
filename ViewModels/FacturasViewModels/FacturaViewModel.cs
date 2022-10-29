using ProyectoBD.ViewModels.PagosViewModels;
using ProyectoBD.ViewModels.ResidentesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps.Serialization;

namespace ProyectoBD.ViewModels.FacturasViewModels
{
    public class FacturaViewModel :ViewModelBase
    {
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

		private DateTime _Fecha = DateTime.Now;
		public DateTime Fecha
		{
			get
			{
				return _Fecha;
			}
			set
			{
				_Fecha = value;
				OnPropertyChanged(nameof(Fecha));
			}
		}

		private string _Nit = string.Empty;
		public string Nit
		{
			get
			{
				return _Nit;
			}
			set
			{
				_Nit = value;
				OnPropertyChanged(nameof(Nit));
			}
		}

		private string _NoDoc = string.Empty;
		public string NoDoc
		{
			get
			{
				return _NoDoc;
			}
			set
			{
				_NoDoc = value;
				OnPropertyChanged(nameof(NoDoc));
			}
		}

		private ResidenteViewModel _Residente = new();
		public ResidenteViewModel Residente
        {
			get
			{
				return _Residente;
			}
			set
			{
                _Residente = value;
				OnPropertyChanged(nameof(Residente));
			}
		}

		private PagoViewModel _Pago = new();
		public PagoViewModel Pago
        {
			get
			{
				return _Pago;
			}
			set
			{
                _Pago = value;
				OnPropertyChanged(nameof(Pago));
			}
		}

		private decimal _Total;
		public decimal Total
		{
			get
			{
				return _Total;
			}
			set
			{
				_Total = value;
				OnPropertyChanged(nameof(Total));
			}
		}
		public List<DetalleFacturaViewModel> DetallesFacturas { get; set; } = new();
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.ViewModels.FacturasViewModels
{
    public class DetalleFacturaViewModel : ViewModelBase
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

		private int _Cantidad;
		public int Cantidad
		{
			get
			{
				return _Cantidad;
			}
			set
			{
				_Cantidad = value;
				Total = Cantidad * PrecioVenta;
				OnPropertyChanged(nameof(Cantidad));
			}
		}

		private string _Descripcion = string.Empty;
		public string Descripcion
		{
			get
			{
				return _Descripcion;
			}
			set
			{
				_Descripcion = value;
				OnPropertyChanged(nameof(Descripcion));
			}
		}

		private decimal _PrecioVenta;
		public decimal PrecioVenta
		{
			get
			{
				return _PrecioVenta;
			}
			set
			{
				_PrecioVenta = value;
                Total = Cantidad * PrecioVenta;
                OnPropertyChanged(nameof(PrecioVenta));
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
	}
}

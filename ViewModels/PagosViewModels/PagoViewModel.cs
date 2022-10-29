using ProyectoBD.ViewModels.TiposPagosViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.ViewModels.PagosViewModels
{
    public class PagoViewModel : ViewModelBase
    {
        private NumberFormatInfo nfi = new CultureInfo("es-GT", false).NumberFormat;
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

		private decimal _Monto;
		public decimal Monto
		{
			get
			{
				return _Monto;
			}
			set
			{
				_Monto = value;
				Descripcion = Monto.ToString("c", nfi) + " - " + TipoPago.Nombre + " - " + NoDoc;
				OnPropertyChanged(nameof(Monto));
			}
		}

		private string _NoDoc= string.Empty;
		public string NoDoc
		{
			get
			{
				return _NoDoc;
			}
			set
			{
				_NoDoc = value;
                Descripcion = Monto.ToString("c", nfi) + " " + TipoPago.Nombre + " " + NoDoc;
                OnPropertyChanged(nameof(NoDoc));
			}
		}

		private TipoPagoViewModel _TipoPago = new();
		public TipoPagoViewModel TipoPago
        {
			get
			{
				return _TipoPago;
			}
			set
			{
                _TipoPago = value;
                Descripcion = Monto.ToString("c", nfi) + " " + TipoPago.Nombre + " " + NoDoc;
                OnPropertyChanged(nameof(TipoPago));
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
	}
}

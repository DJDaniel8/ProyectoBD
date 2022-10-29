using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.ViewModels.TiposPagosViewModels
{
    public class TipoPagoViewModel : ViewModelBase
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

		private string _Nombre = String.Empty;
		public string Nombre
		{
			get
			{
				return _Nombre;
			}
			set
			{
				_Nombre = value;
				OnPropertyChanged(nameof(Nombre));
			}
		}
	}
}

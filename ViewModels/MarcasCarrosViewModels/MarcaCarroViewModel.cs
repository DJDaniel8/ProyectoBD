using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.ViewModels.MarcasCarrosViewModels
{
    public class MarcaCarroViewModel : ViewModelBase
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

		private string _Nombre =string.Empty;
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

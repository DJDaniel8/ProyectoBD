using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using ProyectoBD.ViewModels.ResidentesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.ViewModels.CarrosViewModels
{
    public class CarroViewModel : ViewModelBase
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

		private string _Placa = string.Empty;
		public string Placa
		{
			get
			{
				return _Placa;
			}
			set
			{
				_Placa = value;
                Descripcion = Marca.Nombre + " " + Modelo + " " + Color + " " + Placa;
                OnPropertyChanged(nameof(Placa));
			}
		}

		private string _Modelo = string.Empty;
		public string Modelo
		{
			get
			{
				return _Modelo;
			}
			set
			{
				_Modelo = value;
                Descripcion = Marca.Nombre + " " + Modelo + " " + Color + " " + Placa;
                OnPropertyChanged(nameof(Modelo));
			}
		}

		private string _Color =string.Empty;
		public string Color
		{
			get
			{
				return _Color;
			}
			set
			{
				_Color = value;
                Descripcion = Marca.Nombre + " " + Modelo + " " + Color + " " + Placa;
                OnPropertyChanged(nameof(Color));
			}
		}

		private MarcaCarroViewModel _Marca = new();
		public MarcaCarroViewModel Marca
        {
			get
			{
				return _Marca;
			}
			set
			{
                _Marca = value;
				Descripcion = Marca.Nombre + " " + Modelo + " " + Color + " " + Placa;
				OnPropertyChanged(nameof(Marca));
			}
		}

		private ResidenteViewModel _Dueño = new();
		public ResidenteViewModel Dueño
        {
			get
			{
				return _Dueño;
			}
			set
			{
                _Dueño = value;
				OnPropertyChanged(nameof(Dueño));
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

using ProyectoBD.Commands.MainWindowCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoBD.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
		public MainWindowViewModel()
		{
			IngresarCommand = new IngresarCommand(this);
		}
		public ICommand IngresarCommand { get; }

		private string _Usuario = string.Empty;
		public string Usuario
		{
			get
			{
				return _Usuario;
			}
			set
			{
				_Usuario = value;
				OnPropertyChanged(nameof(Usuario));
			}
		}

		private string _Contraseña = string.Empty;
		public string Contraseña
		{
			get
			{
				return _Contraseña;
			}
			set
			{
				_Contraseña = value;
				OnPropertyChanged(nameof(Contraseña));
			}
		}

	}
}

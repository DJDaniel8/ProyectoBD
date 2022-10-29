using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.ViewModels.TrabajadoresViewModels
{
    public class EmpleadosViewModel : ViewModelBase
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

        private string _PrimerNombre =string.Empty;
        public string PrimerNombre
        {
            get
            {
                return _PrimerNombre;
            }
            set
            {
                _PrimerNombre = value;
                NombreCompleto = PrimerNombre + " " + SegundoNombre + " " + PrimerApellido + " " + SegundoApellido;
                OnPropertyChanged(nameof(PrimerNombre));
            }
        }

        private string _SegundoNombre = string.Empty;
        public string SegundoNombre
        {
            get
            {
                return _SegundoNombre;
            }
            set
            {
                _SegundoNombre = value;
                NombreCompleto = PrimerNombre + " " + SegundoNombre + " " + PrimerApellido + " " + SegundoApellido;
                OnPropertyChanged(nameof(SegundoNombre));
            }
        }

        private string _PrimerApellido = string.Empty;
        public string PrimerApellido
        {
            get
            {
                return _PrimerApellido;
            }
            set
            {
                _PrimerApellido = value;
                NombreCompleto = PrimerNombre + " " + SegundoNombre + " " + PrimerApellido + " " + SegundoApellido;
                OnPropertyChanged(nameof(PrimerApellido));
            }
        }

        private string _SegundoApelldio = string.Empty;
        public string SegundoApellido
        {
            get
            {
                return _SegundoApelldio;
            }
            set
            {
                _SegundoApelldio = value;
                NombreCompleto = PrimerNombre + " " + SegundoNombre + " " + PrimerApellido + " " + SegundoApellido;
                OnPropertyChanged(nameof(SegundoApellido));
            }
        }

        private string _Email = string.Empty;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _Sexo = string.Empty;
        public string Sexo
        {
            get
            {
                return _Sexo;
            }
            set
            {
                _Sexo = value;
                OnPropertyChanged(nameof(Sexo));
            }
        }

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

        private string _Direccion = string.Empty;
        public string Direccion
        {
            get
            {
                return _Direccion;
            }
            set
            {
                _Direccion = value;
                OnPropertyChanged(nameof(Direccion));
            }
        }

        private string _Telefono = string.Empty;
        public string Telefono
        {
            get
            {
                return _Telefono;
            }
            set
            {
                _Telefono = value;
                OnPropertyChanged(nameof(Telefono));
            }
        }

        private string _NombreCompleto = string.Empty; 
        public string NombreCompleto
        {
            get
            {
                return _NombreCompleto;
            }
            set
            {
                _NombreCompleto = value;
                OnPropertyChanged(nameof(NombreCompleto));
            }
        }
    }
}

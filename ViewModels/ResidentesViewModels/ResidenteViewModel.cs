using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.ViewModels.ResidentesViewModels
{
    public class ResidenteViewModel : ViewModelBase
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

        private string _PrimerNombre = string.Empty;
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

        private string _Calle = string.Empty;
        public string Calle
        {
            get
            {
                return _Calle;
            }
            set
            {
                _Calle = value;
                Direccion = "Calle " + Calle + " Zona " + Zona + " No. Casa " + NoCasa;
                OnPropertyChanged(nameof(Calle));
            }
        }

        private string _Zona = string.Empty;
        public string Zona
        {
            get
            {
                return _Zona;
            }
            set
            {
                _Zona = value;
                Direccion = "Calle " + Calle + " Zona " + Zona + " No. Casa " + NoCasa;
                OnPropertyChanged(nameof(Zona));
            }
        }

        private string _NoCasa = string.Empty;
        public string NoCasa
        {
            get
            {
                return _NoCasa;
            }
            set
            {
                _NoCasa = value;
                Direccion = "Calle " + Calle + " Zona " + Zona + " No. Casa " + NoCasa;
                OnPropertyChanged(nameof(NoCasa));
            }
        }

        private bool _Estatus = false;
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

        private string _DPI = string.Empty;
        public string DPI
        {
            get
            {
                return _DPI;
            }
            set
            {
                _DPI = value;
                NombreDPI = DPI + " - " + NombreCompleto;
                OnPropertyChanged(nameof(DPI));
            }
        }

        private DateTime _FechaNacimiento = DateTime.Now;
        public DateTime FechaNacimiento 
        {
            get
            {
                return _FechaNacimiento;
            }
            set
            {
                _FechaNacimiento = value;
                OnPropertyChanged(nameof(FechaNacimiento));
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
                NombreDPI = DPI + " - " + NombreCompleto; 
                OnPropertyChanged(nameof(NombreCompleto));
            }
        }

        private string _NombreDPI = string.Empty;
        public string NombreDPI
        {
            get
            {
                return _NombreDPI;
            }
            set
            {
                _NombreDPI = value;
                OnPropertyChanged(nameof(NombreDPI));
            }
        }
    }
}

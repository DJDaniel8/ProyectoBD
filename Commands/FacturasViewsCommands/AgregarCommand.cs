using ProyectoBD.ViewModels.FacturasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.FacturasViewsCommands
{
    public class AgregarCommand : CommandBase
    {
        private CrearFacturasViewModel _viewModel;
        public AgregarCommand(CrearFacturasViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.Agregar();
        }
    }
}

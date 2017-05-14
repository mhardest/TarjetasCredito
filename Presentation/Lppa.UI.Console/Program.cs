using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lppa.Entities;

namespace Lppa.UI.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var controller = new Lppa.UI.Process.ProyectoComponentController();
            var lista = controller.ListarProyectos();

            foreach (var item in lista)
            {
                System.Console.WriteLine("Codigo: {0} - Descripcion: {1}", item.Codigo,item.Descripcion);
            }
        }

        private static void Agregar()
        {
            var controller = new Lppa.UI.Process.ProyectoComponentController();
            var proyecto = new Proyecto
            {
                Codigo = 100,
                Descripcion = "Proyecto LPPA",
                RowId = Guid.NewGuid()
            };
            controller.AgregarUnProyecto(proyecto);
        }
    }
}

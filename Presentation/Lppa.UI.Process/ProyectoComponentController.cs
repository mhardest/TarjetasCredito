using Lppa.Business;
using Lppa.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace Lppa.UI.Process
{
    /// <summary>
    ///  controller component.
    /// </summary>
    public partial class ProyectoComponentController
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">A id value.</param>
        /// <returns>Returns a Proyecto object.</returns>
        public Proyecto ListarProyectosPorCodigo(int id)
        {
            var bc = new GestorBusinessComponent();
            return bc.ListarProyectosPorCodigo(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a List Proyecto object.</returns>
        public List<Proyecto> ListarProyectos()
        {
            var bc = new GestorBusinessComponent();
            return bc.ListarProyectos();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">A id value.</param>
        public void EliminarProyecto(int id)
        {
            var bc = new GestorBusinessComponent();
            bc.EliminarProyecto(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proyecto">A proyecto value.</param>
        public void EditarProyecto(Proyecto proyecto)
        {
            var bc = new GestorBusinessComponent();
            bc.EditarProyecto(proyecto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proyecto">A proyecto value.</param>
        /// <returns>Returns a Proyecto object.</returns>
        public Proyecto AgregarUnProyecto(Proyecto proyecto)
        {
            var bc = new GestorBusinessComponent();
            return bc.AgregarUnProyecto(proyecto);
        }
    }
}

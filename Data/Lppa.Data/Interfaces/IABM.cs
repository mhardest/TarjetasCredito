using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Data.Interfaces
{
    public interface IABM<T>
    {

        /// 
        /// <param name="Lista"></param>
        //List<T> ConsultarTodos(string store, Dictionary<string, object> parametros);
        IEnumerable<T> ConsultarTodos();


        /// 
        /// <param name="Entidad"></param>
        int Ingresar(T Entidad);

        /// 
        /// <param name="Entidad"></param>
        int Modifcar(T Entidad);

        /// 
        /// <param name="Entidad"></param>
        int Eliminar(T Entidad);

        /// 
        /// <param name="Entidad"></param>
        T Consultar(T Entidad);
    }//end IABM
}

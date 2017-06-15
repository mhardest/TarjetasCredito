using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Data.Mapper
{
    public class MapperGenerico<T> where T : class
    {



        Dictionary<string, object> _instanciareferencia = new Dictionary<string, object>();
        Dictionary<string, object> _instanciaobjetoslista = new Dictionary<string, object>();
        object listafias = null;
        string nombrepropiedadlista = null;
        object instanciatipolista = null;


        private IList<T> LimpiarObjetos(IList<T> objetos)
        {


            IDictionary<object, object> _dict = new Dictionary<object, object>();

            IList<T> _lista = new List<T>();


            foreach (var principal in objetos)
            {
                object objeto;

                if (_lista.Contains(principal))
                {
                    objeto = _lista.Where(c => c.Equals(principal)).First();

                }
                else
                {

                    objeto = principal;
                    _lista.Add(principal);
                }

                foreach (var item in principal.GetType().GetProperties().Where(c => c.PropertyType.GetInterface(typeof(IList<>).FullName) != null))
                {

                    var xxxxxxx = item.GetValue(principal);

                    if (xxxxxxx != null && objeto.Equals(principal))
                    {



                        IList list;
                        if (_dict.Keys.Contains(objeto))
                        {
                            object value;
                            _dict.TryGetValue(objeto, out value);
                            list = (IList)value;
                        }
                        else
                        {
                            object _listacoleecion;
                            _listacoleecion = Activator.CreateInstance(item.PropertyType);
                            list = (IList)_listacoleecion;
                            _dict.Add(objeto, list);
                        }

                        foreach (var u in ((IList)xxxxxxx))
                        {
                            list.Add(u);
                        }



                        objeto.GetType().GetProperty(item.Name).SetValue(objeto, null);
                        objeto.GetType().GetProperty(item.Name).SetValue(objeto, list);

                    }


                }



            }



            return _lista;






        }


        public IList<T> DataTableToObject(DataTable dataTable)
        {
            try
            {

                var tipoobjeto = typeof(T);
                IList<T> listaobjeto = new List<T>();

                foreach (DataRow fila in dataTable.Rows)
                {

                    listafias = null;
                    nombrepropiedadlista = null;
                    instanciatipolista = null;

                    T instancia = (T)Activator.CreateInstance(tipoobjeto);
                    datarowtoobject(fila, instancia);


                    listaobjeto.Add(instancia);



                    _instanciareferencia.Clear();
                    _instanciaobjetoslista.Clear();
                }


                return LimpiarObjetos(listaobjeto);

                //return listaobjeto;
            }
            catch (Exception ex)
            {
                var mens = ex.Message;
                return null;
            }
        }


        private void datarowtoobject(DataRow fila, object objeto)
        {
            var tipo = objeto.GetType();

            //Console.WriteLine(objeto.GetType().Name);
            //object listafias = null;
            //string nombrepropiedadlista = null;
            //object instanciatipolista = null;

            foreach (DataColumn column in fila.Table.Columns)
            {
                var propiedad = tipo.GetProperty(column.ColumnName);

                if (propiedad != null)
                {
                    propiedad.SetValue(objeto,
                        fila[column.ColumnName] != DBNull.Value ? fila[column.ColumnName] : null);
                }
                else
                {

                    //Colleciones
                    BuscarCollecciones(tipo, objeto, column.ColumnName, fila);

                    //Referencias
                    BuscarReferencias(tipo, objeto, column.ColumnName, fila);
                }
            }
            if (listafias != null && instanciatipolista != null)
            {
                if (listafias is IList)
                {


                    foreach (var it in instanciatipolista.GetType().GetProperties().Where(c => c.PropertyType == tipo))
                    {

                        it.SetValue(instanciatipolista, objeto);

                    }

                    (listafias as IList).Add(instanciatipolista);
                    tipo.GetProperty(nombrepropiedadlista).SetValue(objeto, listafias);



                }

            }




        }


        private void BuscarCollecciones(Type tipo, object objeto, string columnname, DataRow fila)
        {
            if (objeto != null)
            {
                //Console.WriteLine("-->" + objeto.GetType().Name);
                foreach (var item in tipo.GetProperties().Where(c => c.PropertyType.GetInterface(typeof(IList<>).FullName) != null))
                {
                    nombrepropiedadlista = item.Name;
                    var f = item.PropertyType;

                    listafias = Activator.CreateInstance(f);
                    var i = item.PropertyType.GetProperties().Where(c => c.PropertyType.BaseType == typeof(AbstractEntidades))
                        .Select(c => new { propiedades = c.PropertyType.GetProperties(), tipo = c.PropertyType }).ToList();


                    foreach (var ite in item.PropertyType.GetProperties().Where(c => c.PropertyType.GetInterface(typeof(IList<>).FullName) != null && c.PropertyType != tipo && c.PropertyType != item.PropertyType))
                    {
                        BuscarCollecciones(ite.GetType(), ite.GetType().GetProperties().Any(c => c.Name == columnname) ? Activator.CreateInstance(ite.PropertyType) : null, columnname, fila);
                    }

                    foreach (var propie in i.SelectMany(c => c.propiedades).Where(c => c.Name == columnname))
                    {




                        if (_instanciaobjetoslista.ContainsKey(i.Select(c => c.tipo).FirstOrDefault().Name))
                        {
                            instanciatipolista = _instanciaobjetoslista.Where(c => c.Key == i.Select(x => x.tipo).FirstOrDefault().Name).Select(c => c.Value).FirstOrDefault();

                        }
                        else
                        {

                            instanciatipolista = Activator.CreateInstance(i.Select(c => c.tipo).FirstOrDefault());
                            _instanciaobjetoslista.Add(i.Select(c => c.tipo).FirstOrDefault().Name, instanciatipolista);

                        }

                        propie.SetValue(instanciatipolista, fila[columnname] != DBNull.Value ? fila[columnname] : null);






                    }




                }

            }


        }


        private void BuscarReferencias(Type tipo, object objeto, string columnname, DataRow fila)
        {
            if (objeto != null)
            {
                //Console.WriteLine("-->" + objeto.GetType().Name);
                foreach (
                           var entities in
                               tipo.GetProperties().Where(x => x.PropertyType.BaseType == typeof(AbstractEntidades)))
                {

                    foreach (
                 var d in
                     entities.PropertyType.GetProperties().Where(x => x.PropertyType.BaseType == typeof(AbstractEntidades) && x.PropertyType != tipo && x.PropertyType != entities.PropertyType))

                    {
                        BuscarReferencias(d.GetType(), d.GetType().GetProperties().Any(c => c.Name == columnname) ? Activator.CreateInstance(d.PropertyType) : null, columnname, fila);
                    }

                    object instancia = null;
                    foreach (var propiedades in entities.PropertyType.GetProperties().Where(c => c.Name == columnname))
                    {



                        if (_instanciareferencia.ContainsKey(tipo.GetProperty(entities.Name).Name))
                        {

                            instancia =
                                _instanciareferencia.Where(x => x.Key == tipo.GetProperty(entities.Name).Name).Select(x => x.Value).First();
                        }
                        else
                        {
                            instancia = Activator.CreateInstance(entities.PropertyType);

                            _instanciareferencia.Add(tipo.GetProperty(entities.Name).Name, instancia);
                        }


                        propiedades.SetValue(instancia,
                            fila[columnname] != DBNull.Value ? fila[columnname] : null);







                        if (instancia != null)
                        {
                            tipo.GetProperty(entities.Name).SetValue(objeto, instancia);
                        }
                    }


                }

            }
        }

        private class AbstractEntidades
        {
        }
    }
}

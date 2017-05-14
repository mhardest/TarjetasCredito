using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace Lppa.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Proyecto : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Codigo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        
    }
}

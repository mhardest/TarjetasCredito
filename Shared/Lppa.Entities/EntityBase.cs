using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Lppa.Entities
{
    /// <summary>
    /// Base entity class.
    /// </summary>
    [DataContract]
    public class EntityBase : INotifyPropertyChanged
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public int Id { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 
        /// </summary>
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            return this.GetType().Name + ": " +
                string.Join("|", this.GetType().GetProperties()
                .Where(p => !p.PropertyType.IsGenericType && !p.PropertyType.IsArray)
                .Select(p => string.Format("{0}={1}", p.Name, p.GetValue(this, null))));
        }

        #region Implementing audit Pattern
        

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Guid RowId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime ChangedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Guid ChangedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime? DeletedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Guid DeletedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool IsDeleted { get; set; }
        #endregion

    }
}

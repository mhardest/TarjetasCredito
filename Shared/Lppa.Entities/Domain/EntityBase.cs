using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Lppa.Entities.Domain
{
    /// <summary>
    /// Base entity class.
    /// </summary>
    [Serializable]
    public abstract class EntityBase : INotifyPropertyChanged
    {
        public long Id { get; set; }

        #region Constructor

        protected EntityBase()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.RowId = Guid.NewGuid();
        }

        #endregion

        #region Implementing Audit Pattern


        /// <summary>
        /// 
        /// </summary>
        public Guid RowId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ChangedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? ChangedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DeletedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? DeletedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }

        #endregion

        #region Métodos Publicos

        public void Eliminar()
        {
            this.IsDeleted = true;
            this.ChangedOn = DateTime.UtcNow;
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            var propertyValues = this.GetType().GetProperties()
                .Where(p => !p.PropertyType.IsGenericType && !p.PropertyType.IsArray)
                .Select(p => $"{p.Name}={p.GetValue(this, null)}");

            return string.Concat(this.GetType().Name, ":", string.Join("|", propertyValues));
        }
    }
}
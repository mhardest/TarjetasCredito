using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Lppa.Entities;

namespace Lppa.Data
{
    /// <summary>
    /// Proyecto data access component. Gestiona operaciones CRUD para la tabla Proyecto.
    /// </summary>
    public partial class ProyectoRepository : DataAccessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="proyecto"></param>
        /// <returns></returns>
        public Proyecto Create(Proyecto proyecto)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Proyecto ([Codigo], [Descripcion], [RowId], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy], [DeletedOn], [DeletedBy], [IsDeleted]) " +
                "VALUES(@Codigo, @Descripcion, @RowId, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy, @DeletedOn, @DeletedBy, @IsDeleted); SELECT SCOPE_IDENTITY();";

            // Connect to database.
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Codigo", DbType.Int32, proyecto.Codigo);
                db.AddInParameter(cmd, "@Descripcion", DbType.String, proyecto.Descripcion);
                db.AddInParameter(cmd, "@RowId", DbType.Guid, proyecto.RowId);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, proyecto.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Guid, proyecto.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, proyecto.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Guid, proyecto.ChangedBy);
                db.AddInParameter(cmd, "@DeletedOn", DbType.DateTime2, proyecto.DeletedOn);
                db.AddInParameter(cmd, "@DeletedBy", DbType.Guid, proyecto.DeletedBy);
                db.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, proyecto.IsDeleted);

                proyecto.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return proyecto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proyecto"></param>
        public void UpdateById(Proyecto proyecto)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Proyecto " +
                "SET " +
                    "[Codigo]=@Codigo, " +
                    "[Descripcion]=@Descripcion, " +
                    "[RowId]=@RowId, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy, " +
                    "[DeletedOn]=@DeletedOn, " +
                    "[DeletedBy]=@DeletedBy, " +
                    "[IsDeleted]=@IsDeleted " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Codigo", DbType.Int32, proyecto.Codigo);
                db.AddInParameter(cmd, "@Descripcion", DbType.String, proyecto.Descripcion);
                db.AddInParameter(cmd, "@RowId", DbType.Guid, proyecto.RowId);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, proyecto.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Guid, proyecto.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, proyecto.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Guid, proyecto.ChangedBy);
                db.AddInParameter(cmd, "@DeletedOn", DbType.DateTime2, proyecto.DeletedOn);
                db.AddInParameter(cmd, "@DeletedBy", DbType.Guid, proyecto.DeletedBy);
                db.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, proyecto.IsDeleted);
                db.AddInParameter(cmd, "@Id", DbType.Int32, proyecto.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.Proyecto WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Proyecto SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Codigo], [Descripcion], [RowId], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]" +
                        ", [DeletedOn], [DeletedBy], [IsDeleted] " +
                "FROM dbo.Proyecto  " +
                "WHERE [Id]=@Id ";

            Proyecto proyecto = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        proyecto = LoadProyecto(dr);
                    }
                }
            }

            return proyecto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Proyecto> Select()
        {
            // WARNING! 
            // La siguiente consulta SQL no contiene una condición WHERE.
            // Se recomienda incluir una condición WHERE para evitar problemas de rendimiento
            // al consultar conjuntos de resultados grandes.
            const string SQL_STATEMENT =
                "SELECT [Id], [Codigo], [Descripcion], [RowId], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]" +
                        ", [DeletedOn], [DeletedBy], [IsDeleted] " +
                "FROM dbo.Proyecto ";

            var result = new List<Proyecto>();

            // Connect to database.
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create -> new Proyecto
                        var proyecto = LoadProyecto(dr);

                        result.Add(proyecto);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr">A DataReader object.</param>
        /// <returns>Returns -> Proyecto.</returns>		
        private static Proyecto LoadProyecto(IDataReader dr)
        {
            // Create a new Proyecto
            var proyecto = new Proyecto
            {
                Id = GetDataValue<int>(dr, "Id"),
                Codigo = GetDataValue<int>(dr, "Codigo"),
                Descripcion = GetDataValue<string>(dr, "Descripcion"),
                RowId = GetDataValue<Guid>(dr, "RowId"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<Guid>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<Guid>(dr, "ChangedBy"),
                DeletedOn = GetDataValue<DateTime?>(dr, "DeletedOn"),
                DeletedBy = GetDataValue<Guid>(dr, "DeletedBy"),
                IsDeleted = GetDataValue<bool>(dr, "IsDeleted")
            };


            return proyecto;
        }
    }
}


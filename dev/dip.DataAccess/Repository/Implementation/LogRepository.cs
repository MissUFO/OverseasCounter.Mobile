using System;
using System.Collections.Generic;
using System.Data;
using dip.DataAccess.DataObject.Implementation;
using dip.DataAccess.Repository.Interface;

namespace dip.DataAccess.Repository.Implementation
{
    /// <summary>
    /// Save information about users usages
    /// </summary>
    public class LogRepository : IRepository<Log>
    {
        public string ConnectionString { get; set; }

        public LogRepository()
        {
            ConnectionString = DataAccess.ConnectionString.DbConnection;
        }

        /// <summary>
        /// Get list (NOT IMPLEMENTED)
        /// </summary>
        public List<Log> List()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get list (NOT IMPLEMENTED)
        /// </summary>
        public List<Log> List(Log entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get single item (NOT IMPLEMENTED)
        /// </summary>
        public Log Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add or update item
        /// </summary>
        public Log AddEdit(Log entity)
        {
           
            using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "[logs].[Log_AddEdit]";
                dataManager.Add("@UserId", SqlDbType.Int, ParameterDirection.Input, entity.UserId);
                dataManager.Add("@ActionType", SqlDbType.Int, ParameterDirection.Input, (int)entity.ActionType);
                dataManager.Add("@PageUrl", SqlDbType.NVarChar, ParameterDirection.Input, entity.PageUrl);
                dataManager.Add("@OccurredOn", SqlDbType.DateTime, ParameterDirection.Input, entity.OccurredOn);
                
                dataManager.ExecuteNonQuery();
                
            }

            return entity;
        }
    
    }
}
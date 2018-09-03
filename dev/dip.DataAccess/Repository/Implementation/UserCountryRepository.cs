using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using dip.DataAccess.DataManager.Extension;
using dip.DataAccess.DataObject.Implementation;
using dip.DataAccess.Repository.Interface;

namespace dip.DataAccess.Repository.Implementation
{
    /// <summary>
    ///Getting list of documents from database
    /// </summary>
    public class UserCountryRepository : IRepository<Document>
    {
        public string ConnectionString { get; set; }

        public UserCountryRepository()
        {
            ConnectionString = DataAccess.ConnectionString.DbConnection;
        }

        /// <summary>
        ///Get list (NOT IMPLEMENTED)
        /// </summary>
        public List<Document> List()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get list by deviceId
        /// </summary>
        public List<Document> List(Document entity)
        {
            var entities = new List<Document>();

            using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "[dbo].[Document_List]";
                dataManager.Add("@deviceId", SqlDbType.Int, ParameterDirection.Input, entity.DeviceId);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                entities.UnpackXML(xmlOut);
            }

            return entities;
        }

        /// <summary>
        /// Get single item
        /// </summary>
        public Document Get(int id)
        {
            var entity = new Document();

            using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
            {
                dataManager.ExecuteString = "[dbo].[Document_Get]";
                dataManager.Add("@Id", SqlDbType.Int, ParameterDirection.Input, id);
                dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
                dataManager.ExecuteReader();
                XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
                entity.UnpackXML(xmlOut.Element("Document"));
            }

            return entity;
        }

        /// <summary>
        /// Add or update item (NOT IMPLEMENTED)
        /// </summary>
        public Document AddEdit(Document entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete single item (NOT IMPLEMENTED)
        /// </summary>
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
       
    }
}

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
  /// Counting days in country
  /// </summary>
  public class DaysRepository : IRepository<Days>
  {
    public string ConnectionString { get; set; }

    public DaysRepository()
    {
      ConnectionString = DataAccess.ConnectionString.DbConnection;
    }

    /// <summary>
    /// Get list
    /// </summary>
    public List<Days> List()
    {
      return List(new Days() { UserId = 0, CountryId = 0, CountryVisaId = 0 });
    }

    /// <summary>
    /// Get list 
    /// </summary>
    public List<Days> List(Days entity)
    {
      var entities = new List<Days>();

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[dbo].[Days_List]";
        dataManager.Add("@UserId", SqlDbType.Int, ParameterDirection.Input, entity.UserId);
        dataManager.Add("@CountryId", SqlDbType.Int, ParameterDirection.Input, entity.CountryId);
        dataManager.Add("@CountryVisaId", SqlDbType.Int, ParameterDirection.Input, entity.CountryVisaId);
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
    public Days Get(int id)
    {
      var entity = new Days();

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[dbo].[Days_Get]";
        dataManager.Add("@Id", SqlDbType.Int, ParameterDirection.Input, id); //get all
        dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
        dataManager.ExecuteReader();
        XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
        entity.UnpackXML(xmlOut.Element("Day"));
      }

      return entity;
    }

    /// <summary>
    /// Add or update item
    /// </summary>
    public Days AddEdit(Days entity)
    {

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[dbo].[Days_AddEdit]";
        dataManager.Add("@UserId", SqlDbType.Int, ParameterDirection.Input, entity.UserId);
        dataManager.Add("@CountryId", SqlDbType.Int, ParameterDirection.Input, entity.CountryId);
        dataManager.Add("@CountryVisaId", SqlDbType.Int, ParameterDirection.Input, entity.CountryVisaId);
        dataManager.Add("@Days", SqlDbType.Int, ParameterDirection.Input, entity.DaysCount);
        
        dataManager.ExecuteNonQuery();

      }

      return entity;
    }

   
  }
}
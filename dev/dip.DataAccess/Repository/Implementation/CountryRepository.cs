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
  /// Working with Contry database object
  /// </summary>
  public class CountryRepository : IRepository<Country>
  {
    public string ConnectionString { get; set; }

    public CountryRepository()
    {
      ConnectionString = DataAccess.ConnectionString.DbConnection;
    }

    /// <summary>
    ///Get list 
    /// </summary>
    public List<Country> List()
    {
      return List(new Country() { UserId = 0 });
    }

    /// <summary>
    ///Get list with filter
    /// </summary>
    public List<Country> List(Country entity)
    {
      var entities = new List<Country>();

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[dict].[Country_List]";
        dataManager.Add("@UserId", SqlDbType.Int, ParameterDirection.Input, entity.UserId);
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
    public Country Get(int id)
    {
      var entity = new Country();

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[dict].[Country_Get]";
        dataManager.Add("@Id", SqlDbType.Int, ParameterDirection.Input, id);
        dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
        dataManager.ExecuteReader();
        XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
        entity.UnpackXML(xmlOut.Element("Country"));
      }

      return entity;
    }

    /// <summary>
    /// Add or update item
    /// </summary>
    public Country AddEdit(Country entity)
    {
      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[dict].[Country_AddEdit]";

        dataManager.Add("@UserId", SqlDbType.Int, ParameterDirection.Input, entity.UserId);
        dataManager.Add("@Name", SqlDbType.NVarChar, ParameterDirection.Input, entity.Name);
        dataManager.Add("@Code", SqlDbType.NVarChar, ParameterDirection.Input, entity.Code);
        dataManager.Add("@FinancialPeriodDateStart", SqlDbType.DateTime, ParameterDirection.Input, entity.CountryFinancialPeriod.DateStart);
        dataManager.Add("@FinancialPeriodDateEnd", SqlDbType.DateTime, ParameterDirection.Input, entity.CountryFinancialPeriod.DateEnd);
        dataManager.Add("@IsDefault", SqlDbType.Bit, ParameterDirection.Input, entity.IsDefault);

        dataManager.ExecuteNonQuery();
      }

      return entity;
    }

    /// <summary>
    /// Delete
    /// </summary>
    public bool Delete(int userId, int countryId)
    {
      bool result = true;
      try
      {

        using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
        {
          dataManager.ExecuteString = "[dict].[Country_Delete]";

          dataManager.Add("@UserId", SqlDbType.Int, ParameterDirection.Input, userId);
          dataManager.Add("@CountryId", SqlDbType.Int, ParameterDirection.Input, countryId);

          dataManager.ExecuteNonQuery();
        }
      }
      catch (Exception) { result = false; }

      return result;
    }


  }
}

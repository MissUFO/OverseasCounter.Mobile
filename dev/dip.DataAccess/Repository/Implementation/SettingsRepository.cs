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
  /// Repository for retrieving information about AppSettings
  /// </summary>
  public class SettingsRepository : IRepository<Settings>
  {
    public string ConnectionString { get; set; }

    public SettingsRepository()
    {
      ConnectionString = DataAccess.ConnectionString.DbConnection;
    }

    /// <summary>
    /// Get list
    /// </summary>
    public List<Settings> List()
    {
      return List(new Settings());
    }

    /// <summary>
    /// Get list
    /// </summary>
    public List<Settings> List(Settings entity)
    {
      var entities = new List<Settings>();

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[conf].[Settings_List]";
        dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
        dataManager.ExecuteReader();
        XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
        entities.UnpackXML(xmlOut);
      }

      return entities;
    }

    /// <summary>
    /// Get single item by key
    /// </summary>
    public Settings GetByKey(string key)
    {
      var entity = new Settings();

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[conf].[Settings_GetByKey]";
        dataManager.Add("@Key", SqlDbType.NVarChar, ParameterDirection.Input, key);
        dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
        dataManager.ExecuteReader();
        XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
        entity.UnpackXML(xmlOut.Element("Setting"));
      }

      return entity;
    }

    /// <summary>
    /// Get single item  (NOT IMPLEMENTED)
    /// </summary>
    public Settings Get(int id)
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// Add or update item (NOT IMPLEMENTED)
    /// </summary>
    public Settings AddEdit(Settings entity)
    {
      throw new System.NotImplementedException();
    }

  }
}
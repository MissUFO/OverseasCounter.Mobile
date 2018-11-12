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
  ///Working with Visa database object
  /// </summary>
  public class UserCountryVisaRepository : IRepository<UserCountryVisa>
  {
    public string ConnectionString { get; set; }

    public UserCountryVisaRepository()
    {
      ConnectionString = DataAccess.ConnectionString.DbConnection;
    }

    /// <summary>
    ///Get list
    /// </summary>
    public List<UserCountryVisa> List()
    {
      return List(new UserCountryVisa());
    }

    /// <summary>
    /// Get list by filter
    /// </summary>
    public List<UserCountryVisa> List(UserCountryVisa entity)
    {
      var entities = new List<UserCountryVisa>();

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[map].[UserCountryVisa_List]";
        dataManager.Add("@UserId", SqlDbType.Int, ParameterDirection.Input, entity.UserId);
        dataManager.Add("@CountryId", SqlDbType.Int, ParameterDirection.Input, entity.CountryId);
        dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
        dataManager.ExecuteReader();
        XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
        entities.UnpackXML(xmlOut);
      }

      return entities;
    }

    /// <summary>
    /// Get single item  (NOT IMPLEMENTED)
    /// </summary>
    public UserCountryVisa Get(int id)
    {
      var entity = new UserCountryVisa();

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[map].[UserCountryVisa_Get]";
        dataManager.Add("@Id", SqlDbType.Int, ParameterDirection.Input, id); //get all
        dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
        dataManager.ExecuteReader();
        XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
        entity.UnpackXML(xmlOut.Element("UserCountryVisa"));
      }

      return entity;
    }

    /// <summary>
    /// Add or update item
    /// </summary>
    public UserCountryVisa AddEdit(UserCountryVisa entity)
    {
      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[map].[UserCountryVisa_AddEdit]";
        dataManager.Add("@UserId", SqlDbType.Int, ParameterDirection.Input, entity.UserId);
        dataManager.Add("@CountryId", SqlDbType.Int, ParameterDirection.Input, entity.CountryId);

        dataManager.Add("@Name", SqlDbType.NVarChar, ParameterDirection.Input, entity.CountryVisa.Name);
        dataManager.Add("@Code", SqlDbType.NVarChar, ParameterDirection.Input, entity.CountryVisa.Code);
        dataManager.Add("@Description", SqlDbType.NVarChar, ParameterDirection.Input, entity.CountryVisa.Description);
        dataManager.Add("@DateStart", SqlDbType.DateTime, ParameterDirection.Input, entity.CountryVisa.DateStart);
        dataManager.Add("@DateEnd", SqlDbType.DateTime, ParameterDirection.Input, entity.CountryVisa.DateEnd);
        dataManager.Add("@CountFirstDay", SqlDbType.Bit, ParameterDirection.Input, entity.CountryVisa.CountFirstDay);
        dataManager.Add("@CountLastDay", SqlDbType.Bit, ParameterDirection.Input, entity.CountryVisa.CountLastDay);
        dataManager.Add("@TargetDays", SqlDbType.Int, ParameterDirection.Input, entity.CountryVisa.TargetDays);
        dataManager.Add("@SpecialTime", SqlDbType.NVarChar, ParameterDirection.Input, entity.CountryVisa.SpecialTime);
        dataManager.Add("@AllowNotification", SqlDbType.Bit, ParameterDirection.Input, entity.AllowNotification);

        dataManager.ExecuteNonQuery();

      }

      return entity;
    }

    /// <summary>
    /// Delete
    /// </summary>
    public bool Delete(int userId, int visaId)
    {
      bool result = true;
      try
      {

        using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
        {
          dataManager.ExecuteString = "[map].[UserCountryVisa_Delete]";

          dataManager.Add("@UserId", SqlDbType.Int, ParameterDirection.Input, userId);
          dataManager.Add("@VisaId", SqlDbType.Int, ParameterDirection.Input, visaId);

          dataManager.ExecuteNonQuery();
        }
      }
      catch (Exception) { result = false; }

      return result;
    }

  }
}

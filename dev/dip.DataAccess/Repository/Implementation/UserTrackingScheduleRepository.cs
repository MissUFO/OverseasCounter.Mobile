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
  ///Working with UserTrackingSchedule database object
  /// </summary>
  public class UserTrackingScheduleRepository : IRepository<UserTrackingSchedule>
  {
    public string ConnectionString { get; set; }

    public UserTrackingScheduleRepository()
    {
      ConnectionString = DataAccess.ConnectionString.DbConnection;
    }

    /// <summary>
    ///Get list
    /// </summary>
    public List<UserTrackingSchedule> List()
    {
      return List(new UserTrackingSchedule(){ UserId = 0 });
    }

    /// <summary>
    /// Get list by filter
    /// </summary>
    public List<UserTrackingSchedule> List(UserTrackingSchedule entity)
    {
      var entities = new List<UserTrackingSchedule>();

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[dbo].[UserTrackingSchedule_List]";
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
    public UserTrackingSchedule Get(int id)
    {
      var entity = new UserTrackingSchedule();

      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[dbo].[UserTrackingSchedule_Get]";
        dataManager.Add("@Id", SqlDbType.Int, ParameterDirection.Input, id);
        dataManager.Add("@Xml", SqlDbType.Xml, ParameterDirection.Output);
        dataManager.ExecuteReader();
        XElement xmlOut = XElement.Parse(dataManager["@Xml"].Value.ToString());
        entity.UnpackXML(xmlOut.Element("UserTrackingSchedule"));
      }

      return entity;
    }

    /// <summary>
    /// Add or update item
    /// </summary>
    public UserTrackingSchedule AddEdit(UserTrackingSchedule entity)
    {
      using (var dataManager = new DataManager.Implementation.DataManager(ConnectionString))
      {
        dataManager.ExecuteString = "[dbo].[UserTrackingSchedule_AddEdit]";

        dataManager.Add("@UserId", SqlDbType.Int, ParameterDirection.Input, entity.UserId);
        dataManager.Add("@ScheduledHours", SqlDbType.Int, ParameterDirection.Input, entity.ScheduledHours);
        dataManager.Add("@ScheduledDays", SqlDbType.Int, ParameterDirection.Input, entity.ScheduledDays);
        dataManager.Add("@ScheduledNotificationId", SqlDbType.NVarChar, ParameterDirection.Input, entity.ScheduledNotificationId);
        dataManager.Add("@Enabled", SqlDbType.Int, ParameterDirection.Input, entity.Enabled);
        dataManager.Add("@LastRun", SqlDbType.DateTime, ParameterDirection.Input, entity.LastRun);

        dataManager.ExecuteNonQuery();
      }

      return entity;
    }

  }
}

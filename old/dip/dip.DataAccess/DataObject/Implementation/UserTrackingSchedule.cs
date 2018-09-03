using System;
using System.Xml.Linq;
using dip.DataAccess.DataManager.Extension;

namespace dip.DataAccess.DataObject.Implementation
{
  /// <summary>
  /// UserTrackingSchedule object
  /// </summary>
  public class UserTrackingSchedule : Entity
  {
    public int UserId { get; set; }

    public int ScheduledHours { get; set; }

    public int ScheduledDays { get; set; }

    public DateTime LastRun { get; set; }

    protected override void CreateObjectFromXml(XElement xml)
    {
      this.Id = xml.Attribute("Id").ToType<int>();
      this.UserId = xml.Attribute("UserId").ToType<int>();
      this.ScheduledHours = xml.Attribute("ScheduledHours").ToType<int>();
      this.ScheduledDays = xml.Attribute("ScheduledDays").ToType<int>();

      this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
      this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();

      this.LastRun = xml.Attribute("LastRun").ToType<DateTime>();
    }
  }
}

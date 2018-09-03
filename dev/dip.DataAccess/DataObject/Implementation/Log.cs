using System;
using System.Xml.Linq;
using dip.DataAccess.DataManager.Extension;
using dip.DataAccess.DataObject.Enum;

namespace dip.DataAccess.DataObject.Implementation
{
  /// <summary>
  /// Log for user in system
  /// </summary>
  public class Log : Entity
  {
    public int UserId { get; set; }
    public string PageUrl { get; set; }
    public LogActionType ActionType { get; set; }
    public DateTime OccurredOn { get; set; }

    protected override void CreateObjectFromXml(XElement xml)
    {
      this.Id = xml.Attribute("Id").ToType<int>();
      this.UserId = xml.Attribute("UserId").ToType<int>();
      this.PageUrl = xml.Attribute("PageUrl").ToType<string>();
      this.ActionType = xml.Attribute("ActionType").ToEnum<LogActionType>();
      this.OccurredOn = xml.Attribute("OccurredOn").ToType<DateTime>();
      
    }
  }
}

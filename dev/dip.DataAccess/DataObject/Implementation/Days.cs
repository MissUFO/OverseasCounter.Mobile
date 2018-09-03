using System;
using System.Xml.Linq;
using dip.DataAccess.DataManager.Extension;

namespace dip.DataAccess.DataObject.Implementation
{
  /// <summary>
  /// Days object
  /// </summary>
  public class Days : Entity
  {
    public int UserCountryVisaId { get; set; }

    public int DaysCount { get; set; }

    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }

    protected override void CreateObjectFromXml(XElement xml)
    {
      this.Id = xml.Attribute("Id").ToType<int>();
      this.UserCountryVisaId = xml.Attribute("UserCountryVisaId").ToType<int>();
      this.DaysCount = xml.Attribute("Days").ToType<int>();

      this.DateStart = xml.Attribute("DateStart").ToType<DateTime>();
      this.DateEnd = xml.Attribute("DateEnd").ToType<DateTime>();
    }
  }
}

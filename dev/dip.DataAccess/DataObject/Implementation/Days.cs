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
    public int UserId { get; set; }
    public int CountryId { get; set; }
    public int? CountryVisaId { get; set; }
    public int DaysCount { get; set; }

    protected override void CreateObjectFromXml(XElement xml)
    {
      this.Id = xml.Attribute("Id").ToType<int>();
      this.UserId = xml.Attribute("UserId").ToType<int>();
      this.CountryId = xml.Attribute("CountryId").ToType<int>();
      this.CountryVisaId = xml.Attribute("CountryVisaId").ToType<int>();
      this.DaysCount = xml.Attribute("Days").ToType<int>();

      this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
      this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
    }
  }
}

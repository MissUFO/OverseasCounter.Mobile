using System;
using System.Xml.Linq;
using dip.DataAccess.DataManager.Extension;

namespace dip.DataAccess.DataObject.Implementation
{
  /// <summary>
  /// CountryFinancialPeriod object
  /// </summary>
  public class CountryFinancialPeriod : Entity
  {
    public int CountryId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }

    
    protected override void CreateObjectFromXml(XElement xml)
    {
      this.Id = xml.Attribute("Id").ToType<int>();
      this.CountryId = xml.Attribute("CountryId").ToType<int>();

      this.DateStart = xml.Attribute("DateStart").ToType<DateTime>();
      this.DateEnd = xml.Attribute("DateEnd").ToType<DateTime>();
    }
  }
}

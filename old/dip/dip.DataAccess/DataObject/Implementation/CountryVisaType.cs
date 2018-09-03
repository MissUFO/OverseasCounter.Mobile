using System;
using System.Xml.Linq;
using dip.DataAccess.DataManager.Extension;

namespace dip.DataAccess.DataObject.Implementation
{
  /// <summary>
  /// CountryVisaType object
  /// </summary>
  public class CountryVisaType : Entity
  {
    public int CountryId { get; set; }

    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public bool CountFirstDay { get; set; }
    public bool CountLastDay { get; set; }
    public int TargetDays { get; set; }
    public string SpecialTime { get; set; }

    protected override void CreateObjectFromXml(XElement xml)
    {
      this.Id = xml.Attribute("Id").ToType<int>();
      this.CountryId = xml.Attribute("CountryId").ToType<int>();

      this.Name = xml.Attribute("Name").ToType<string>();
      this.Code = xml.Attribute("Code").ToType<string>();
      this.Description = xml.Attribute("Description").ToType<string>();
      this.CountFirstDay = xml.Attribute("CountFirstDay").ToType<bool>();
      this.CountLastDay = xml.Attribute("CountLastDay").ToType<bool>();
      this.TargetDays = xml.Attribute("TargetDays").ToType<int>();
      this.SpecialTime = xml.Attribute("SpecialTime").ToType<string>();
    }
  }
}

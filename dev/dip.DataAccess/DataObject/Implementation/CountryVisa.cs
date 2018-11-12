using System;
using System.Xml.Linq;
using dip.DataAccess.DataManager.Extension;

namespace dip.DataAccess.DataObject.Implementation
{
  /// <summary>
  /// CountryVisa object
  /// </summary>
  public class CountryVisa : Entity
  {
   
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public bool CountFirstDay { get; set; }
    public bool CountLastDay { get; set; }
    public int TargetDays { get; set; }
    public string SpecialTime { get; set; }

    protected override void CreateObjectFromXml(XElement xml)
    {
      this.Id = xml.Attribute("Id").ToType<int>();
     
      this.Name = xml.Attribute("Name").ToType<string>();
      this.Code = xml.Attribute("Code").ToType<string>();
      this.Description = xml.Attribute("Description").ToType<string>();
      this.DateStart = xml.Attribute("DateStart").ToType<DateTime>();
      this.DateEnd = xml.Attribute("DateEnd").ToType<DateTime>();
      this.CountFirstDay = Convert.ToBoolean(xml.Attribute("CountFirstDay").ToType<int>());
      this.CountLastDay = Convert.ToBoolean(xml.Attribute("CountLastDay").ToType<int>());
      this.TargetDays = xml.Attribute("TargetDays").ToType<int>();
      this.SpecialTime = xml.Attribute("SpecialTime").ToType<string>();
    }
  }
}

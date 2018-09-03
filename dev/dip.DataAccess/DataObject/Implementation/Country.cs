using System;
using System.Xml.Linq;
using dip.DataAccess.DataManager.Extension;

namespace dip.DataAccess.DataObject.Implementation
{
  /// <summary>
  /// Country object
  /// </summary>
  public class Country : Entity
  {
    public string Name { get; set; }
    public string Code { get; set; }

    protected override void CreateObjectFromXml(XElement xml)
    {
      this.Id = xml.Attribute("Id").ToType<int>();
      this.Name = xml.Attribute("Name").ToType<string>();
      this.Code = xml.Attribute("Code").ToType<string>();

      this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
      this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
    }
  }
}

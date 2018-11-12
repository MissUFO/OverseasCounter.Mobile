using System;
using System.Collections.Generic;
using System.Xml.Linq;
using dip.DataAccess.DataManager.Extension;

namespace dip.DataAccess.DataObject.Implementation
{
  /// <summary>
  /// Country object
  /// </summary>
  public class Country : Entity
  {
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public bool IsDefault { get; set; }

    public CountryFinancialPeriod CountryFinancialPeriod
    {
      get { return _countryFinancialPeriod; }
      set { _countryFinancialPeriod = value; }
    }
    private CountryFinancialPeriod _countryFinancialPeriod = new CountryFinancialPeriod();

    public List<CountryVisa> CountryVisas
    {
      get { return _countryVisas; }
      set { _countryVisas = value; }
    }
    private List<CountryVisa> _countryVisas = new List<CountryVisa>();

    public List<Days> Days
    {
      get { return _days; }
      set { _days = value; }
    }
    private List<Days> _days = new List<Days>();

    protected override void CreateObjectFromXml(XElement xml)
    {
      this.Id = xml.Attribute("Id").ToType<int>();
      this.UserId = xml.Attribute("UserId").ToType<int>();
      this.Name = xml.Attribute("Name").ToType<string>();
      this.Code = xml.Attribute("Code").ToType<string>();
      this.IsDefault = Convert.ToBoolean(xml.Attribute("IsDefault").ToType<int>());
      this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
      this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();

      this.CountryFinancialPeriod.UnpackXML(xml.Element("CountryFinancialPeriod"));
      this.CountryVisas.UnpackXML(xml.Element("CountryVisas"));
      this.Days.UnpackXML(xml.Element("Days"));
    }
  }
}

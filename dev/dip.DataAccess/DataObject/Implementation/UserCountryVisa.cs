using System;
using System.Xml.Linq;
using dip.DataAccess.DataManager.Extension;
using System.Collections.Generic;

namespace dip.DataAccess.DataObject.Implementation
{
  /// <summary>
  /// UserCountryVisa object
  /// </summary>
  public class UserCountryVisa : Entity
  {
    public int UserId { get; set; }
    public int CountryId { get; set; }
    public int VisaId { get; set; }

    public List<Days> Days
    {
      get { return _days; }
      set { _days = value; }
    }
    private List<Days> _days = new List<Days>();

    public CountryVisa CountryVisa
    {
      get { return _countryVisa; }
      set { _countryVisa = value; }
    }
    private CountryVisa _countryVisa = new CountryVisa();

    public Country Country
    {
      get { return _country; }
      set { _country = value; }
    }
    private Country _country = new Country();

    public CountryFinancialPeriod CountryFinancialPeriod
    {
      get { return _countryFinancialPeriod; }
      set { _countryFinancialPeriod = value; }
    }
    private CountryFinancialPeriod _countryFinancialPeriod = new CountryFinancialPeriod();

    public bool AllowNotification { get; set; }

    protected override void CreateObjectFromXml(XElement xml)
    {
      this.UserId = xml.Attribute("UserId").ToType<int>();
      this.CountryId = xml.Attribute("CountryId").ToType<int>();
      this.VisaId = xml.Attribute("VisaId").ToType<int>();

      this.Days.UnpackXML(xml.Element("Days"));

      this.CountryVisa.UnpackXML(xml.Element("CountryVisa"));
      this.Country.UnpackXML(xml.Element("Country"));
      this.CountryFinancialPeriod.UnpackXML(xml.Element("CountryFinancialPeriod"));

      this.AllowNotification = Convert.ToBoolean(xml.Attribute("AllowNotification").ToType<int>());

      this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
      this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
    }
  }
}

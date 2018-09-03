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
    public List<Days> Days
    {
      get { return _days; }
      set { _days = value; }
    }
    private List<Days> _days = new List<Days>();

    public CountryVisaType CountryVisaType
    {
      get { return _countryVisaType; }
      set { _countryVisaType = value; }
    }
    private CountryVisaType _countryVisaType = new CountryVisaType();

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

    protected override void CreateObjectFromXml(XElement xml)
    {
      this.Days.UnpackXML(xml.Element("Days"));

      this.CountryVisaType.UnpackXML(xml.Element("CountryVisaType"));
      this.Country.UnpackXML(xml.Element("Country"));
      this.CountryFinancialPeriod.UnpackXML(xml.Element("CountryFinancialPeriod"));
    }
  }
}

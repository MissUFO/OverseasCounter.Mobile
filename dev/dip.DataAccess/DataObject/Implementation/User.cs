using System;
using System.Collections.Generic;
using System.Xml.Linq;
using dip.DataAccess.DataManager.Extension;

namespace dip.DataAccess.DataObject.Implementation
{
  /// <summary>
  /// User object
  /// </summary>
  public class User : Entity
  {
    public string Email { get; set; }
    public string Password { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }

    public string PhoneNumber { get; set; }
    public byte[] Photo { get; set; }

    public string FullName
    {
      get
      {
        return string.Join(" ", LastName, FirstName);
      }
    }

    public bool Status
    {
      get { return _status; }
      set { _status = value; }
    }
    private bool _status = true;

    public DateTime LastLoginOn { get; set; }

    public List<UserTrackingSchedule> UserTrackingSchedules
    {
      get { return _userTrackingSchedules; }
      set { _userTrackingSchedules = value; }
    }
    private List<UserTrackingSchedule> _userTrackingSchedules = new List<UserTrackingSchedule>();

    public List<UserCountryVisa> UserCountryVisas
    {
      get { return _userCountryVisas; }
      set { _userCountryVisas = value; }
    }
    private List<UserCountryVisa> _userCountryVisas = new List<UserCountryVisa>();

    protected override void CreateObjectFromXml(XElement xml)
    {
      this.Id = xml.Attribute("Id").ToType<int>();
      this.Email = xml.Attribute("Email").ToType<string>();
      this.Password = xml.Attribute("Password").ToType<string>();

      this.FirstName = xml.Attribute("FirstName").ToType<string>();
      this.LastName = xml.Attribute("LastName").ToType<string>();
      this.MiddleName = xml.Attribute("MiddleName").ToType<string>();

      this.PhoneNumber = xml.Attribute("PhoneNumber").ToType<string>();
      this.Photo = xml.Attribute("Photo").ToType<byte[]>();

      this.Status = Convert.ToBoolean(xml.Attribute("Status").ToType<int>());
      this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
      this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
      this.LastLoginOn = xml.Attribute("LastLoginOn").ToType<DateTime>();

      this.UserTrackingSchedules.UnpackXML(xml.Element("UserTrackingSchedules"));
      this.UserCountryVisas.UnpackXML(xml.Element("UserCountryVisas"));
      
    }
  }
}

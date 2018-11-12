using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using dip.DataAccess.Repository.Implementation;
using dip.DataAccess.DataObject.Implementation;
using System;

namespace dip.WebAPI.Controllers
{
  [RoutePrefix("api/usercountryvisa")]
  public class UserCountryVisaController : ApiController
  {
    [HttpPost]
    [Route("addEdit")]
    public HttpResponseMessage Add(int userId, int countryId, string name, string code, string description, DateTime dateStart, DateTime dateEnd, bool countFirstDay = true, bool countLastDay = true, int targetDays = 30, string specialTime = "", bool allowNotification = true)
    {
      var repo = new UserCountryVisaRepository();
      var entity = new UserCountryVisa();
      entity.UserId = userId;
      entity.CountryId = countryId;

      entity.CountryVisa.Name = name;
      entity.CountryVisa.Code = code;
      entity.CountryVisa.Description = description;
      entity.CountryVisa.DateStart = dateStart;
      entity.CountryVisa.DateEnd = dateEnd;
      entity.CountryVisa.CountFirstDay = countFirstDay;
      entity.CountryVisa.CountLastDay = countLastDay;
      entity.CountryVisa.TargetDays = targetDays;
      entity.CountryVisa.SpecialTime = specialTime;

      entity.AllowNotification = allowNotification;

      entity = repo.AddEdit(entity);

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }
    
    [HttpPost]
    [Route("delete")]
    public HttpResponseMessage Delete(int userId, int visaId)
    {
      var repo = new UserCountryVisaRepository();
      var entity = repo.Delete(userId, visaId);

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpGet]
    [Route("list")]
    public HttpResponseMessage List(int userId, int countryId)
    {
      var repo = new UserCountryVisaRepository();
      var entities = repo.List(new UserCountryVisa() { UserId = userId, CountryId = countryId });

      var json = JsonConvert.SerializeObject(entities);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    

  }
}

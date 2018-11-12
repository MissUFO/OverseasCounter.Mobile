using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using dip.DataAccess.Repository.Implementation;
using dip.DataAccess.DataObject.Implementation;
using System;

namespace dip.WebAPI.Controllers
{
  [RoutePrefix("api/days")]
  public class DaysController : ApiController
  {
    [HttpPost]
    [Route("addEdit")]
    public HttpResponseMessage AddEdit(int userId, int countryId, int countryVisaId, int daysCount=1)
    {
      var repo = new DaysRepository();

      var itm = new Days();
      itm.UserId = userId;
      itm.CountryId = countryId;
      itm.CountryVisaId = countryVisaId;
      itm.DaysCount = daysCount;

      var entity = repo.AddEdit(itm);

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpGet]
    [Route("get")]
    public HttpResponseMessage Get(int userId, int countryId, int? countryVisaId)
    {
      var repo = new DaysRepository();

      var itm = new Days();
      itm.UserId = userId;
      itm.CountryId = countryId;
      itm.CountryVisaId = countryVisaId;

      var entities = repo.List(itm);

      var json = JsonConvert.SerializeObject(entities);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpGet]
    [Route("list")]
    public HttpResponseMessage List(int userId)
    {
      var repo = new DaysRepository();
      var entities = repo.List(new Days() { UserId = userId });

      var json = JsonConvert.SerializeObject(entities);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }
  }
}

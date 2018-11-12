using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using dip.DataAccess.Repository.Implementation;
using dip.DataAccess.DataObject.Implementation;
using System;

namespace dip.WebAPI.Controllers
{
  [RoutePrefix("api/country")]
  public class CountryController : ApiController
  {
    [HttpPost]
    [Route("addEdit")]
    public HttpResponseMessage AddEdit(int userId, string name, string code, DateTime financialPeriodDateStart, DateTime financialPeriodDateEnd, bool isDefault)
    {
      var repo = new CountryRepository();

      var itm = new Country();
      itm.UserId = userId;
      itm.Name = name;
      itm.Code = code;
      itm.IsDefault = isDefault;

      itm.CountryFinancialPeriod.DateStart = financialPeriodDateStart;
      itm.CountryFinancialPeriod.DateEnd = financialPeriodDateEnd;

      var entity = repo.AddEdit(itm);

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }
    

    [HttpGet]
    [Route("get")]
    public HttpResponseMessage Get(int id)
    {
      var repo = new CountryRepository();
      var entities = repo.Get(id);

      var json = JsonConvert.SerializeObject(entities);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpGet]
    [Route("list")]
    public HttpResponseMessage List(int userId)
    {
      var repo = new CountryRepository();
      var entities = repo.List(new Country() { UserId = userId });

      var json = JsonConvert.SerializeObject(entities);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpPost]
    [Route("delete")]
    public HttpResponseMessage Delete(int userId, int countryId)
    {
      var repo = new CountryRepository();
      var entity = repo.Delete(userId, countryId);

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

  }
}
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using dip.DataAccess.Repository.Implementation;
using dip.DataAccess.DataObject.Implementation;

namespace dip.WebAPI.Controllers
{
  [RoutePrefix("api/days")]
  public class DaysController : ApiController
  {
    [HttpPost]
    [Route("add")]
    public HttpResponseMessage Add(int userCountryVisaId, int days = 1)
    {
      var repo = new SettingsRepository();
      var entity = new Days();

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpGet]
    [Route("countriesVisasList")]
    public HttpResponseMessage CountriesVisasList(int userId)
    {
      var repo = new SettingsRepository();
      var entities = repo.List();

      var json = JsonConvert.SerializeObject(entities);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpGet]
    [Route("getByUserCountry")]
    public HttpResponseMessage GetByUserCountry(int userId, int countryId)
    {
      var repo = new SettingsRepository();
      var entities = repo.List();

      var json = JsonConvert.SerializeObject(entities);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }


    [HttpGet]
    [Route("getByCountryVisa")]
    public HttpResponseMessage GetByCountryVisa(int userCountryVisaId)
    {
      var repo = new SettingsRepository();
      var entities = repo.List();

      var json = JsonConvert.SerializeObject(entities);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

  }
}

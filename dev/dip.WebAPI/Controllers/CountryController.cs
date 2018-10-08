using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using dip.DataAccess.Repository.Implementation;
using dip.DataAccess.DataObject.Implementation;

namespace dip.WebAPI.Controllers
{
  [RoutePrefix("api/country")]
  public class CountryController : ApiController
  {
    [HttpPost]
    [Route("add")]
    public HttpResponseMessage Add(int userCountryVisaId, int days = 1)
    {
      var repo = new SettingsRepository();
      var entity = new Country(); //repo.GetByKey(key);

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpPost]
    [Route("edit")]
    public HttpResponseMessage Edit(int userCountryVisaId, int days = 1)
    {
      var repo = new SettingsRepository();
      var entity = new Country();

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpPost]
    [Route("delete")]
    public HttpResponseMessage Delete(int userCountryVisaId, int days = 1)
    {
      var repo = new SettingsRepository();
      var entity = new Country();

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpGet]
    [Route("list")]
    public HttpResponseMessage List(int userId)
    {
      var repo = new SettingsRepository();
      var entities = repo.List();

      var json = JsonConvert.SerializeObject(entities);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

  }
}
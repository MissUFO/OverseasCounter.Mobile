using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using dip.DataAccess.Repository.Implementation;

namespace dip.WebAPI.Controllers
{
    public class SettingsController : ApiController
    {
        [HttpGet]
        [Route("api/Settings/GetByKey/{key}")]
        public HttpResponseMessage GetByKey(string key)
        {
            var repo = new SettingsRepository();
            var entity = repo.GetByKey(key);

            var json = JsonConvert.SerializeObject(entity);
            return new HttpResponseMessage {Content = new StringContent(json, Encoding.UTF8, "application/json")};
        }

        [HttpGet]
        [Route("api/Settings/List")]
        public HttpResponseMessage List()
        {
            var repo = new SettingsRepository();
            var entities = repo.List();

            var json = JsonConvert.SerializeObject(entities);
            return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }
    }
}

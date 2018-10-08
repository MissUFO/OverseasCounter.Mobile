using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using dip.DataAccess.DataObject.Implementation;
using dip.DataAccess.Repository.Implementation;

namespace dip.WebAPI.Controllers
{
  [RoutePrefix("api/error")]
  public class ErrorController : ApiController
  {
    [HttpPost]
    [Route("add")]
    public HttpResponseMessage AddEdit(Error error)
    {

      var repo = new ErrorRepository();
      var entity = repo.AddEdit(error);

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }
  }
}
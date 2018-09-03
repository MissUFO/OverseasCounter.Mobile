using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using dip.DataAccess.Repository.Implementation;

namespace dip.WebAPI.Controllers
{
  public class UserController : ApiController
  {
    [HttpGet]
    [Route("api/User/{id:int}")]
    public HttpResponseMessage Get(int id)
    {
      var repo = new UserRepository();
      var entity = repo.Get(id);

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpGet]
    [Route("api/User/LogIn/{login}/{password}")]
    public HttpResponseMessage LogIn(string login, string password)
    {
      var repository = new UserRepository();

      var entity = repository.Login(login, password);
      var json = JsonConvert.SerializeObject(entity);
      
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpGet]
    [Route("api/User/LogOff/{login}")]
    public HttpResponseMessage LogOff(string login)
    {
      var entity = new { OK = true };

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

  }
}

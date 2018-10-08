using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using dip.DataAccess.Repository.Implementation;
using dip.DataAccess.DataObject.Implementation;

namespace dip.WebAPI.Controllers
{
  [RoutePrefix("api/user")]
  public class UserController : ApiController
  {
    
    [HttpGet]
    [Route("get")]
    public HttpResponseMessage Get(int id)
    {
      var repo = new UserRepository();
      var entity = repo.Get(id);

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    
    [HttpGet]
    [Route("login")]
    public HttpResponseMessage LogIn(string login, string password)
    {
      var repository = new UserRepository();

      var entity = repository.Login(login, password);
      var json = JsonConvert.SerializeObject(entity);
      
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    
    [HttpPost]
    [Route("create")]
    [AcceptVerbs("POST", "PUT")]
    public HttpResponseMessage Create(User user)
    {
      var repository = new UserRepository();

      var entity = repository.AddEdit(user);
      var json = JsonConvert.SerializeObject(entity);

      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    
    [HttpPost]
    [Route("update")]
    [AcceptVerbs("POST", "PUT")]
    public HttpResponseMessage Update(User user)
    {
      var repository = new UserRepository();

      var entity = repository.AddEdit(user);
      var json = JsonConvert.SerializeObject(entity);

      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    
    [HttpPost]
    [Route("changePicture")]
    [AcceptVerbs("POST", "PUT")]
    public HttpResponseMessage ChangePicture(int userId, byte[] photo)
    {
      var repository = new UserRepository();

      var entity = new User();//repository.Login(login, password);
      var json = JsonConvert.SerializeObject(entity);

      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    
    [HttpPost]
    [Route("changePassword")]
    [AcceptVerbs("POST", "PUT")]
    public HttpResponseMessage ChangePassword(int userId, string password)
    {
      var repository = new UserRepository();

      var entity = new User();
      var json = JsonConvert.SerializeObject(entity);

      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    
    [HttpPost]
    [Route("changePhone")]
    [AcceptVerbs("POST", "PUT")]
    public HttpResponseMessage ChangePhone(string login, string password)
    {
      var repository = new UserRepository();

      var entity = new User();
      var json = JsonConvert.SerializeObject(entity);

      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpPost]
    [Route("restorePassword")]
    [AcceptVerbs("POST", "PUT")]
    public HttpResponseMessage RestorePassword(string email, string password, string password_new)
    {
      var repository = new UserRepository();

      var entity = new User();
      var json = JsonConvert.SerializeObject(entity);

      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpGet]
    [Route("logoff")]
    public HttpResponseMessage LogOff(int userId)
    {
      var entity = new { OK = true };

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

  }
}

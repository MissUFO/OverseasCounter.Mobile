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
    public HttpResponseMessage Create(string email, string password, string firstName, string lastName, string middleName, string phoneNumber, byte[] photo, bool status = true)
    {
      var repository = new UserRepository();

      var user = repository.GetByEmail(email);
      if (user == null || user.Id == 0)
      {
        var entity = new User();
        entity.Email = email;
        entity.Password = password;
        entity.FirstName = firstName;
        entity.LastName = lastName;
        entity.MiddleName = middleName;
        entity.Photo = photo;
        entity.PhoneNumber = phoneNumber;
        entity.Status = status;

        entity = repository.AddEdit(entity);
        var json = JsonConvert.SerializeObject(entity);
        return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
      }
      else
      {
        var json = new { status = true, message = "Пользователь с введенным логином уже существует." };
        return new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json") };
      }
    }

    
    [HttpPost]
    [Route("update")]
    [AcceptVerbs("POST", "PUT")]
    public HttpResponseMessage Update(int userId, string email = null, string firstName = null, string lastName = null, string middleName = null, string phoneNumber = null)
    {
      var repository = new UserRepository();

      var entity = repository.Get(userId);
      if (entity != null && entity.Id > 0)
      {
        if (!string.IsNullOrEmpty(email))
          entity.Email = email;
        if (!string.IsNullOrEmpty(firstName))
          entity.FirstName = firstName;
        if (!string.IsNullOrEmpty(lastName))
          entity.LastName = lastName;
        if (!string.IsNullOrEmpty(middleName))
          entity.MiddleName = middleName;
        if (!string.IsNullOrEmpty(phoneNumber))
          entity.PhoneNumber = phoneNumber;

        entity = repository.AddEdit(entity);
      }
      var json = JsonConvert.SerializeObject(entity);

      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    
    [HttpPost]
    [Route("changePicture")]
    [AcceptVerbs("POST", "PUT")]
    public HttpResponseMessage ChangePicture(int userId, byte[] photo)
    {
      var repository = new UserRepository();
      var entity = repository.Get(userId);
      if (entity != null && entity.Id > 0)
      {
        entity.Photo = photo;
        entity = repository.AddEdit(entity);
      }
      var json = JsonConvert.SerializeObject(entity);

      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    
    [HttpPost]
    [Route("changePassword")]
    [AcceptVerbs("POST", "PUT")]
    public HttpResponseMessage ChangePassword(string login, string password, string passwordNew)
    {
      var repository = new UserRepository();
      var entity = repository.Login(login, password);
      if (entity != null && entity.Id > 0)
      {
        entity.Password = passwordNew;
        entity = repository.AddEdit(entity);
      }
      var json = JsonConvert.SerializeObject(entity);

      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    
    [HttpPost]
    [Route("changePhone")]
    [AcceptVerbs("POST", "PUT")]
    public HttpResponseMessage ChangePhone(string login, string password, string phone)
    {
      var repository = new UserRepository();
      var entity = repository.Login(login, password);
      if (entity != null && entity.Id > 0)
      {
        entity.PhoneNumber = phone;
        entity = repository.AddEdit(entity);
      }
      var json = JsonConvert.SerializeObject(entity);

      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpPost]
    [Route("restorePassword")]
    [AcceptVerbs("POST", "PUT")]
    public HttpResponseMessage RestorePassword(string login, string phone)
    {
      var json = JsonConvert.SerializeObject(new { status = false, message = "Пользователь с указанным логином не найден." });

      var repository = new UserRepository();
      var entity = repository.GetByEmail(login);
      if (entity != null && entity.Id > 0)
      {
        if (entity.PhoneNumber.Trim() != phone.Trim())
          json = JsonConvert.SerializeObject(new { status = false, message = "Номер телефона не совпадает с телефоном в вашем профиле." });
        else
          json = JsonConvert.SerializeObject(entity);
      }

      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpGet]
    [Route("logoff")]
    public HttpResponseMessage LogOff(int userId)
    {
      var entity = new { status = true };

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

  }
}

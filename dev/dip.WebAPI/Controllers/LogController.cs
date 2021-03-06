﻿using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using dip.DataAccess.DataObject.Implementation;
using dip.DataAccess.Repository.Implementation;

namespace dip.WebAPI.Controllers
{
  [RoutePrefix("api/log")]
  public class LogController : ApiController
  {
    [HttpPost]
    [Route("add")]
    public HttpResponseMessage AddEdit(Log usageLog)
    {

      var repo = new LogRepository();
      var entity = repo.AddEdit(usageLog);

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }
  }
}

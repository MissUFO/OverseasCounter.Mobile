using System;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using dip.DataAccess.DataObject.Implementation;
using dip.DataAccess.DataObject.Enum;
using dip.DataAccess.Repository.Implementation;

namespace dip.WebAPI.Controllers
{
    public class LogController : ApiController
    {
        [HttpGet]
        [Route("api/Log/Add/{userId}/{pageUrl}/{actionType}")]
        public HttpResponseMessage AddEdit(int userId, string pageUrl, byte actionType)
        {   
            var usageLog = new Log()
            {
                UserId = userId,
                PageUrl = pageUrl,
                ActionType = (LogActionType)actionType,
                OccurredOn = DateTime.Now
            };
            var repo = new LogRepository();
            var entity = repo.AddEdit(usageLog);

            var json = JsonConvert.SerializeObject(entity);
            return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }
    }
}

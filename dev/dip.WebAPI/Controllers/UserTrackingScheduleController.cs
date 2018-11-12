using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using dip.DataAccess.Repository.Implementation;
using dip.DataAccess.DataObject.Implementation;
using System;

namespace dip.WebAPI.Controllers
{
  [RoutePrefix("api/usertrackingschedule")]
  public class UserTrackingScheduleController : ApiController
  {
    [HttpPost]
    [Route("addEdit")]
    public HttpResponseMessage AddEdit(int userId, int scheduledHours, int scheduledDays, string scheduledNotificationId, bool enabled, DateTime lastRun)
    {
      var repo = new UserTrackingScheduleRepository();

      var itm = new UserTrackingSchedule();
      itm.UserId = userId;
      itm.ScheduledDays = scheduledDays;
      itm.ScheduledHours = scheduledHours;

      itm.ScheduledNotificationId = scheduledNotificationId;
      itm.Enabled = enabled;
      itm.LastRun = lastRun;

      var entity = repo.AddEdit(itm);

      var json = JsonConvert.SerializeObject(entity);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }
    

    [HttpGet]
    [Route("get")]
    public HttpResponseMessage Get(int id)
    {
      var repo = new UserTrackingScheduleRepository();
      var entities = repo.Get(id);

      var json = JsonConvert.SerializeObject(entities);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

    [HttpGet]
    [Route("list")]
    public HttpResponseMessage List(int userId)
    {
      var repo = new UserTrackingScheduleRepository();
      var entities = repo.List(new UserTrackingSchedule() { UserId = userId });

      var json = JsonConvert.SerializeObject(entities);
      return new HttpResponseMessage { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    }

  }
}
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using dip.DataAccess.Repository.Implementation;
using System.Net;
using System.Collections.Generic;
using Microsoft.Azure.NotificationHubs;
using System.Net.Http;
using System;
using System.Linq;

namespace dip.WebAPI.Controllers
{

  public class NotificationController : ApiController
  {

    public async Task<HttpResponseMessage> SchedulePushNotificationAlert(int userId)
    {
      var schedulerepo = new UserTrackingScheduleRepository();

      var userrepo = new UserRepository();
      var user = userrepo.Get(userId);

      NotificationHubClient hub = NotificationHubClient
                                 .CreateClientFromConnectionString("<connection string with full access>", "<hub name>");

      var schedule = user.UserTrackingSchedules.Where(_ => _.Enabled).FirstOrDefault();

      if (schedule != null && schedule.Enabled)
      {
        Notification notification = new AppleNotification("{\"aps\":{\"alert\":\"Happy birthday!\"}}");
        var scheduledTime = new DateTimeOffset(DateTime.Today.AddDays(schedule.ScheduledDays - 1), new TimeSpan(schedule.ScheduledHours, 0, 0));
        var scheduled = await hub.ScheduleNotificationAsync(notification, scheduledTime);

        schedule.ScheduledNotificationId = scheduled.ScheduledNotificationId;
        schedulerepo.AddEdit(schedule);
      }
      return Request.CreateResponse(HttpStatusCode.OK);
    }

    public async Task<HttpResponseMessage> CancelPushNotificationAlert(int userId)
    {
      var userrepo = new UserRepository();
      var user = userrepo.Get(userId);

      var schedule = user.UserTrackingSchedules.Where(_ => _.Enabled).FirstOrDefault();
      if (schedule != null &&  schedule.Enabled && schedule.ScheduledNotificationId != string.Empty)
      {
        NotificationHubClient hub = NotificationHubClient
                                   .CreateClientFromConnectionString("<connection string with full access>", "<hub name>");
        await hub.CancelNotificationAsync(schedule.ScheduledNotificationId);
      }
      return Request.CreateResponse(HttpStatusCode.OK);

    }

    public async Task<HttpResponseMessage> CreatePushNotificationAlert(int userId)
    {
      var userrepo = new UserRepository();
      var user = userrepo.Get(userId);

      var settingsrepo = new SettingsRepository();
      var notificationTitle = settingsrepo.GetByKey("NOTIFICATION_PUSH_TITLE");
      var notificationDescription = settingsrepo.GetByKey("NOTIFICATION_PUSH_DESCRIPTION");

      NotificationHubClient hub = NotificationHubClient
                                 .CreateClientFromConnectionString("<connection string with full access>", "<hub name>");
      string toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">Hello from a .NET App!</text></binding></visual></toast>";
      await hub.SendWindowsNativeNotificationAsync(toast);

      return Request.CreateResponse(HttpStatusCode.OK);
    }

  }
}
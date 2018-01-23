using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace RepositoryLayer
{
    public class NotificationRepository : INotificationRepository
    {
        private DataContext context;

        public NotificationRepository() { this.context = new DataContext(); }

        public List<Notification> GetAll()
        {
            return this.context.Notifications.ToList();
        }

        public Notification Get(int id)
        {
            return this.context.Notifications.SingleOrDefault(e => e.NotificationId == id);
        }

        public int Insert(Notification notification)
        {
            this.context.Notifications.Add(notification);
            return this.context.SaveChanges();
        }

        public int Update(Notification notification)
        {
            Notification notificationToUpdate = this.context.Notifications.SingleOrDefault(e => e.NotificationId == notification.NotificationId);

            notificationToUpdate.NotificationId = notification.NotificationId;
            notificationToUpdate.CustomerId = notification.CustomerId;
            notificationToUpdate.Seen = notification.Seen;
            notificationToUpdate.Time = notification.Time;
            

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Notification notificationToDelete = this.context.Notifications.SingleOrDefault(e => e.NotificationId == id);
            this.context.Notifications.Remove(notificationToDelete);

            return this.context.SaveChanges();
        }
    }
}

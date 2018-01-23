using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using RepositoryLayer;

namespace Service
{
    public class NotificationService : INotificationService
    {
        private NotificationRepository repo = new NotificationRepository();

        public List<Notification> GetAll()
        {
            return repo.GetAll();
        }

        public Notification Get(int id)
        {
            return repo.Get(id);
        }

        public int Insert(Notification noti)
        {
            return repo.Insert(noti);
        }

        public int Update(Notification noti)
        {
            return repo.Update(noti);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}

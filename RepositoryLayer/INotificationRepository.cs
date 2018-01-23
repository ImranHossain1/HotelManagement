using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace RepositoryLayer
{
    public interface INotificationRepository
    {
        List<Notification> GetAll();
        Notification Get(int id);
        int Insert(Notification notification);
        int Update(Notification notification);
        int Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace RepositoryLayer
{
    public interface IMessageRepository
    {
        List<Message> GetAll();
        Message Get(int id);
        int Insert(Message message);
        int Update(Message message);
        int Delete(int id);
    }
}

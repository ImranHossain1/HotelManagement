using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using RepositoryLayer;

namespace Service
{
    public class MessageService : IMessageService
    {
        private MessageRepository repo = new MessageRepository();

        public List<Message> GetAll()
        {
            return repo.GetAll();
        }

        public Message Get(int id)
        {
            return repo.Get(id);
        }

        public int Insert(Message message)
        {
            return repo.Insert(message);
        }

        public int Update(Message message)
        {
            return repo.Update(message);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}

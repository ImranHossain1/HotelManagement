using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace RepositoryLayer
{
    public class MessageRepository : IMessageRepository
    {
        private DataContext context;

        public MessageRepository() { this.context = new DataContext(); }

        public List<Message> GetAll()
        {
            return this.context.Messages.ToList();
        }

        public Message Get(int id)
        {
            return this.context.Messages.SingleOrDefault(e => e.MessageId == id);
        }

        public int Insert(Message message)
        {
            this.context.Messages.Add(message);
            return this.context.SaveChanges();
        }

        public int Update(Message message)
        {
            Message messageToUpdate = this.context.Messages.SingleOrDefault(e => e.MessageId == message.MessageId);

            messageToUpdate.MessageId = message.MessageId;
            messageToUpdate.SenderName = message.SenderName;
            messageToUpdate.SenderEmail = message.SenderEmail;
            messageToUpdate.SenderPhone = message.SenderPhone;
            messageToUpdate.MessageBody = message.MessageBody;
            messageToUpdate.Time = message.Time;
            messageToUpdate.Seen = message.Seen;

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Message messageToDelete = this.context.Messages.SingleOrDefault(e => e.MessageId == id);
            this.context.Messages.Remove(messageToDelete);

            return this.context.SaveChanges();
        }
    }
}

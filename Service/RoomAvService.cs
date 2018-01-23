using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using RepositoryLayer;

namespace Service
{
    public class RoomAvService : IRoomAvService
    {
        private RoomAvRepository repo = new RoomAvRepository();

        public List<RoomAv> GetAll()
        {
            return repo.GetAll();
        }

        public RoomAv Get(int id)
        {
            return repo.Get(id);
        }

        public int Insert(RoomAv room)
        {
            return repo.Insert(room);
        }

        public int Update(RoomAv room)
        {
            return repo.Update(room);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using RepositoryLayer;

namespace Service
{
    public class RoomService : IRoomService
    {
        private RoomRepository repo = new RoomRepository();

        public List<Room> GetAll()
        {
            return repo.GetAll();
        }

        public Room Get(int id)
        {
            return repo.Get(id);
        }

        public Room Get(string id)
        {
            return repo.Get(id);
        }

        public int Insert(Room room)
        {
            return repo.Insert(room);
        }

        public int Update(Room room)
        {
            return repo.Update(room);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}

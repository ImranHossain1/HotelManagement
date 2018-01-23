using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace RepositoryLayer
{
    public interface IRoomRepository
    {
        List<Room> GetAll();
        Room Get(int id);
        int Insert(Room room);
        int Update(Room room);
        int Delete(int id);
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using RepositoryLayer;

namespace Service
{
    public class AdminService : IAdminService
    {
        private AdminRepository repo = new AdminRepository();

        public List<Admin> GetAll()
        {
            return repo.GetAll();
        }

        public Admin Get(int id)
        {
            return repo.Get(id);
        }

        public Admin GetByEmailPass(string u, string p)
        {
            return repo.GetByEmailPass(u,p);
        }

        public int Insert(Admin admin)
        {
            return repo.Insert(admin);
        }

        public int Update(Admin admin)
        {
            return repo.Update(admin);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}

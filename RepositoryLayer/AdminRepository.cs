using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace RepositoryLayer
{
    public class AdminRepository : IAdminRepository
    { 
        private DataContext context;

        public AdminRepository() { this.context = new DataContext(); }

        public List<Admin> GetAll()
        {
            return this.context.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return this.context.Admins.SingleOrDefault(e => e.AdminId == id);
        }
        public Admin GetByEmailPass(string e, string p)
        {
            //throw new NotImplementedException();
            return this.context.Admins.SingleOrDefault(u => u.UserName == e && u.Password == p);
        }

        public int Insert(Admin admin)
        {
            this.context.Admins.Add(admin);
            return this.context.SaveChanges();
        }

        public int Update(Admin model)
        {
            Admin adminToUpdate = this.context.Admins.SingleOrDefault(a => a.AdminId == model.AdminId);

            adminToUpdate.AdminName = model.AdminName;
            adminToUpdate.AdminEmail = model.AdminEmail;
            adminToUpdate.AdminContactNumber = model.AdminContactNumber;
            adminToUpdate.Thana = model.Thana;
            adminToUpdate.District = model.District;
            adminToUpdate.PostelCode = model.PostelCode;
            adminToUpdate.UserName = model.UserName;
            adminToUpdate.Password = model.Password;
            
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Admin adminToDelete = this.context.Admins.SingleOrDefault(e => e.AdminId == id);
            this.context.Admins.Remove(adminToDelete);

            return this.context.SaveChanges();
        }
    }
}

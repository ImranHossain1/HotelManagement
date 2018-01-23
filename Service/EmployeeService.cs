using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using RepositoryLayer;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository repo = new EmployeeRepository();

        public List<Employee> GetAll()
        {
            return repo.GetAll();
        }

        public Employee Get(int id)
        {
            return repo.Get(id);
        }

        public int Insert(Employee emp)
        {
            return repo.Insert(emp);
        }

        public int Update(Employee emp)
        {
            return repo.Update(emp);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}

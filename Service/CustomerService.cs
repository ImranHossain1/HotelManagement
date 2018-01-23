using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using RepositoryLayer;

namespace Service
{
    public class CustomerService : ICustomerService
    {
        private CustomerRepository repo = new CustomerRepository();

        public List<Customer> GetAll()
        {
            return repo.GetAll();
        }

        public Customer Get(int id)
        {
            return repo.Get(id);
        }
        public Customer Get(string id)
        {
            return repo.Get(id);
        }

        public int Insert(Customer customer)
        {
            return repo.Insert(customer);
        }

        public int Update(Customer customer)
        {
            return repo.Update(customer);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}

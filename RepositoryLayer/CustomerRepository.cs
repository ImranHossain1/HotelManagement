using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace RepositoryLayer
{
    public class CustomerRepository : ICustomerRepository
    {
        private DataContext context;

        public CustomerRepository() { this.context = new DataContext(); }

        public List<Customer> GetAll()
        {
            return this.context.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return this.context.Customers.SingleOrDefault(e => e.CustomerId == id);
        }
        public Customer Get(string id)
        {
            return this.context.Customers.SingleOrDefault(e => e.Username == id);
        }

        public int Insert(Customer customer)
        {
            this.context.Customers.Add(customer);
            return this.context.SaveChanges();
        }

        public int Update(Customer customer)
        {
            Customer customerToUpdate = this.context.Customers.SingleOrDefault(e => e.CustomerId == customer.CustomerId);

            customerToUpdate.CustomerName = customer.CustomerName;
            customerToUpdate.CustomerEmail = customer.CustomerEmail;
            customerToUpdate.CustomerContactNumber = customer.CustomerContactNumber;
            customerToUpdate.Username = customer.Username;
            customerToUpdate.RoomNeeded = customer.RoomNeeded;
            customerToUpdate.ArrivaleTime = customer.ArrivaleTime;
            customerToUpdate.RoomAvs = customer.RoomAvs;

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Customer customerToDelete = this.context.Customers.SingleOrDefault(e => e.CustomerId == id);
            this.context.Customers.Remove(customerToDelete);

            return this.context.SaveChanges();
        }
    }
}

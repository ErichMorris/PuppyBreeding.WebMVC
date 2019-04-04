using PuppyBreeding.Data;
using PuppyBreeding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    CustomerId = model.CustomerId,
                    CustomerName = model.CustomerName,
                    Email = model.Email,
                    Phone = model.Phone,
                    CustomerApproved = model.CustomerApproved,
                    DepositPaid = model.DepositPaid
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        .Select(
                            e =>
                                new CustomerListItem
                                {
                                    CustomerId = e.CustomerId,
                                    CustomerName = e.CustomerName,
                                    Email = e.Email,
                                    Phone = e.Phone,
                                    CustomerApproved = e.CustomerApproved,
                                    DepositPaid = e.DepositPaid
                                }
                        );

                return query.ToArray();
            }
        }
        public CustomerDetail GetCustomerById(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId);
                return
                    new CustomerDetail
                    {
                        CustomerId = entity.CustomerId,
                        CustomerName = entity.CustomerName,
                        Email = entity.Email,
                        Phone = entity.Phone,
                        CustomerApproved = entity.CustomerApproved,
                        DepositPaid = entity.DepositPaid
                    };
            }
        }
        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == model.CustomerId);

                entity.CustomerId = model.CustomerId;
                entity.CustomerName = model.CustomerName;
                entity.Email = model.Email;
                entity.Phone = model.Phone;
                entity.CustomerApproved = model.CustomerApproved;
                entity.DepositPaid = model.DepositPaid;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

using PuppyBreeding.Data;
using PuppyBreeding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Services
{
    public class OrderService
    {
        private readonly Guid _userId;

        public OrderService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateOrder(OrderCreate model)
        {
            var entity =
                new Order()
                {
                    PuppyId = model.PuppyId,
                    CustomerId = model.CustomerId,
                    PriceInFullPaid = model.PriceInFullPaid
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Orders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<OrderListItem> GetOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Orders
                        .Select(
                            e =>
                                new OrderListItem
                                {
                                    OrderId = e.OrderId,
                                    PuppyId = e.PuppyId,
                                    CustomerId = e.CustomerId,
                                    Price = e.Puppy.Price,
                                    CustomerApproved = e.Customer.CustomerApproved,
                                    DepositPaid = e.Customer.DepositPaid,
                                    PriceInFullPaid = e.PriceInFullPaid
                                }
                        );

                return query.ToArray();
            }
        }
        public OrderDetail GetOrderById(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == orderId);
                return
                    new OrderDetail
                    {
                        OrderId = entity.OrderId,
                        PuppyId = entity.PuppyId,
                        CustomerId = entity.CustomerId,
                        PriceInFullPaid = entity.PriceInFullPaid
                    };
            }
        }
        public bool UpdateOrder(OrderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == model.OrderId);
                entity.OrderId = model.OrderId;
                entity.PuppyId = model.PuppyId;
                entity.CustomerId = model.CustomerId;
                entity.PriceInFullPaid = model.PriceInFullPaid;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteOrder(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == orderId);

                ctx.Orders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

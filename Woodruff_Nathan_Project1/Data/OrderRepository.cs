using Data.Entities;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class OrderRepository : IOrdersRepository
    {
        private readonly Context _db;
        public OrderRepository(Context db)
        {
            _db = db;
        }


        public void Add(Domain.Order order)
        {
            _db.Orders.Add(Mapper.Map(order));
        }

        public void Edit(Domain.Order order)
        {
            if (_db.Orders.Find(order.userid) != null)
            {
                _db.Orders.Update(Mapper.Map(order));
            }

        }

        public void Delete(int id)
        {

            var record = _db.Orders.Where(q => q.Id == id).FirstOrDefault();

            if (record != null)
            {
                _db.Orders.Remove(record);
            }
        }

        public IEnumerable<Domain.Order> GetOrders()
        {
            return _db.Orders.Select(r => Mapper.Map(r)).ToList();
        }

        public IEnumerable<Domain.Order> GetOrdersByName(string username)
        {
            List<Order> orders = new List<Order>();

            var user = _db.Users.Where(q => q.Username == username).FirstOrDefault();
            var records = _db.Orders.Where(q => q.UsernameId == user.Id);

            foreach (var record in records)
            {
                orders.Add(Mapper.Map(record));
            }

            return orders;
        }

        public void Save()
        {
            _db.SaveChanges();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IOrdersRepository
    {
        //CRUD Operations
        //These are the domain entities

        void Add(Order order);

        void Edit(Order order);

        void Delete(int id);

        IEnumerable<Order> GetOrders();

        IEnumerable<Order> GetOrdersByName(string username);

        void Save();
    }
}

using System;
using Db = Data.Entities;
using Domain;

namespace Data
{
    public class Mapper
    {
        //Maps Domain classes into Data classes
        //Maps Data classes into Domain classes

        public static Domain.User Map(Db.Users user) => new Domain.User()
        {
            id = user.Id,
            username = user.Username,
            password = user.Password,
            location = user.Location,
        };

        //refactor into long form to allow control flow
        public static Db.Users Map(Domain.User user) => new Db.Users()
        {
            Username = user.username,
            Password = user.password,
            Location = user.location,
        };

        public static Domain.Pizza Map(Db.Pizzas pizza) => new Domain.Pizza
        {
            id = pizza.Id,
            size = pizza.Size,
            crust = pizza.Crust,
            type = pizza.Type,
            cost = (decimal)pizza.Cost
        };

        public static Db.Pizzas Map(Domain.Pizza pizza) => new Db.Pizzas
        {
            Id = (int)pizza.id,
            Size = pizza.size,
            Crust = pizza.crust,
            Type = pizza.type,
            Cost = pizza.cost
        };

        public static Domain.Order Map(Db.Orders order) => new Domain.Order
        {
            time = order.OrderTime,
            userid = (int)order.UsernameId,
            pizza = Map(order.Pizza)
        };

        public static Db.Orders Map(Domain.Order order) => new Db.Orders
        {
            OrderTime = order.time,
            UsernameId = order.userid,
            Pizza = Map(order.pizza)
        };
    }
}
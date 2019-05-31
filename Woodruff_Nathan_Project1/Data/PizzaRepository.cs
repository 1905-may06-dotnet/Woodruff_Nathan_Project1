using System.Collections.Generic;
using Domain;
using Data.Entities;
using System.Linq;

namespace Data
{

    public class PizzaRepository : IPizzaRepository
    {
        private readonly Context _db;
        public PizzaRepository(Context db)
        {
            _db = db;
        }

        public void Add(Domain.Pizza pizza)
        {
            _db.Pizzas.Add(Mapper.Map(pizza));
        }

        public void Edit(Domain.Pizza pizza)
        {
            if (_db.Pizzas.Find(pizza.id) != null)
            {
                _db.Pizzas.Update(Mapper.Map(pizza));
            }

        }

        public void Delete(int id)
        {

            var record = _db.Pizzas.Where(q => q.Id == id).FirstOrDefault();

            if (record != null)
            {
                _db.Pizzas.Remove(record);
            }
        }

        public IEnumerable<Domain.Pizza> GetPizzas()
        {
            return _db.Pizzas.Select(r => Mapper.Map(r)).ToList();
        }

        public Domain.Pizza GetPizzaById(int id)
        {
            var record = _db.Pizzas.Where(q => q.Id == id).FirstOrDefault();

            if (record != null)
            {
                return Mapper.Map(record);
            }
            else
            {
                return null;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
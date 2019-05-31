using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public interface IPizzaRepository
    {

        //CRUD Operations
        //These are the domain entities

        void Add(Pizza pizza);

        void Edit(Pizza pizza);

        void Delete(int id);

        IEnumerable<Pizza> GetPizzas();

        Pizza GetPizzaById(int id);

        void Save();


    }
}
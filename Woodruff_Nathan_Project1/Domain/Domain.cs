using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Domain
    {
        //Business Methods
    }
    public class User
    {
        private int? _id;
        private string _username;
        private string _password;
        private string _location;

        public int ?id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public string location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        public string password
        {
            get
            {
                return _password;
            } 
            set
            {
                _password = value;
            }
        }

        public bool CheckPassword(string password)
        {
            if(this.password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Pizza
    {
        private int? _id;
        private string _size;
        private string _crust;
        private string _type;
        private decimal _cost;


        public decimal GetCost(Pizza pizza)
        {
            switch (pizza.size)
            {
                case "small":
                    pizza.cost += 8.00M;
                    break;
                case "medium":
                    pizza.cost += 12.50M;
                    break;
                case "large":
                    pizza.cost += 15.00M; ;
                    break;
            }

            return this.cost;
        }

        public int ?id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }

        }
        
        public string size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
                
        public string crust
        {
            get
            {
                return _crust;
            }
            set
            {
                _crust = value;
            }
        }
                
        public string type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public decimal cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }

    }

    public class Order
    {
        private DateTime _time;
        private Pizza _pizza;
        private int _userid;
        private int _pizzaid;

        public DateTime time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }

        public Pizza pizza
        {
            get
            {
                return _pizza;
            }
            set
            {
                _pizza = value;
            }
        }

        public int userid
        { get
            {
                return _userid;
            }
            set
            {
                _userid = value;
            }
        }

        public int pizzaid
        {
            get
            {
                return _pizzaid;
            }
            set
            {
                _pizzaid = value;
            }
        }
    }

}

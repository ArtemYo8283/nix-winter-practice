using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLPC.Models
{
    public class PC {
        public PC() {

        }
        public PC(int Id, string Name, float Price, PCCategory Category) { 
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Category = Category;
        }

        private int _id;
        private string? _name;
        private float _price;
        private PCCategory _category;


        public int Id { 
            get { return _id; }
            private set { _id = value; }
        }
        public string? Name {
            get { return _name; }
            private set
            {
                if (String.IsNullOrEmpty(value)) {
                    throw new ArgumentNullException("Name is incorrect");
                }
                else {
                    _name = value;
                }
            }
        }

        public float Price {
            get { return _price; }
            private set
            {
                if (value <= 0 || value.Equals(null)) {
                    throw new ArgumentNullException("Price is incorrect");
                } else {
                    _price = value;
                }
            } 
        }

        public PCCategory Category {
            get { return _category; }
            private set
            {
                if (value.Equals(null))
                {
                    throw new ArgumentNullException("Category is incorrect");
                }
                else
                {
                    _category = value;
                }
            }
        }

        public bool IsBooked { get; set; } = false;

        public void start() {
            Console.WriteLine($"Start PC with id {Id}\n");
            for (int i = 0; i < 101; i += 10) {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                Console.WriteLine($"{i}%");
                Thread.Sleep(500);
            }
            Console.WriteLine($"Completed!\n");
        }

        public override string ToString()
        {
            return "==========\n" + $"Name: {Name}\n" + $"Price: {Price}\n" + $"Category: {Category}\n" + $"Id: {Id}\n" + "==========\n";
        }
    }
}

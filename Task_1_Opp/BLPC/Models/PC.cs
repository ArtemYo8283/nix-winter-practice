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
        public PC(int Id, string Name, float Price) { 
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
        }

        private int _id;
        private string? _name;
        private float _price;

        public int Id { 
            get { return _id; } 
            set { _id = value; }
        }
        public string? Name {
            get { return _name; }
            set
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
            set {
                if (value <= 0 || value == null) {
                    throw new ArgumentNullException("Price is incorrect");
                } else {
                    _price = value;
                }
            } 
        }
        private bool IsBooked { get; set; }

        public PC search()
        {

            return new PC();
        }
        public override string ToString()
        {
            return "";
        }
    }
}

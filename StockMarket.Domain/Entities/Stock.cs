using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Entities
{
    public class Stock
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }

        // Constructors
        public Stock() { }
        public Stock(int id, string name, decimal price)
        {
            ValidatePrice(price);
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }

        // Update the stock price with validation
        public void UpdatePrice(decimal newPrice)
        {
            ValidatePrice(newPrice);
            Price = newPrice;
        }

        // Validate the stock price
        private void ValidatePrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("Price cannot be negative.");
        }

    }

}

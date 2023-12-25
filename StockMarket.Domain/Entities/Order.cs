using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Entities
{
    public class Order
    {
        // Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StockId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PersonName { get; set; }

        public virtual Stock Stock { get; set; }

        // Constructors
        public Order() { }
        public Order(int stockId, decimal price, int quantity, string personName)
        {
            ValidateOrder(stockId, price, quantity, personName);
            StockId = stockId;
            Price = price;
            Quantity = quantity;
            PersonName = personName;
        }

        // Update the order details with validation
        public void UpdateOrder(decimal newPrice, int newQuantity)
        {
            ValidatePrice(newPrice);
            ValidateQuantity(newQuantity);
            Price = newPrice;
            Quantity = newQuantity;
        }

        // Validate the entire order
        private void ValidateOrder(int stockID, decimal price, int quantity, string personName)
        {
            if (stockID <= 0)
                throw new ArgumentException("Invalid stock ID.");
            ValidatePrice(price);
            ValidateQuantity(quantity);
            if (string.IsNullOrWhiteSpace(personName))
                throw new ArgumentException("Person name must be provided.");
        }

        // Validate the order price
        private void ValidatePrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.");
        }

        // Validate the order quantity
        private void ValidateQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");
        }

    }

}

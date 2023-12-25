using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.ApplicationService.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string StockName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PersonName { get; set; }
    }

    public class OrderCreateOrUpdateDto
    {
        public int StockId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PersonName { get; set; }
    }

}

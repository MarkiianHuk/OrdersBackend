using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdersBackend.DAL.Enums;

namespace OrdersBackend.BL.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Currency UnitCurrency { get; set; }
        public Currency OutputCurrency { get; set; }
    }
}

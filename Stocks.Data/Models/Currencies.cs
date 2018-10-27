using System;
namespace Stocks.Data.Models
{
    public class Currencies
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public bool Default { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stocks.Data.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public short Type { get; set; }

        [ForeignKey("AccountId")]
        public Accounts Accounts { get; set; }


    }
}

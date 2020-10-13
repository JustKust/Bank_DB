using System;
using System.Collections.Generic;

namespace Bank_DB.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Deposits = new HashSet<Deposits>();
        }

        public long CurId { get; set; }
        public long Name { get; set; }
        public long ExchangeRate { get; set; }

        public virtual ICollection<Deposits> Deposits { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Bank_DB.Models
{
    public partial class Deposits
    {
        public Deposits()
        {
            Depositors = new HashSet<Depositors>();
        }

        public long DepId { get; set; }
        public long DepName { get; set; }
        public long MinDepTern { get; set; }
        public long MinDepAmount { get; set; }
        public long AddCond { get; set; }
        public long CurId { get; set; }

        public virtual Currency Cur { get; set; }
        public virtual ICollection<Depositors> Depositors { get; set; }
    }
}

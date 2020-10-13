using System;
using System.Collections.Generic;

namespace Bank_DB.Models
{
    public partial class Positions
    {
        public Positions()
        {
            Employee = new HashSet<Employee>();
        }

        public long PosId { get; set; }
        public long PosName { get; set; }
        public long Salary { get; set; }
        public long Responsibilities { get; set; }
        public long Requirements { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}

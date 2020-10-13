using System;
using System.Collections.Generic;

namespace Bank_DB.Models
{
    public partial class Depositors
    {
        public Depositors()
        {
            Employee = new HashSet<Employee>();
        }

        public long FullName { get; set; }
        public long Adress { get; set; }
        public long PhoneNum { get; set; }
        public long PassData { get; set; }
        public long DeposDate { get; set; }
        public long RefundDate { get; set; }
        public long SummAm { get; set; }
        public long SummRef { get; set; }
        public long DepRafMark { get; set; }
        public long DepId { get; set; }

        public virtual Deposits Dep { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}

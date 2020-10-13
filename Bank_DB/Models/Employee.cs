using System;
using System.Collections.Generic;

namespace Bank_DB.Models
{
    public partial class Employee
    {
        public long EmId { get; set; }
        public long FullName { get; set; }
        public long Adress { get; set; }
        public long Telephone { get; set; }
        public long Age { get; set; }
        public long Gender { get; set; }
        public long PassData { get; set; }
        public long PosId { get; set; }

        public virtual Depositors PassDataNavigation { get; set; }
        public virtual Positions Pos { get; set; }
    }
}

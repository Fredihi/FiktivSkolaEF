using System;
using System.Collections.Generic;

namespace FiktivSkolaEF.Models
{
    public partial class StaffPosition
    {
        public StaffPosition()
        {
            ConnectionTables = new HashSet<ConnectionTable>();
            staff = new HashSet<staff>();
        }

        public int Id { get; set; }
        public string StaffPosition1 { get; set; } = null!;

        public virtual ICollection<ConnectionTable> ConnectionTables { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}

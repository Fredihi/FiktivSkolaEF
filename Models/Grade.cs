using System;
using System.Collections.Generic;

namespace FiktivSkolaEF.Models
{
    public partial class Grade
    {
        public Grade()
        {
            ConnectionTables = new HashSet<ConnectionTable>();
        }

        public int Id { get; set; }
        public string Grade1 { get; set; } = null!;

        public virtual ICollection<ConnectionTable> ConnectionTables { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FiktivSkolaEF.Models
{
    public partial class staff
    {
        public staff()
        {
            ConnectionTables = new HashSet<ConnectionTable>();
        }
        public int Id { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int? PositionId { get; set; }

        public virtual StaffPosition? Position { get; set; }
        public virtual ICollection<ConnectionTable> ConnectionTables { get; set; }
    }
}

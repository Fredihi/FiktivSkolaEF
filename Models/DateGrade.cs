using System;
using System.Collections.Generic;

namespace FiktivSkolaEF.Models
{
    public partial class DateGrade
    {
        public DateGrade()
        {
            ConnectionTables = new HashSet<ConnectionTable>();
        }

        public int Id { get; set; }
        public DateTime GradeDate { get; set; }

        public virtual ICollection<ConnectionTable> ConnectionTables { get; set; }
    }
}

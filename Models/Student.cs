using System;
using System.Collections.Generic;

namespace FiktivSkolaEF.Models
{
    public partial class Student
    {
        public Student()
        {
            ConnectionTables = new HashSet<ConnectionTable>();
        }

        public int Id { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int PersonalNumber { get; set; }
        public string Gender { get; set; } = null!;
        public string Class { get; set; } = null!;

        public virtual ICollection<ConnectionTable> ConnectionTables { get; set; }
    }
}

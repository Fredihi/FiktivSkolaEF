using System;
using System.Collections.Generic;

namespace FiktivSkolaEF.Models
{
    public partial class ConnectionTable
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int StaffId { get; set; }
        public int GradeId { get; set; }
        public int StaffPositionId { get; set; }
        public int? DateGradeId { get; set; }

        public virtual DateGrade? DateGrade { get; set; }
        public virtual Grade Grade { get; set; } = null!;
        public virtual staff Staff { get; set; } = null!;
        public virtual StaffPosition StaffPosition { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}

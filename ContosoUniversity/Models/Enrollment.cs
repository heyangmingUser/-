using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    /// <summary>
    /// 登记
    /// </summary>
    public class Enrollment
    {
        public int EnrollmentID { get; set; }


        public int CourseID { get; set; }
        public Course Course { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
    }

    public enum Grade
    {
        A, B, C, D, F
    }
}

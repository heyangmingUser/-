﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    /// <summary>
    /// 学生
    /// </summary>
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }

        /// <summary>
        /// 额外属性one
        /// </summary>
        public string ExtraOne { get; set; }

        /// <summary>
        /// 额外字段Two
        /// </summary>
        internal string ExtraTwo;

        /// <summary>
        /// 额外属性Three
        /// </summary>
        public string ExtraThree {
            get
            {
                return ExtraTwo;
            }
            set
            {
                ExtraTwo = value;
            }
        }



    }
}

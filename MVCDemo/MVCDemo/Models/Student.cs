using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Student
    {
        public int SId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EnrollmentNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PhoneNo { get; set; }

    }
}
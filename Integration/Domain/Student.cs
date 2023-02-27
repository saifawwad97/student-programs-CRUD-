using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Domain
{
    public class Student
    {
        public string StudentID;
        public string FirstName;
        public string LastName;
        public string Email;


        public Student(string studentid, string fname, string lname, string email)
        {
            StudentID = studentid;
            FirstName = fname;
            LastName = lname;
            Email = email;
        }
    }
}

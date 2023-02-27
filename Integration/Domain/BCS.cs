using Integration.TechnicalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Domain
{
    public class BCS
    {


        public static bool CreateProgram(string programcode, string description)
        {
            bool success;

            success = Programs.AddProgram(programcode, description);

            return success;
        }

        public static bool DeleteStudent(string studentid)
        {
            bool success;

            success = Students.RemoveStudent(studentid);

            return success;
        }

        public static bool EnrollStudent(Student AcceptedStudent, string Programcode)
        {
            bool success;

            success = Students.AddStudent(AcceptedStudent, Programcode);

            return success;
        }

        public static Student FindStudent(string StudentID)
        {
            Student findstudent;

            findstudent = Students.GetStudent(StudentID);

            return findstudent;
        }
        public static bool ModifyStudent(Student Enrolled_Student)
        {
            bool success;

            success = Students.UpdateStudent(Enrolled_Student);

            return success;
        }




        public static ProgramF FindProgram(string ProgramCode)
        {
            ProgramF find;

            find = Programs.GetProgram(ProgramCode);

            return find;

        }


    }
}
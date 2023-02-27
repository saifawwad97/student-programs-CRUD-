using Integration.Domain;
//using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.TechnicalServices
{
    public class Students
    {
        public static bool AddStudent(Student AcceptedStudent, string Programcode)
        {

            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection BAIS3150 = new();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = BAIS3150;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AddStudent";



            
            SqlParameter studentid = new SqlParameter();
            studentid.Value = AcceptedStudent.StudentID;
            studentid.SqlDbType = SqlDbType.NVarChar;
            studentid.ParameterName = "@StudentID";
            command.Parameters.Add(studentid);

            SqlParameter firstname = new SqlParameter();
            firstname.Value = AcceptedStudent.FirstName;
            firstname.SqlDbType = SqlDbType.NVarChar;
            firstname.ParameterName = "@FirstName";
            command.Parameters.Add(firstname);

            SqlParameter lastname = new SqlParameter();
            lastname.Value = AcceptedStudent.LastName;
            lastname.SqlDbType = SqlDbType.NVarChar;
            lastname.ParameterName = "@LastName";
            command.Parameters.Add(lastname);

            SqlParameter email = new SqlParameter();
            email.Value = AcceptedStudent.Email;
            email.SqlDbType = SqlDbType.NVarChar;
            email.ParameterName = "@Email";
            command.Parameters.Add(email);

            SqlParameter pc = new SqlParameter();
            pc.Value = Programcode;
            pc.SqlDbType = SqlDbType.NVarChar;
            pc.ParameterName = "@ProgramCode";
            command.Parameters.Add(pc);


            
            command.ExecuteNonQuery();

            return true;
        }

        public static bool RemoveStudent(string studentid)
        {

            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection BAIS3150 = new();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = BAIS3150;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DeleteStudent";




            SqlParameter student_id = new SqlParameter();
            student_id.Value = studentid;
            student_id.SqlDbType = SqlDbType.NVarChar;
            student_id.ParameterName = "@StudentID";
            command.Parameters.Add(student_id);



            command.ExecuteNonQuery();

            return true;
        }


        public static Student GetStudent(string StudentID)
        {
            

            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection BAIS3150 = new();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();

            
            SqlCommand command = new SqlCommand();
            command.Connection = BAIS3150;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetStudent";

           
            SqlParameter studentid = new SqlParameter();
            studentid.Value = StudentID;
            studentid.SqlDbType = SqlDbType.NVarChar;
            studentid.ParameterName = "@StudentID";
            command.Parameters.Add(studentid);

            Student st = new Student("", "", "", "");


            SqlDataReader r = command.ExecuteReader();

        
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; ++i)
                {
                    if (i == 0)
                        st.StudentID = r[i].ToString();

                    if (i == 1)
                        st.FirstName = r[i].ToString();

                    if (i == 2)
                        st.LastName = r[i].ToString();

                    if (i == 3)
                        st.Email = r[i].ToString();

                }
            }
            return st;
        }
        public static List<Student> GetStudents(string ProgramCode)
        {
            List<Student> ls = new List<Student>(); 

          
       
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection BAIS3150 = new();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();

         
            SqlCommand command = new SqlCommand();
            command.Connection = BAIS3150;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetStudentsByProgram";

            SqlParameter pc = new SqlParameter();
            pc.Value = ProgramCode;
            pc.SqlDbType = SqlDbType.NVarChar;
            pc.ParameterName = "@ProgramCode";
            command.Parameters.Add(pc);

           


            SqlDataReader r = command.ExecuteReader();

            while (r.Read())
            {
                Student st = new Student("", "", "", "");
                for (int i = 0; i < r.FieldCount; ++i)
                {
                    if (i == 0)
                        st.StudentID = r[i].ToString();

                    if (i == 1)
                        st.FirstName = r[i].ToString();

                    if (i == 2)
                        st.LastName = r[i].ToString();

                    if (i == 3)
                        st.Email = r[i].ToString();

                }

                ls.Add(st);

            }
            r.Close();
            return ls;
        }

        public static bool UpdateStudent(Student ModifyStudent)
        {
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection BAIS3150 = new();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();

            
            SqlCommand command = new SqlCommand();
            command.Connection = BAIS3150;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UpdateStudent";

            SqlParameter studentid = new SqlParameter();
            studentid.Value = ModifyStudent.StudentID;
            studentid.SqlDbType = SqlDbType.NVarChar;
            studentid.ParameterName = "@StudentID";
            command.Parameters.Add(studentid);

            SqlParameter firstname = new SqlParameter();
            firstname.Value = ModifyStudent.FirstName;
            firstname.SqlDbType = SqlDbType.NVarChar;
            firstname.ParameterName = "@FirstName";
            command.Parameters.Add(firstname);

            SqlParameter lastname = new SqlParameter();
            lastname.Value = ModifyStudent.LastName;
            lastname.SqlDbType = SqlDbType.NVarChar;
            lastname.ParameterName = "@LastName";
            command.Parameters.Add(lastname);

            SqlParameter email = new SqlParameter();
            email.Value = ModifyStudent.Email;
            email.SqlDbType = SqlDbType.NVarChar;
            email.ParameterName = "@Email";
            command.Parameters.Add(email);




            command.ExecuteNonQuery();

            return true;

        }
    }
}
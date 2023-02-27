using Integration.Domain;

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
    public class Programs
    {
        public static bool AddProgram(string ProgramCode, string describe)
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
            command.CommandText = "AddProgram";

         
            SqlParameter pc= new SqlParameter();
            pc.Value = ProgramCode;
            pc.SqlDbType = SqlDbType.NVarChar;
            pc.ParameterName = "@ProgramCode";
            command.Parameters.Add(pc);

            SqlParameter description = new SqlParameter();
            description.Value = describe;
            description.SqlDbType = SqlDbType.NVarChar;
            description.ParameterName = "@Description";
            command.Parameters.Add(description);



            command.ExecuteNonQuery();

            return true;
        }

        public static ProgramF GetProgram(string ProgramCode)
        {
            ProgramF g = new ProgramF("", "");


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
            command.CommandText = "GetProgram";


            SqlParameter studentid = new SqlParameter();
            studentid.Value = ProgramCode;
            studentid.SqlDbType = SqlDbType.NVarChar;
            studentid.ParameterName = "@ProgramCode";
            command.Parameters.Add(studentid);



            SqlDataReader r = command.ExecuteReader();

            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; ++i)
                {
                    if (i == 0)
                        g.ProgramCode = r[i].ToString();

                    if (i == 1)
                        g.Description = r[i].ToString();


                }
            }
            return g;
        }

    }
}
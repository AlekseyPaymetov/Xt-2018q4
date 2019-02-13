using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.Entities;

namespace Epam.Task06_3layers.UsersAndAwardsDAL
{
    public class SiteUserDB_Dao
    {
        public SiteUserDB_Dao()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        protected string ConnectionString { get; set; }

        public bool Add(SiteUser siteUser)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "AddSiteUser";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameterName = new SqlParameter("@login", siteUser.Name);
                    command.Parameters.Add(parameterName);

                    string text = siteUser.Password;
                    byte[] data = Encoding.Default.GetBytes(text);
                    byte[] result = new SHA256Managed().ComputeHash(data);
                    SqlParameter pas = new SqlParameter("@password", result);
                    command.Parameters.Add(pas);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CorrectLoginAndPassword(string login, string password)
        {
            var users = new List<string>();
            var pass = new List<byte[]>();

            byte[] data = Encoding.Default.GetBytes(password);
            byte[] result = new SHA256Managed().ComputeHash(data);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "GetAllSiteUser";
                    command.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add((string)reader["login"]);
                        pass.Add((byte[])reader["password"]);
                    }
                }

                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i] == login)
                    {
                        if (pass[i].SequenceEqual(result))
                        {
                            return true;
                        }

                        return false;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<string> GetAllSiteUserLogin()
        {
            var result = new List<string>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "GetAllSiteUserLogin";
                    command.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add((string)reader["login"]);
                    }
                }
            }
            catch
            {
            }

            return result;
        }
    }
}

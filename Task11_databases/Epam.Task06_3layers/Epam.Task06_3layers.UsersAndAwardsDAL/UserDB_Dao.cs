using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.Entities;
using Epam.Task06_3layers.UsersAndAwardsInterfaceDAL;

namespace Epam.Task06_3layers.UsersAndAwardsDAL
{
    public class UserDB_Dao : AbstractDBDao<User>
    {
        public override bool Add(User someObject)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "AddUser";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameterName = new SqlParameter("@name", someObject.Name);
                    command.Parameters.Add(parameterName);
                    SqlParameter date = new SqlParameter("@DateOfBirth", someObject.DateOfBirth);
                    command.Parameters.Add(date);
                    string base64str = someObject.ImgPath.Substring(someObject.ImgPath.IndexOf(',') + 1);
                    byte[] bytes = Convert.FromBase64String(base64str);
                    SqlParameter img = new SqlParameter("@image", bytes);
                    command.Parameters.Add(img);
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

        public bool Update(int id, string name, DateTime birthDate)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "UpdateUser";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameterId = new SqlParameter("@id", id);
                    command.Parameters.Add(parameterId);
                    SqlParameter parameterName = new SqlParameter("@name", name);
                    command.Parameters.Add(parameterName);
                    SqlParameter date = new SqlParameter("@birthDate", birthDate);
                    command.Parameters.Add(date);
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

        public override bool Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "DeleteUser";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameterName = new SqlParameter("@id", id);
                    command.Parameters.Add(parameterName);
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

        public override IEnumerable<User> GetAll()
        {
            var result = new List<User>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "GetAllUsers";
                    command.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new User((int)reader["id"], (string)reader["name"], (DateTime)reader["dateOfBirth"], Convert.ToBase64String((byte[])reader["image"])));
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

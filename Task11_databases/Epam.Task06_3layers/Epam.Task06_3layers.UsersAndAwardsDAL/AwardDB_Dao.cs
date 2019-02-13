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
    public class AwardDB_Dao : AbstractDBDao<Award>
    {
        public override bool Add(Award someObject)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "AddAward";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameterName = new SqlParameter("@title", someObject.Title);
                    command.Parameters.Add(parameterName);
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

        public bool Update(int id, string title)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "UpdateAward";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameterId = new SqlParameter("@id", id);
                    command.Parameters.Add(parameterId);
                    SqlParameter parameterName = new SqlParameter("@title", title);
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

        public override bool Delete(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "DeleteAward";
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

        public override IEnumerable<Award> GetAll()
        {
            var result = new List<Award>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "GetAllAwards";
                    command.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Award((int)reader["id"], (string)reader["title"], Convert.ToBase64String((byte[])reader["image"])));
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

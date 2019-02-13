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
    public class AwardsToUserDB_Dao : AbstractDBDao<AwardToUser>
    {
        public override bool Add(AwardToUser someObject)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "AddUserAward";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter idAward = new SqlParameter("@idAward", someObject.IdAward);
                    command.Parameters.Add(idAward);
                    SqlParameter idUser = new SqlParameter("@idUser", someObject.IdUser);
                    command.Parameters.Add(idUser);
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

        public bool Update(int oldIdAward, int oldIdUser, int idAward, int idUser)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "UpdateUserAward";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter oA = new SqlParameter("@oldIdAward", oldIdAward);
                    command.Parameters.Add(oA);

                    SqlParameter oI = new SqlParameter("@oldIdUser", oldIdUser);
                    command.Parameters.Add(oI);

                    SqlParameter a = new SqlParameter("@idAward", idAward);
                    command.Parameters.Add(a);

                    SqlParameter idUserParameter = new SqlParameter("@idUser", idUser);
                    command.Parameters.Add(idUserParameter);

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

        public bool Delete(int idUser, int idAward)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "DeleteUserAward";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter idAwardParametr = new SqlParameter("@idAward", idAward);
                    command.Parameters.Add(idAwardParametr);
                    SqlParameter idUserParametr = new SqlParameter("@idUser", idUser);
                    command.Parameters.Add(idUserParametr);
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

        public override IEnumerable<AwardToUser> GetAll()
        {
            var result = new List<AwardToUser>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "GetAllUserAwards";
                    command.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new AwardToUser(0, (int)reader["idAward"], (int)reader["idUser"]));
                    }
                }
            }
            catch
            {
            }

            return result;
        }

        public override bool Delete(int id)
        {
            return false;
        }
    }
}

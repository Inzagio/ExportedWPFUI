using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WPFUI.Models;

namespace WPFUI
{
    public class DataAccess
    {
        public List<PersonModel> GetPeople(string lastName)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("UsersDB")))
            {
                return connection.Query<PersonModel>($"select * from Users where LastName = '{lastName}'").ToList();
            }
        }

    }
}

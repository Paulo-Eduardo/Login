using System;
using System.Data;
using System.Web.Configuration;
using Dapper;
using MySql.Data.MySqlClient;

namespace Login.Models
{
    public class LogError
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Erro { get; set; }

        public static void SavingLog(Guid user, string erro)
        {
            using (IDbConnection db = new MySqlConnection(WebConfigurationManager.ConnectionStrings["LoginBase"].ConnectionString))
            {
                db.Execute("Insert into LogError (Id, User, Erro) values(@id, @user, @erro)", new { id = Guid.NewGuid().ToString(), user = user, erro = erro });
            }
        }
    }
}
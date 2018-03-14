using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Configuration;
using Dapper;
using MySql.Data.MySqlClient;

namespace Login.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        public static List<Usuario> Get()
        {
            using (IDbConnection db = new MySqlConnection(WebConfigurationManager.ConnectionStrings["LoginBase"].ConnectionString))
            {
                var retorno = db.Query<Usuario>("Select * From User").ToList();
                if (retorno.Count == 0)
                {
                    Create("admin", "Admin123", "", null);
                    retorno = Get();
                }
                return retorno;
            }
        }

        public static void Create(string login, string password, string email, string image)
        {
            using (IDbConnection db = new MySqlConnection(WebConfigurationManager.ConnectionStrings["LoginBase"].ConnectionString))
            {
                db.Execute("Insert into User (Id, Login, Password, Created, Email, Image) values(@id, @login, @password, @created, @email, @image)", new { id = Guid.NewGuid().ToString(), login = login, password = password, created = DateTime.Now, email = email, image = image});
            }
        }

        public static Usuario Get(string login, string password)
        {
            var usuarios = Get();
            return usuarios.FirstOrDefault(x => x.Login == login && x.Password == password);

        }

        public static void Remove(Guid id)
        {
            using (IDbConnection db = new MySqlConnection(WebConfigurationManager.ConnectionStrings["LoginBase"].ConnectionString))
            {
                db.Execute("Delete from User where Id = @id", new { id = id });
            }
        }
    }
}
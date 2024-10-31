using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Library_Manager
{
    internal class User
    {
        private static string connectionString = @"Data Source=C:\Users\magie\source\repos\Advanced-Library-Manager\Advanced Library Manager\Data\users.db";


        public int ID { get; set; }
        public string UserName { get; set; }

        private string Password { get; set; }
        public bool isAdmin { get; set; }

        private List<User> users;

        public IEnumerable<User> Users { get { return users; } }

        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var createDbCmd = connection.CreateCommand();
                createDbCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    Password TEXT NOT NULL,
                    isAdmin BOOL NOT NULL
                );";
                createDbCmd.ExecuteNonQuery();
            }
        }

        public static void AddUser(User user)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    var addToDbCmd = connection.CreateCommand();
                    addToDbCmd.CommandText = @"
                        INSERT INTO Users (Username, Password, isAdmin)
                        VALUES ($username, $password, $isadmin)";

                    addToDbCmd.Parameters.AddWithValue("$username", user.UserName);
                    addToDbCmd.Parameters.AddWithValue("$password", user.Password );
                    addToDbCmd.Parameters.AddWithValue("$isadmin", user.isAdmin);
                    addToDbCmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"SQLite Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
            }
        }

        public static User GetUser(string username, string password)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var getUserCmd = connection.CreateCommand();
                getUserCmd.CommandText = "SELECT * FROM Users WHERE Username = $username AND Password = $password";
                getUserCmd.Parameters.AddWithValue("$username", username);
                getUserCmd.Parameters.AddWithValue("$password", password);

                using (var reader = getUserCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User(
                            reader.GetInt32(0),             
                            reader.GetString(1),             
                            reader.GetString(2),             
                            reader.GetBoolean(3)            
                        );

                    }
                }
            }
            return null;
        }

        public User(int ID, string userName, string password, bool isAdmin)
        {
            ID = ID;
            UserName = userName;
            Password = password;
            this.isAdmin = isAdmin;
        }
        
        public User(string username, string password, bool isAdmin)
        {
            this.UserName = username;
            this.Password = password;
            this.isAdmin = isAdmin;
        }
    }
}

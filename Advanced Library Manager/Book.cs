using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Advanced_Library_Manager
{
    public class Book
    {
        private static string connectionString = @"Data Source=C:\Users\magie\source\repos\Advanced-Library-Manager\Advanced Library Manager\Data\library.db";

        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Copies { get; set; }
        public string ISBN { get; set; }

        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var createDbCmd = connection.CreateCommand();
                createDbCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Books (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Author TEXT NOT NULL,
                    ISBN TEXT NOT NULL,
                    Copies INTEGER NOT NULL
                );";
                createDbCmd.ExecuteNonQuery();
            }
        }

        public static void AddBook(Book book)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    var addToDbCmd = connection.CreateCommand();
                    addToDbCmd.CommandText = @"
                        INSERT INTO Books (Title, Author, ISBN, Copies)
                        VALUES ($title, $author, $isbn, $copies)";

                    addToDbCmd.Parameters.AddWithValue("$title", book.Title);
                    addToDbCmd.Parameters.AddWithValue("$author", book.Author);
                    addToDbCmd.Parameters.AddWithValue("$isbn", book.ISBN);
                    addToDbCmd.Parameters.AddWithValue("$copies", book.Copies);
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

        public static List<Book> GetBooks()
        {
            var books = new List<Book>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var readDbCmd = connection.CreateCommand();
                readDbCmd.CommandText = "SELECT * FROM Books";

                using (var reader = readDbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            ID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            ISBN = reader.GetString(3),
                            Copies = reader.GetInt32(4)
                        });
                    }
                }
            }

            return books;
        }

        public static void UpdateBook(Book book)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    var updateDbCmd = connection.CreateCommand();
                    updateDbCmd.CommandText = @"
                        UPDATE Books
                        SET Title = $title, Author = $author, ISBN = $isbn, Copies = $copies
                        WHERE Id = $id";

                    updateDbCmd.Parameters.AddWithValue("$id", book.ID);
                    updateDbCmd.Parameters.AddWithValue("$title", book.Title);
                    updateDbCmd.Parameters.AddWithValue("$author", book.Author);
                    updateDbCmd.Parameters.AddWithValue("$isbn", book.ISBN);
                    updateDbCmd.Parameters.AddWithValue("$copies", book.Copies);
                    updateDbCmd.ExecuteNonQuery();
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

        public static void DeleteBook(int ID)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    var deleteDbCmd = connection.CreateCommand();
                    deleteDbCmd.CommandText = "DELETE FROM Books WHERE Id = $id";
                    deleteDbCmd.Parameters.AddWithValue("$id", ID);
                    deleteDbCmd.ExecuteNonQuery();
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

        public static void ClearDB()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    var deleteDbCmd = connection.CreateCommand();
                    deleteDbCmd.CommandText = "DELETE FROM Books";
                    deleteDbCmd.ExecuteNonQuery();

                    var resetCmd = connection.CreateCommand();
                    resetCmd.CommandText = "DELETE FROM sqlite_sequence WHERE name = 'Books';";
                    resetCmd.ExecuteNonQuery();

                    Console.WriteLine("Database has been cleared!");
                }
            }
            catch(SQLiteException ex)
            {
                Console.WriteLine($"SQLite Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
            }
        }
    }
}

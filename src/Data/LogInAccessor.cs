using System;
using MySql.Data.MySqlClient;

namespace AmazonClone.src.Data {
    class LogInAccessor : DBAccessor {
        public LogInAccessor() : base(){}

        public void InsertUser(string username, string password) {
            connection.Open();

            var sql = "INSERT INTO credentials(username, password) VALUES(@username, @password)";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            connection.Close();
        }
        
        public bool UserNameExists(string username) {
            connection.Open();

            MySqlDataReader reader = GetReaderFor(username);

            bool exists = reader.Read();

            connection.Close();

            return exists;
        }
        public bool VerifyUserNamePassWord(string username, string password) {
            connection.Open();

            MySqlDataReader reader = GetReaderFor(username);
            if (reader.Read()) {
                if (reader.GetString(1) == username && reader.GetString(2) == password) {
                    connection.Close();
                    return true;
                } else {
                    connection.Close();
                }
            }
            return false;
        }

        private MySqlDataReader GetReaderFor(string username) {
            var sql = "SELECT * FROM credentials WHERE username=@username";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("username", username);

            MySqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }
    }
}
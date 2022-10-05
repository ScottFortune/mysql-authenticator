using System;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace MySQlAuthenticator.src.Data {
    class LogInAccessor : DBAccessor {
        public LogInAccessor() : base(){}

        public void InsertUser(string username, string password) {
            connection.Open();

            HashAlgorithm sha = SHA256.Create();
            byte[] hashedPassword = sha.ComputeHash(Encoding.ASCII.GetBytes(password));
            string hashString = Encoding.ASCII.GetString(hashedPassword);

            var sql = "INSERT INTO credentials(username, password) VALUES(@username, @password)";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", hashString);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            //connection.Close();

            return;
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
            HashAlgorithm sha = SHA256.Create();
            byte[] hashedPassword = sha.ComputeHash(Encoding.ASCII.GetBytes(password));
            string hashString = Encoding.ASCII.GetString(hashedPassword);

            MySqlDataReader reader = GetReaderFor(username);
            if (reader.Read()) {
                if (reader.GetString(1) == username && reader.GetString(2) == hashString) {
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
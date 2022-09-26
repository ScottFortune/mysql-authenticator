using System;
using MySql.Data.MySqlClient;

namespace AmazonClone.src.Data {
    abstract class DBAccessor {
        protected MySqlConnection connection;
        
        public DBAccessor() {
            string databaseEndpoint = @"server=localhost;userid=root;password=TempPassword;database=amazonclonedb";
            connection = new MySqlConnection(databaseEndpoint);
        }
    }
}
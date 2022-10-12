# mysql-authenticator

The line:  
-- 'string databaseEndpoint = @"server=localhost;userid=root;password=TempPassword;database=amazonclonedb";' --   
in DBAccessor.cs can be changed to connect to your own local MySQL database.

NOTE: Project was previously called AmazonClone, hence the database name.

Run using "dotnet run" while in project directory

I created this project in order to gain more experience using the SQL language and connecting to databases such as MySQL. I learned how to use commands like
SELECT, INSERT, DELETE, CREATE, FROM, WHERE, as well as manipulate the commands using C# libraries. While learning about hashing algorithms in my computer
security class, I realized that I could make my authentication service for the server more secure by using a hash for the password. Instead of storing the 
password as strings inputted from the user, the program hashes the password using SHA256. When a user logs in, their attempted password is hashed as well, and since
hashed strings map to the same output, a correct password will grant access.

The program itself prompts two commands, 'create user' and 'login'. I plan on adding admin access as well that would allow manipulation of the database table
directly from the program itself.

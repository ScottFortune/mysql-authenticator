using System;
using MySQlAuthenticator.src.Data;

namespace MySQlAuthenticator.src.ConsoleUI {
    class WelcomeUI {
        private static string Username = "";
        static void Main(string[] args) {
            Console.WriteLine("Welcome to MySQL Authenticator.");
            AwaitInput();
        }
        static void AwaitInput() {
            ListCommands();
            var input = Console.ReadLine();
            if (input != null) {
                ProcessCommand(input);
            }
        }
        static void ListCommands() {
            Console.WriteLine("Type a following command:");
            Console.WriteLine("\nlogin\ncreate user\n");
        }
        static void ProcessCommand(string input) {
            if (input == "login") {
                LogIn();
            } else if (input == "create user"){
                CreateUser();
            } else {
                Console.WriteLine("Invalid Input");
                AwaitInput();
            }
        }

        static void LogIn() {
            LogInAccessor logInAccessor = new LogInAccessor();

            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            if (username != null && logInAccessor.UserNameExists(username)) {
                Username = username;
                Console.Write("Enter password: ");
                var password = Console.ReadLine();
                if (password != null && logInAccessor.VerifyUserNamePassWord(username, password)) {
                    Console.WriteLine("Successfully logged in.");
                    ShowCommandUI();
                } else {
                    Console.WriteLine("Incorrect password.\n");
                    AwaitInput();
                }
            } else {
                Console.WriteLine("Username does not exist.\n");
                AwaitInput();
            }
        }

        static void ShowCommandUI() {
            if(Username == "admin") {
                AdminUI adminUI = new AdminUI(Username);
                adminUI.AwaitInput();
            }
        }

        static void CreateUser()
        {
            Console.WriteLine("\nCreating a user...");
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();

            if (username != null && password != null) {
                LogInAccessor logInAccessor = new LogInAccessor();
                if (!logInAccessor.UserNameExists(username)) {
                    logInAccessor.InsertUser(username, password);
                    Console.WriteLine("\nUser created.");
                    AwaitInput();
                } else {
                    Console.WriteLine("\nUsername already exists.");
                    AwaitInput();
                }
            }
        }
    }
}
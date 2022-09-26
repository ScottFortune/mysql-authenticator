using System;
using AmazonClone.src.Data;

namespace AmazonClone.src.ConsoleUI 
{
    class AdminUI : CommandUI
    {
        public AdminUI(String username) : base(username)
        {
        }

        override public void AwaitInput()
        {
            ListCommands();
            var input = Console.ReadLine();
            if (input != null)
            {
                ProcessCommand(input);
            }
        }

        public override void ListCommands()
        {
            Console.WriteLine("Type a following command:");
            Console.WriteLine("\nList Users\n");
        }

        public void ProcessCommand(string input)
        {
            if (input == "List Users")
            {
                ListUsers();
            }
        }

        private void ListUsers()
        {
            AdminAccessor adminAccessor = new AdminAccessor();
            adminAccessor.ListUsers();
        }
    }
}
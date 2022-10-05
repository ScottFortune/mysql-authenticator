using System;
using MySQlAuthenticator.src.Data;

namespace MySQlAuthenticator.src.ConsoleUI
{
    abstract class CommandUI
    {
        protected string Username;

        public CommandUI(string username)
        {
            Username = username;
        }

        abstract public void AwaitInput();
        
        abstract public void ListCommands();
    }
}

using System;
using AmazonClone.src.Data;

namespace AmazonClone.src.ConsoleUI
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

using System;

namespace MySQlAuthenticator.src.ConsoleUI 
{
    class SellerUI : CommandUI
    {
        public SellerUI(string username) : base(username){}

        public override void AwaitInput()
        {
            throw new NotImplementedException();
        }

        public override void ListCommands()
        {
            throw new NotImplementedException();
        }
    }
}
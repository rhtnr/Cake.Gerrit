using Cake.Gerrit.Connector.Contracts.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Connector.Commands
{
    public class AddMessageCommand : IGerritCommand
    {
        private readonly string message;
        private readonly string command = "-m";

        public AddMessageCommand(string message)
        {
            this.message = message;
        }

        public string GetCommandString()
        {
            return $"{command} '\"{message}\"'";
        }
    }
}

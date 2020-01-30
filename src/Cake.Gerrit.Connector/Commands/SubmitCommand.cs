using Cake.Gerrit.Connector.Contracts.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Connector.Commands
{
    public class SubmitCommand : IGerritCommand
    {
        private const string command = "--submit";
        public string GetCommandString()
        {
            return command;
        }
    }
}

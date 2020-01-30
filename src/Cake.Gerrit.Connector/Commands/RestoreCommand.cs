using Cake.Gerrit.Connector.Contracts.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Connector.Commands
{
    public class RestoreCommand : IGerritCommand
    {
        private const string command = "--restore";
        public string GetCommandString()
        {
            return command;
        }
    }
}


using Cake.Gerrit.Connector.Contracts.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Connector.Commands
{
    public class RebaseCommand : IGerritCommand
    {
        private const string command = "--rebase";
        public string GetCommandString()
        {
            return command;
        }
    }
}

using Cake.Gerrit.Connector.Contracts.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Connector.Commands
{
    public class AbandonCommand : IGerritCommand
    {
        private const string command = "--abandon";
        public string GetCommandString()
        {
            return command;
        }
    }
}

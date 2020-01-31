using Cake.Gerrit.Connector.Contracts.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Connector.Commands
{
    public class AddVerifiedCommand : IGerritCommand
    {
        private readonly int n;
        private readonly string command = "--verified";

        public AddVerifiedCommand(int n)
        {
            this.n = n;
        }

        public string GetCommandString()
        {
            if (n == 0) return $"{command} +{n}";
            return n > 0 ? $"{command} +{n}" : $"{command} -{-n}";
        }
    }
}

using Cake.Gerrit.Connector.Contracts.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Connector.Commands
{
    public class AddLabelCommand : IGerritCommand
    {
        private readonly string label;
        private readonly int n;
        private readonly string command = "--label";
        public AddLabelCommand(string label, int n)
        {
            this.n = n;
            this.label = label;
        }

        public string GetCommandString()
        {
            return n>0 ? $"{command} {label}=+{n}" : $"{command} {label}=-{-n}";
        }
    }
}

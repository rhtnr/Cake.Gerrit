using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Connector.Contracts.Commands
{
    public interface IGerritCommand
    {
        string GetCommandString();
    }
}

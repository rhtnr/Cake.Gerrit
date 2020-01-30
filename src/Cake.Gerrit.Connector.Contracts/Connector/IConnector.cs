using Cake.Gerrit.Models.Executor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Connector.Contracts.Connector
{
    public interface IConnector
    {
        void Connect();
        CommandResult CreateExecuteCommand(string command);
        void Disconnect();
    }
}

using Cake.Gerrit.Connector.Contracts.Commands;
using Cake.Gerrit.Connector.Contracts.Connector;
using Cake.Gerrit.Connector.Contracts.References;
using Cake.Gerrit.Connector.References;
using Cake.Gerrit.Models.Executor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Connector.Commands
{
    public class GerritCommandRunner : IGerritCommandRunner
    {
        private readonly IConnector _Connector;
        private readonly string _Command = "gerrit review";
        public GerritCommandRunner(IConnector connector)
        {
            this._Connector = connector;
        }

        public CommandResult ExecuteCommand(IGerritCommand command, IGerritCommitInfo commit)
        {
            if (command == null ) throw new ArgumentNullException(nameof(command));
            if (commit == null ) throw new ArgumentNullException(nameof(commit));
            
            this._Connector.Connect();
            string completeCmnd = GetCommandString(command, commit);
            var result = this._Connector.CreateExecuteCommand(completeCmnd);
            _Connector.Disconnect();
            return result;

        }

        public string GetCommandString(IGerritCommand command, IGerritCommitInfo commit)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (commit == null) throw new ArgumentNullException(nameof(commit));
            return $"{this._Command} {command.GetCommandString()} {commit.GetCommitInfo()}";
        }
    }
}

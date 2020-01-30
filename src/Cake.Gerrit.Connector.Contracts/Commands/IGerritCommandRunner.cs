using Cake.Gerrit.Connector.Contracts.References;
using Cake.Gerrit.Models.Executor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Connector.Contracts.Commands
{
    public interface IGerritCommandRunner
    {
        CommandResult ExecuteCommand(IGerritCommand command, IGerritCommitInfo commit);

        string GetCommandString(IGerritCommand command, IGerritCommitInfo commit);
    }
}

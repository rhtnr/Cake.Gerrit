using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Connector.Contracts.References
{
    public interface IGerritCommitInfo
    {
        string GetCommitInfo();
    }
}

using Cake.Gerrit.Connector.Contracts.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Connector.References
{
    /// <summary>
    /// Creates a Gerrit commit reference
    /// </summary>
    public class GerritCommitInfo : IGerritCommitInfo
    {
        private string commit;
        private string changenumber;
        private string patchset;


        /// <summary>
        /// Creates a commit info from the commit Id string
        /// </summary>
        /// <param name="commit">Commit Id</param>
        public GerritCommitInfo(string commit)
        {
            this.commit = commit;
        }

        /// <summary>
        /// Creates a commit info with the change number string and the patch set number
        /// </summary>
        /// <param name="changenumber">Change number string</param>
        /// <param name="patchset">Patchset number</param>
        public GerritCommitInfo(string changenumber, int patchset)
        {
            this.changenumber = changenumber;
            this.patchset = patchset.ToString();
        }

        /// <summary>
        /// Creates a commit info with the change number string and the patch set number
        /// </summary>
        /// <param name="changenumber">Change number string</param>
        /// <param name="patchset">Patchset number</param>
        public GerritCommitInfo(string changenumber, string patchset)
        {
            this.changenumber = changenumber;
            this.patchset = patchset;
        }

        private bool IsPatchSetDefined()
        {
            return !string.IsNullOrEmpty(patchset);
        }

        public string GetCommitInfo()
        {
            if(IsPatchSetDefined())
            {
                return $"{changenumber},{patchset}";
            }
            else
            {
                return commit;
            }
        }
    }
}

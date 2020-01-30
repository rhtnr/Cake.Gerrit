using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.Diagnostics;
using Cake.Gerrit.Api.Authentication;
using Cake.Gerrit.Connector.Commands;
using Cake.Gerrit.Connector.Connector;
using Cake.Gerrit.Connector.Contracts.Commands;
using Cake.Gerrit.Connector.Contracts.Connector;
using Cake.Gerrit.Connector.Contracts.References;
using Cake.Gerrit.Connector.References;
using Cake.Gerrit.Models.Executor;
using System;

namespace Cake.Gerrit
{
    /// <summary>
    /// Contains main functionality to add Gerrit Review comments through Cake
    /// </summary>
    [CakeAliasCategory("GerritCodeReview")]
    public static class GerritReview
    {
        /// <summary>
        /// Adds a Code Review to a commit in Gerrit
        /// </summary>
        /// <param name="context"></param>
        /// <param name="authSettings">Gerrit server and authentication settings</param>
        /// <param name="commitInfo">Gerrit commit information</param>
        /// <param name="n">Set the label to the value 'N'</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Review Comments")]
        public static void AddCodeReview(this ICakeContext context, GerritAuthConfig authSettings, GerritCommitInfo commitInfo, int n)
        {
            CheckNullArg(authSettings, nameof(authSettings));
            CheckNullArg(commitInfo, nameof(commitInfo));
            Run(context, authSettings, new AddCodeReviewCommand(n), commitInfo);
        }

        /// <summary>
        /// Adds a label to a commit in Gerrit
        /// </summary>
        /// <param name="context"></param>
        /// <param name="authSettings">Gerrit server and authentication settings</param>
        /// <param name="commitInfo">Gerrit commit information<</param>
        /// <param name="label">Label string</param>
        /// <param name="n">Set the label to the value 'N'</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Review Comments")]
        public static void AddLabel(this ICakeContext context, GerritAuthConfig authSettings, IGerritCommitInfo commitInfo, string label, int n)
        {
            CheckNullArg(authSettings, nameof(authSettings));
            CheckNullArg(commitInfo, nameof(commitInfo));
            CheckNullArg(label, nameof(label));
            Run(context, authSettings, new AddLabelCommand(label, n), commitInfo);
        }

        /// <summary>
        /// Adds a 'Verified' to a commit in Gerrit
        /// </summary>
        /// <param name="context"></param>
        /// <param name="authSettings">Gerrit server and authentication settings</param>
        /// <param name="commitInfo">Gerrit commit information<</param>
        /// <param name="n">Set the label to the value 'N'</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Review Comments")]
        public static void AddVerified(this ICakeContext context, GerritAuthConfig authSettings, IGerritCommitInfo commitInfo, int n)
        {
            CheckNullArg(authSettings, nameof(authSettings));
            CheckNullArg(commitInfo, nameof(commitInfo));
            Run(context, authSettings, new AddVerifiedCommand(n), commitInfo);
        }

        /// <summary>
        /// Abandons a commit in Gerrit
        /// </summary>
        /// <param name="context"></param>
        /// <param name="authSettings">Gerrit server and authentication settings</param>
        /// <param name="commitInfo">Gerrit commit information<</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Review Comments")]
        public static void Abandon(this ICakeContext context, GerritAuthConfig authSettings, IGerritCommitInfo commitInfo)
        {
            CheckNullArg(authSettings, nameof(authSettings));
            CheckNullArg(commitInfo, nameof(commitInfo));
            Run(context, authSettings, new AbandonCommand(), commitInfo);
        }

        /// <summary>
        /// Submits a commit in Gerrit
        /// </summary>
        /// <param name="context"></param>
        /// <param name="authSettings">Gerrit server and authentication settings</param>
        /// <param name="commitInfo">Gerrit commit information<</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Review Comments")]
        public static void Submit(this ICakeContext context, GerritAuthConfig authSettings, IGerritCommitInfo commitInfo)
        {
            CheckNullArg(authSettings, nameof(authSettings));
            CheckNullArg(commitInfo, nameof(commitInfo));
            Run(context, authSettings, new SubmitCommand(), commitInfo);
        }

        /// <summary>
        /// Rebases a commit in Gerrit
        /// </summary>
        /// <param name="context"></param>
        /// <param name="authSettings">Gerrit server and authentication settings</param>
        /// <param name="commitInfo">Gerrit commit information<</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Review Comments")]
        public static void Rebase(this ICakeContext context, GerritAuthConfig authSettings, IGerritCommitInfo commitInfo)
        {
            CheckNullArg(authSettings, nameof(authSettings));
            CheckNullArg(commitInfo, nameof(commitInfo));
            Run(context, authSettings, new RebaseCommand(), commitInfo);
        }

        /// <summary>
        /// Restores a commit in Gerrit
        /// </summary>
        /// <param name="context"></param>
        /// <param name="authSettings">Gerrit server and authentication settings</param>
        /// <param name="commitInfo">Gerrit commit information<</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Review Comments")]
        public static void Restore(this ICakeContext context, GerritAuthConfig authSettings, IGerritCommitInfo commitInfo)
        {
            CheckNullArg(authSettings, nameof(authSettings));
            CheckNullArg(commitInfo, nameof(commitInfo));
            Run(context, authSettings, new RestoreCommand(), commitInfo);
        }

        private static void Run(ICakeContext context, GerritAuthConfig authSettings, IGerritCommand command, IGerritCommitInfo commitInfo)
        {
            ICakeLog logger = context.Log;

            IConnector connector = new GerritSSHConnector(authSettings);
            logger.Information("Creating Gerrit Review command...");
            logger.Debug($"{command.GetCommandString()}");
            IGerritCommandRunner runner = new GerritCommandRunner(connector);
            logger.Debug($"{runner.GetCommandString(command, commitInfo)}");
            CommandResult result = runner.ExecuteCommand(command, commitInfo);
            if (result.ExitStatus == 0)
                logger.Information($"Gerrit Review call has been successful - {result.ToString()}");
            else
            {
                logger.Error(result.ToString());
                throw new CakeException($"Gerrit Code Review SSH Error - {result.Error}");
            }
        }

        private static void CheckNullArg(Object obj, string name)
        {
            if (obj == null) throw new ArgumentNullException(name);
        }

    }
}

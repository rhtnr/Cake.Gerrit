using Cake.Gerrit.Api.Authentication;
using Cake.Gerrit.Connector.Contracts.Connector;
using Cake.Gerrit.Models.Executor;
using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cake.Gerrit.Connector.Connector
{
    public class GerritSSHConnector : IConnector, IDisposable
    {
        private readonly SshClient sshClient;
        private bool disposed;

        public GerritSSHConnector(GerritAuthConfig authConfig)
        {
            if (authConfig == null) throw new ArgumentNullException(nameof(authConfig));
            sshClient = new SshClient(authConfig.GetAuthInfo());
            disposed = false;
        }

        public void Connect()
        {
            sshClient.Connect();
        }

        public CommandResult CreateExecuteCommand(string command)
        {
            var sshCommand = sshClient.CreateCommand(command);
            sshCommand.Execute();
            return new CommandResult
            {
                Error = sshCommand.Error,
                ExitStatus = sshCommand.ExitStatus,
                Output = new StreamReader(sshCommand.OutputStream).ReadToEnd(),
                ExtendedOutput = new StreamReader(sshCommand.ExtendedOutputStream).ReadToEnd()
            };

        }

        public void Disconnect()
        {
            sshClient.Disconnect();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                sshClient.Dispose();
            }

            disposed = true;
        }
    }
}

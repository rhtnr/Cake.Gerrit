using Cake.Gerrit.Api.Authentication;
using Cake.Gerrit.Connector.Commands;
using Cake.Gerrit.Connector.Contracts.Commands;
using Cake.Gerrit.Connector.Contracts.References;
using Cake.Gerrit.Connector.References;
using Renci.SshNet;
using System;
using Xunit;

namespace Cake.Gerrit.Tests
{
    public class UnitTests
    {
        [Fact]
        public void AuthConfig()
        {
            //arrange
            string user = "someuser";
            string host = "somehost";
            string password = "somepassword";
            int port = 99;
            GerritAuthConfig config = new GerritAuthConfig
            {
                Host = host,
                Port = port,
                User = user,
                Password = password
            };

            //act
            var auth = config.GetAuthInfo();

            //assert
            Assert.Equal(auth.Username, user);
            Assert.Single(auth.AuthenticationMethods);
            Assert.Equal(auth.Host, host);
        }

        [Fact]
        public void CommandStrings()
        {
            //arrange
            string label = "myLabel";
            IGerritCommand addCodeRevC = new AddCodeReviewCommand(5);
            IGerritCommand addLabelC = new AddLabelCommand(label, -5);
            IGerritCommand addVerifiedC = new AddVerifiedCommand(-4);
            IGerritCommand addMessageC = new AddMessageCommand(label);

            //act
            string addCodeRevCR = addCodeRevC.GetCommandString();
            string addLabelCR = addLabelC.GetCommandString();
            string addVerifiedCR = addVerifiedC.GetCommandString();
            string addMessageCR = addMessageC.GetCommandString();

            //assert
            Assert.Equal("--code-review +5", addCodeRevCR);
            Assert.Equal($"--label {label}=-5", addLabelCR);
            Assert.Equal("--verified -4", addVerifiedCR);
            Assert.Equal("-m '\"myLabel\"'", addVerifiedCR);
        }

        [Fact]
        public void CommitInfo()
        {
            //arrange
            string commitStr = "abcdefghi78";
            int patchSet = 2;
            string changeNumber = "abcde";
            IGerritCommitInfo info = new GerritCommitInfo(commitStr);
            IGerritCommitInfo infoP = new GerritCommitInfo(changeNumber, patchSet);

            //act
            string result = info.GetCommitInfo();
            string resultp = infoP.GetCommitInfo();

            //assert
            Assert.Equal(commitStr, result);
            Assert.Equal($"{changeNumber},{patchSet}", resultp);
        }
    }
}

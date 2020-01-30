using Renci.SshNet;
using System.Collections.Generic;

namespace Cake.Gerrit.Api.Authentication
{
    public class GerritAuthConfig
    {
        /// <summary>
        /// Port on which Gerrit runs. Defaults to 29418
        /// </summary>
        public int Port { get; set; } = 29418;

        /// <summary>
        /// Host on which Gerrit runs
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gerrit username
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Gerrit password associated with the user
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Path to private key file used for authentication
        /// </summary>
        public string PrivateKeyFilePath { get; set; }

        /// <summary>
        /// Set the passphrase if one is associated with the key file
        /// </summary>
        public string Passphrase { get; set; }

        public ConnectionInfo GetAuthInfo()
        {
            
            List<AuthenticationMethod> methods = new List<AuthenticationMethod>();
            if (!string.IsNullOrEmpty(Password))
            {
                methods.Add(new PasswordAuthenticationMethod(User, Password));
            }

            if (!string.IsNullOrEmpty(PrivateKeyFilePath))
            {
                PrivateKeyFile keyFile = null;
                if (string.IsNullOrEmpty(Passphrase))
                    keyFile = new PrivateKeyFile(PrivateKeyFilePath);
                else
                    keyFile = new PrivateKeyFile(PrivateKeyFilePath, Passphrase);
                var keyFileAuth = new PrivateKeyAuthenticationMethod(User, new PrivateKeyFile[] { keyFile });
                methods.Add(keyFileAuth);
            }

            ConnectionInfo connInfo = new ConnectionInfo(Host.ToString(), Port, User, methods.ToArray());            
            return connInfo;
        }


    }
}

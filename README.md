# Cake.Gerrit
A Cake Addin to post reviews/comments/labels to Gerrit Code Review

![](https://github.com/rhtnr/Cake.Gerrit/workflows/Test%20Build%20Publish%20Push/badge.svg)


### Usage

```powershell
#addin "Cake.Cake.Gerrit&loaddependencies=true"
```

```cs
var gerritLogin = new Cake.Gerrit.Api.Authentication.GerritAuthConfig{
	Host = "gerrit.somecompany.com",
	User = "gerrituser",
	PrivateKeyFilePath = @"C:\keys\gerrit\id_rsa"
};

var commitSha = new Cake.Gerrit.Connector.References.GerritCommitInfo(lastCommit.Sha);

Task("Gerrit")

    .Does(() => 
    {
      AddMessage(gerritLogin, commitSha, "Adding a message to Gerrit");
    });
```
Usage:
```cs
AddCodeReview(GerritAuthConfig authSettings, GerritCommitInfo commitInfo, int n)
AddLabel(GerritAuthConfig authSettings, GerritCommitInfo commitInfo, string label, int n)
AddVerified(GerritAuthConfig authSettings, GerritCommitInfo commitInfo, int n)
AddMessage( GerritAuthConfig authSettings, GerritCommitInfo commitInfo, string message)
```


[README file made with my favorite MD editor](https://dillinger.io/)

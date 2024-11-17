![](https://img.shields.io/badge/SGS-OAD-orange) 
![](https://img.shields.io/badge/proj-Helpers%20Library-purple)
![](https://img.shields.io/badge/-Standard%202.1-056473?logo=dotnet)
![](https://img.shields.io/badge/-6-512BD4?logo=dotnet)
![](https://img.shields.io/badge/-8-512BD4?logo=dotnet)
![](https://img.shields.io/badge/-NuGet-004880?logo=nuget)
![](https://img.shields.io/badge/-Git-666?logo=git)
![](https://img.shields.io/badge/-GitHub-666?logo=github)
![](https://img.shields.io/badge/-Gitea-666?logo=gitea)
![](https://img.shields.io/badge/Anthropic-191919?logo=anthropic)
![](https://img.shields.io/badge/OpenAI-412991?logo=openai) 
![](https://img.shields.io/badge/GitHub_Copilot-555?logo=githubcopilot)
![](https://img.shields.io/badge/draw.io-555?logo=diagrams.net)
![](https://img.shields.io/badge/Markdown-555?logo=markdown)

![](./assets/icon.png)

# SGS.OAD.Helper

儲存各種常用的函式庫

# VersionHelper

- 用於取得桌面應用程式版本
- 桌面應用程式因部署方式不同，取得版本方式也有所差異
- 支援一般組件版本與 ClickOnce 部署版本取用

```cs
using SGS.OAD.Helper;

var version = VersionHelper.CurrentVeriosn;
```

>💡ClickOnce 為一種部署方式，支援版本編號自動迭代
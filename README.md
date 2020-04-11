# LIFF-blazor-todo-app
LINE Front-end Framework (LIFF) v2 を利用したTodo管理アプリケーションをBlazor（client-side）のSPAで実装するサンプルです。

## 開発環境
このサンプルは現在 Blazor WebAssembly 3.2.0 Preview 3 に対応しています。  
以下の環境をご準備ください。

- [.NET Core SDK 3.1 SDK (Version 3.1.201 以降)](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [Visual Studio 2019 (Visual Studio 2019 16.6 Preview 2 以降)](https://visualstudio.microsoft.com/ja/vs/preview/)
- Blazorテンプレートを以下のコマンドでインストール

```cmd
　dotnet new -i Microsoft.AspNetCore.Components.WebAssembly.Templates::3.2.0-preview3.20168.3
```

## /.github/workflow
GitHub Actions によるGitHub Pagesへの自動デプロイの設定

GitHub Pages Demoサイト  
https://pierre3.github.io/liff-blazor-todo-app/  
※リンクからLINEのログイン画面に遷移します。
※Demoサイトでは作成したToDoはメモリ上にのみ作成され、永続化は行いません。

## /lif-blazor-todo-app
Todo管理アプリのサンプルコードです。

## /liff-app-starter
クライアント(Blazor WebAssembly App) + LIFF のみの最小構成のサンプル

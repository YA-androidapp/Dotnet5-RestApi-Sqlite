# Dotnet5-RestApi-Sqlite

---

# 必要なツール類

- [Visual Studio Code](https://code.visualstudio.com/download)
- [C# for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
  - [Linux](https://docs.microsoft.com/ja-jp/dotnet/core/install/linux)

```sh
$ wget https://packages.microsoft.com/config/ubuntu/20.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
$ sudo dpkg -i packages-microsoft-prod.deb
$ sudo apt-get update && sudo apt-get install -y apt-transport-https && sudo apt-get update && sudo apt-get install -y dotnet-sdk-5.0 && rm packages-microsoft-prod.deb
$ echo export PATH='$HOME/.dotnet/tools:$PATH' >> ~/.bashrc
$ dotnet --version
```

> 5.0.201

# 手順

## Project

```sh
$ dotnet new webapi -o . -n ItemApp
$ dotnet dev-certs https --trust
$ dotnet run
```

- 動作確認
  - HTTPS
    - [https://localhost:5001/WeatherForecast/](https://localhost:5001/WeatherForecast/) JSON データ
    - [https://localhost:5001/swagger/index.html](https://localhost:5001/swagger/index.html) Swagger UI7
  - HTTP
    - [http://localhost:5000/WeatherForecast/](http://localhost:5000/WeatherForecast/) JSON データ
    - [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html) Swagger UI

## Model

```sh
$ mkdir Models
$ touch Models/Item.cs
$ touch Models/SubItem.cs
$ touch Data/ItemContext.cs
$ touch Data/SubItemContext.cs
```

```sh
$ nano appsettings.json
```

```json
  "ConnectionStrings": {
    "ItemContext": "Data Source=./itemapp.db"
  }
```

```sh
$ dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
$ dotnet add package Microsoft.EntityFrameworkCore.Design
$ dotnet add package Microsoft.EntityFrameworkCore.SqlServer
$ dotnet add package Microsoft.EntityFrameworkCore.Sqlite
$ dotnet tool install -g dotnet-ef
$ dotnet tool install -g dotnet-aspnet-codegenerator
$ dotnet aspnet-codegenerator controller -name ItemsController -async -api -m Item -dc ItemContext -outDir Controllers
$ dotnet aspnet-codegenerator controller -name SubItemsController -async -api -m SubItem -dc SubItemContext -outDir Controllers
$ dotnet ef migrations add Initial --context ItemContext
$ dotnet ef migrations add Initial --context SubItemContext
$ dotnet ef database update --context SubItemContext
$ dotnet ef database update --context ItemContext
$ dotnet run
```

---

Copyright (c) 2021 YA-androidapp(https://github.com/YA-androidapp) All rights reserved.

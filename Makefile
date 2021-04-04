install:
	@create-project

create-project:
	dotnet new webapi -o . -n ItemApp
	dotnet dev-certs https --trust
	dotnet run

create-model:
	mkdir Models
	cp src/Models/Item.txt Models/Item.cs
	cp src/Models/SubItem.txt Models/SubItem.cs
	cp src/Models/MyContext.txt Models/MyContext.cs

	dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
	dotnet add package Microsoft.EntityFrameworkCore.Design
	dotnet add package Microsoft.EntityFrameworkCore.SqlServer
	dotnet add package Microsoft.EntityFrameworkCore.Sqlite
	dotnet tool install -g dotnet-aspnet-codegenerator

	sed -i~ "s/using Microsoft.OpenApi.Models;/using Microsoft.OpenApi.Models;\nusing Microsoft.EntityFrameworkCore;\nusing ItemApp.Models;/" Startup.cs
	sed -i "s/services.AddControllers();/services.AddDbContext<MyContext>();\n\t\t\tservices.AddControllers();/" Startup.cs
	dotnet aspnet-codegenerator controller -name ItemsController -async -api -m Item -dc MyContext -outDir Controllers
	sed -i~ 's/CreatedAtAction("GetItem",/CreatedAtAction(nameof(GetItem),/' Controllers/ItemsController.cs
	dotnet aspnet-codegenerator controller -name SubItemsController -async -api -m SubItem -dc MyContext -outDir Controllers
	sed -i~ 's/CreatedAtAction("GetSubItem",/CreatedAtAction(nameof(GetSubItem),/' Controllers/SubItemsController.cs

	dotnet ef migrations add Initial
	dotnet ef database update
	dotnet run
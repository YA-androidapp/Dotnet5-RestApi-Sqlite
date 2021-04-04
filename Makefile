install:
	@create-project

create-project:
	dotnet new webapi -o . -n ItemApp
	dotnet dev-certs https --trust
	dotnet run
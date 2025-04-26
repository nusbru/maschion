# Tarefas
.PHONY: all build run test clean add-migration update-database remove-migration list-migrations

all: build

build:
	dotnet build "maschion.sln"

run:
	dotnet run --project "/home/bruno/Projects/maschion/src/maschion.API"

test:
	dotnet test --project "/home/bruno/Projects/maschion/test/maschion.API.Tests"

clean:
	dotnet clean "maschion.sln"

# Entity Framework Migrations
add-migration:
	dotnet ef migrations add  $(msg) --project "/home/bruno/Projects/maschion/src/maschion.API/maschion.API.csproj"

update-database:
	dotnet ef database update --project "/home/bruno/Projects/maschion/src/maschion.API"

remove-migration:
	dotnet ef migrations remove --project "/home/bruno/Projects/maschion/src/maschion.API"

list-migrations:
	dotnet ef migrations list --project "/home/bruno/Projects/maschion/src/maschion.API"

# Solution to common problems

- HTTPS certificate trust:

  - dotnet dev-certs https --trust
  - dotnet dev-certs https --clean (this first if above not working)

- Downgrade/ Use other node version
  - Mac & Linux:
    - npm install -g n
    - n 18.10.0
  - Windows
    - delete Node.js in Control Panel/ Programme uninstall
    - Install nvm using setup.exe - https://github.com/coreybutler/nvm-windows/releases
    - nvm install 18.10.0
    - nvm use 18.10.0

## Common errprs

- ɵunwrapWritableSignal
  - Downgrade VSCode-Extension Angular Languague Service to 17.2.1
<<<<<<< HEAD:Tipps.md
- Reasons for error \_\_EFMigrationsHistory
  - Typo in the connection string in appsettings.development.json
  - A typo in the Program.cs AddDbContext method that uses the connection string
  - Using a version of Entity Framework that does not match the .Net runtime they are using e.g using .Net 6 but attempting to use Entity Framework provider with a version number of 7
=======
- object cycle detected when retrieving data from server
  - send Dto instead of entity back
>>>>>>> a81f35b3e2806b6ac3be6732683ab416c46ee73d:doc/Tipps.md

# Tools to install

- dotnet-ef(cli tool):
  - dotnet tool install --global dotnet-ef --version 7.0.15
  - dotnet tool update --global dotnet-ef --version 7.0.15
- HTTPS for web client localhost (no versioning allowed)
  - create ssl folder
  - mkcert -install
  - mkcert localhost

# Data migration

- Create migration files:
  - dotnet ef migrations add fileName -o Data/Migrations
- Update database to new schemas
  - dotnet ef database update

# Notes for developer

- Bootstrap
  - using ngx bootstrap (angular + bootstrap)
  - theme spacelab using Bootswatch
- font awesome 6
  - using angular-fontawesome 0.13 - error when generated via ng in standalone api project
    -> no standalone API, only components

## Mac

- "chmod 755 filePath" to make file executable

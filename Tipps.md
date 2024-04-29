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
- Fix Error = ɵunwrapWritableSignal
  - Downgrade VSCode-Extension Angular Languague Service to 17.2.1
- Reasons for error \_\_EFMigrationsHistory
  - Typo in the connection string in appsettings.development.json
  - A typo in the Program.cs AddDbContext method that uses the connection string
  - Using a version of Entity Framework that does not match the .Net runtime they are using e.g using .Net 6 but attempting to use Entity Framework provider with a version number of 7

# Tools to install

- dotnet-ef(cli tool):
  - dotnet tool install --global dotnet-ef --version 7.0.15
  - dotnet tool update --global dotnet-ef --version 7.0.15
- HTTPS for web client localhost (no versioning allowed)
  - create ssl folder
  - mkcert -install
  - mkcert localhost

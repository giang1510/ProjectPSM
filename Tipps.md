# Solution to common problems

- HTTPS certificate trust:

  - dotnet dev-certs https --trust
  - dotnet dev-certs https --clean (this first if above not working)

- Downgrade/ Use other node version
  - npm install -g n
  - n 18.10.0

# Tools to install

- dotnet-ef(cli tool):
  - dotnet tool install --global dotnet-ef --version 7.0.15
  - dotnet tool update --global dotnet-ef --version 7.0.15

# Data migration

- Create migration files:
  - dotnet ef migrations add fileName -o Data/Migrations
- Update database to new schemas
  - dotnet ef database update

# ProjectPSM

Social media service of products

# Features

- users can rate product via star system
- users can edit their profiles
- users can search for products
- users can see reviews from other sites
- users can see prices of the product
- users can write their own reviews

# Todo

- Create skeleton app
  - ASP .NET Core Server wit simple SQLite database
  - Angular clients
- Implement product data access

# Notes for developer

- Bootstrap
  - using ngx bootstrap (angular + bootstrap)
  - theme spacelab using Bootswatch
- font awesome 6
  - using angular-fontawesome 0.13 - error when generated via ng in standalone api project
    -> no standalone API, only components
- HTTPS for web client localhost (no versioning allowed)
  - create ssl folder
  - mkcert -install
  - mkcert localhost

## Mac

- "chmod 755 filePath" to make file executable

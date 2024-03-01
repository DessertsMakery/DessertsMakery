## Persistence
- For adding new migration run this command: <br />
` dotnet ef migrations add Initializing -p .\src\DessertsMakery.Persistence\ --startup-project .\src\Telegram\DessertsMakery.Telegram.Worker\`

- For updating database run this command: <br />
`dotnet ef database update --project .\src\Telegram\DessertsMakery.Telegram.Worker\`

**Note: All commands must be run from root of the solution.**

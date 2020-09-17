# League-Draft
ASP .NET Core League of Legends random generator for champions, build sets, summoner spells and positions.

<img src="https://i.postimg.cc/rmNs1kBG/index.png" width="15%"></img> <img src="https://i.postimg.cc/Gmz1xptm/solodraft.png" width="15%"></img> <img src="https://i.postimg.cc/5tGTsQVb/championdraft.png" width="15%"></img> <img src="https://i.postimg.cc/KYKs3cgV/teams.png" width="15%"></img> <img src="https://i.postimg.cc/dtqHmjyG/positions.png" width="15%"></img> <img src="https://i.postimg.cc/v8vXBxNT/positiondraft.png" width="15%"></img> 

## Getting Started

###### To run the application you need:
- .NET Core 3.1 

- If you don't have *Sql server* on your machine you should replace the configuration in *LeagueDraft.Web/appsettings.json* with this code:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\mssqllocaldb;Database=LeagueDraft;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
- In your *package manger console* type: 

```
update-database
```

## Used technologies
- C#
- .NET Core 3.1
- Entity Framework Core
- Bootstrap
- HTML
- CSS
- JavaScript

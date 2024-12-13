# Exomine API

This project has you building an API for your Exomine client to consume.

## Project Setup
1. Use the [instructions](https://github.com/NSS-Day-Cohort-73/server-side-dotnet-curriculum/blob/main/book-2-web-apis/chapters/web-api-setup.md) from the first column of the .NET curriculum to create a webapi called `ExomineAPI` in your csharp directory.
1. Add a `Models` folder, and create the classes consistent with the ERD for your client side project.
1. Create a DTOs folder inside the Models folder, and add DTOs for each of the models. They can have identical properties as their corresponding Model classes for now.
1. Delete the weather-forecast related code.
1. Create collections at the top of `Program.cs` as the database for this project. Make sure that you have populated those collections with the data they need. You can get this data from the old `database.json` file you won't be using any longer.

### Stretch
Once you feel you have replicated the behavior of your old application, you can delve into stretch goals. MVP first!

Some suggestions:
  1. Better, faster, stronger CSS (possibly with a framework!)
  1. More functionality
  1. Refactor the client

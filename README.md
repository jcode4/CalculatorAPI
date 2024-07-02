Project Name: CalculatorAPI
Description: A .NET 7 ASP.NET WEB API project that allows you to add /subtract/multiply or divide two numbers between 1000 and -1000


TO RUN:
Make sure you have .NET 7 SDK installed as the <TargetFramework>net7.0</TargetFramework> for this project inside .csproj file indicates.
Create a local appsettings.Development.json file under project folder by the following console cmd
cd\CalculatorAPI\CalculatorAPI 
Create appsettings.Development.json file under this above path
Add the following to appsettings.Development.json your local file:
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}


List of command line cmds to get up running once you have cloned the project locally:
cd to project root
dotnet restore
dotnet build
dotnet run

Check CalculatorAPI\Properties\launchSettings.json for localhost URL
Should be running locally on:
 "applicationUrl": "[https://localhost:7191/swagger](https://localhost:7191/swagger/index.html);
 or http://localhost:5223/swagger/index.html"


Additional testing data information:
When testing the setFirstNumber/{location} & setSecondNumber/{location} endpoints like to ideally have following test data input:

Example:
location: user a
number: 7
  


When testing the calculation/{location} endpoint point like to ideally have following test data input:

Example:
location: user a

provide one of the following for Add,Subtract,Multiply, Divide have to be in uppercase
Example
operation: Add

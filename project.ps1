param(
    [string]$FolderName = "MyProject",
    [string]$SolutionName = "MySolution",
    [string]$ConsoleAppName = "MyApp",
    [string]$TestProjectName = "MyApp.Tests"
)

# Create and navigate to the folder
mkdir $FolderName
Set-Location $FolderName

# Create a solution and projects
dotnet new sln -n $SolutionName
dotnet new console -o $ConsoleAppName --use-program-main
dotnet new xunit -o $TestProjectName

# Add projects to solution
dotnet sln add "$ConsoleAppName/$ConsoleAppName.csproj"
dotnet sln add "$TestProjectName/$TestProjectName.csproj"

# Optional: Add test project reference to main app
dotnet add "$TestProjectName/$TestProjectName.csproj" reference "$ConsoleAppName/$ConsoleAppName.csproj"
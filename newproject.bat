dotnet new console -lang F# -o src/Chapter00
dotnet sln add src/Chapter00/Chapter00.fsproj
dotnet new xunit -lang F# -o tests/Chapter00Tests
dotnet sln add tests/Chapter00Tests/Chapter00Tests.fsproj
cd tests/Chapter00Tests
dotnet add reference ../../src/Chapter00/Chapter00.fsproj
dotnet add package Xunit
dotnet add package FsUnit.XUnit
dotnet add package Swensen.Unquote
dotnet build
dotnet test
cd ../..

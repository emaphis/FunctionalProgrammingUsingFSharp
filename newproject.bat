dotnet new console -lang F# -o src/Chapter03
dotnet sln add src/Chapter03/Chapter03.fsproj
dotnet new xunit -lang F# -o tests/Chapter03Tests
dotnet sln add tests/Chapter03Tests/Chapter03Tests.fsproj
cd tests/Chapter03Tests
dotnet add reference ../../src/Chapter03/Chapter03.fsproj
dotnet add package Xunit
dotnet add package FsUnit.XUnit
dotnet add package Swensen.Unquote
dotnet build
dotnet test
cd ../..

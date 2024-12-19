dotnet new console -lang F# -o src/Chapter04
dotnet sln add src/Chapter04/Chapter04.fsproj
dotnet new xunit -lang F# -o tests/Chapter04Tests
dotnet sln add tests/Chapter04Tests/Chapter04Tests.fsproj
cd tests/Chapter04Tests
dotnet add reference ../../src/Chapter04/Chapter04.fsproj
dotnet add package Xunit
dotnet add package FsUnit.XUnit
dotnet add package Swensen.Unquote
dotnet build
dotnet test
cd ../..

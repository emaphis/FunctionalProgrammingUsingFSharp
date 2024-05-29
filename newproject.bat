dotnet new console -lang F# -o src/Chapter01
dotnet sln add src/Chapter01/Chapter01.fsproj
dotnet new xunit -lang F# -o tests/Chapter01Tests
dotnet sln add tests/Chapter01Tests/Chapter01Tests.fsproj
cd tests/Chapter01Tests
dotnet add reference ../../src/Chapter01/Chapter01.fsproj
dotnet add package Xunit
dotnet add package FsUnit.XUnit
dotnet build
dotnet test
cd ../..

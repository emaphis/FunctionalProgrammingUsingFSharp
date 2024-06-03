dotnet new console -lang F# -o src/Chapter02
dotnet sln add src/Chapter02/Chapter02.fsproj
dotnet new xunit -lang F# -o tests/Chapter02Tests
dotnet sln add tests/Chapter02Tests/Chapter02Tests.fsproj
cd tests/Chapter02Tests
dotnet add reference ../../src/Chapter02/Chapter02.fsproj
dotnet add package Xunit
dotnet add package FsUnit.XUnit
dotnet add package Swensen.Unquote
dotnet build
dotnet test
cd ../..

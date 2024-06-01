# Section 1.10 Free-standing programs

A free standing program contains a `main` function of the type:

```fsharp
string[] -> int
```

preceded by the `entry point attribute`:

```fsharp
[<EntryPoint>]
let main (param: string[]) = ...
```

The type `string[]` is an array of strings passed as parameters to the function

The program can take the form:

```fsharp
open System;;

[<EntryPoint>]
let main(param: string[]) =
    printf "Hello %s\n" param.[0]
    0
```

See `Progran.fs` in this directory for an example.

The program text can be simply be sequential lines of code without the boiler-plate in post dotnet 5 versions.

The program can be compiled using the `dotnet fsc` compiler:

```bash
> dotnet fsc Program.fsx -o Program.exe
```

The program can be run as:

```bash
> dotnet run Program Charley
Hello Charley
```

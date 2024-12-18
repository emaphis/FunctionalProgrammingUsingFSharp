module Chapter02.Exercise_02_02_Tests

open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_02

[<Fact>]
let ``Test the pow function`` () =
   test <@ "test " + "string " + "concat" = "test string concat" @>
   test <@ pow ("nothing", 0) = "" @>
   test <@ pow ("once", 1) = "once" @>
   test <@ pow ("hello ", 3) = "hello hello hello " @>

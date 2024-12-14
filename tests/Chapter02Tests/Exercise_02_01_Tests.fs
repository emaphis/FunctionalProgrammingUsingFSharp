module Chapter02.Exercise_02_01_Tests


open System
open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_01


[<Fact>]
let ``test the Exercise_02_01 function``() =
    test <@ f 24 = true @>
    test <@ f 27 = false @>
    test <@ f 29 = false @>
    test <@ f 30 = true @>

module Chapter02.Exercise_02_03

open System
open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_03

[<Fact>]
let ``Test exercise_02_03 isIthChar function`` () =
    test <@ isIthchar("a", 0, 'a') = true @>
    test <@ isIthchar("abc", 0, 'a') = true @>
    test <@ isIthchar("c", 0, 'b') = false @>
    test <@ isIthchar("abc", 1, 'b') = true @>
    test <@ isIthchar("abc", 1, 'c') = false @>

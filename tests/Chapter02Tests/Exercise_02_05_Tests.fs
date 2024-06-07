module Chapter02.Exercise_02_05_Tests

open System
open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_05

[<Fact>]
let ``Test exercise_02_05 occInString function`` () =
    test <@ occInString("", 'a') = 0 @>
    test <@ occInString("a", 'a') = 1 @>
    test <@ occInString("aaaa", 'b') = 0 @>
    test <@ occInString("aaaa", 'a') = 4 @>
    test <@ occInString("bbbb", 'a') = 0 @>
    test <@occInString("abab", 'a') = 2 @>

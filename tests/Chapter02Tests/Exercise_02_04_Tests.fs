module Chapter02.Exercise_02_04_Tests

open System
open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_04

[<Fact>]
let ``Test exercise_02_04 occFromIth function`` () =
    test <@ occFromIth("aaaa", 3, 'b') = 0 @>
    test <@ occFromIth("aaaa", 3, 'a') = 1 @>
    test <@ occFromIth("aaaa", 2, 'a') = 2 @>
    test <@occFromIth("abab", 3, 'a') = 0 @>

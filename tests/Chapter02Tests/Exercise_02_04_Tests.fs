module Chapter02.Exercise_02_04

open System
open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_04

[<Fact>]
let ``Test exercise_02_03 pow function`` () =
    test <@ occFromIth("aaaa", 3, 'b') = 0 @>
    test <@ occFromIth("aaaa", 3, 'a') = 1 @>
    test <@ occFromIth("aaaa", 2, 'a') = 2 @>
    test <@occFromIth("abab", 3, 'a') = 0 @>
    //test <@ pow("a", 5) = "aaaaa" @>
    //test <@ pow("", 5) = "" @>


let test1 = 0 = occFromIth("aaaa", 3, 'b')
let test2 = 1 = occFromIth("aaaa", 3, 'a')
let test3 = 2 = occFromIth("aaaa", 2, 'a')
let test4 = 0 = occFromIth("abab", 3, 'a')

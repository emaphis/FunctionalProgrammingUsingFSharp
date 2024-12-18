module Chapter02.Exercise_02_03_to_05_Tests

open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_03_to_05

[<Fact>]
let ``Test exercise_02_03 isIthChar function`` () =
    test <@ isIthChar("a", 0, 'a') = true @>
    test <@ isIthChar("abc", 0, 'a') = true @>
    test <@ isIthChar("c", 0, 'b') = false @>
    test <@ isIthChar("abc", 1, 'b') = true @>
    test <@ isIthChar("abc", 1, 'c') = false @>
    test <@ isIthChar ("abc", 4, 'a') = false @>


[<Fact>]
let ``Test exercise_02_04 occFromIth function`` () =
    test <@ occFromIth("aaababa", 7, 'b') = 0 @>
    test <@ occFromIth("aaababa", 0, 'b') = 2 @>
    test <@ occFromIth("aaababa", 4, 'b') = 1 @>
    test <@ occFromIth("aaababa", 0, 'c') = 0 @>
    test <@ occFromIth("aaababa", 4, 'a') = 2 @>
    test <@ occFromIth("aaababa", 0, 'a') = 5 @>


[<Fact>]
let ``Test exercise_02_05 occInString function`` () =
    test <@ occInString("", 'a') = 0 @>
    test <@ occInString("aacababa", 'a') = 5 @>
    test <@ occInString("aacababa", 'b') = 2 @>
    test <@ occInString("aacababa", 'c') = 1 @>
    test <@ occInString("aacababa", 'd') = 0 @>

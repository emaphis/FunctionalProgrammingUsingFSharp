module Chapter04.Section_04_03_Example_Tests

open Xunit
open Swensen.Unquote

open Chapter04.Section_04_03_Examples

[<Fact>]
let ``Test Example 4.3: suml`` () =
    test <@ suml [] = 0 @>
    test <@ suml [0] = 0 @>
    test <@ suml [1; 1] = 2 @>
    test <@ suml [1; 2] = 3 @>
    test <@ suml [1; 2; 3; 4; 5] = 15 @>
    

[<Fact>]
let ``Test Example 4.3: altsum`` () =
    test <@ altsum [2;-1; 3] = 6 @>
    test <@ altsum [] = 0 @>
    test <@ altsum [0] = 0 @>
    test <@ altsum [1; 1] = 0 @>
    test <@ altsum [1; 2] = -1 @>
    test <@ altsum [1; 2; 3] = 2 @>
    test <@ altsum [1; 2; 3; 4; 5] = 3 @>
    test <@ altsum [1; 1; 1; 1; 1] = 1 @>


[<Fact>]
let ``Test Example 4.3: succPairs` `` () = 
    test <@ succPairs [1; 2; 3] = [(1, 2); (2, 3)] @>
    test <@ succPairs [] = [] @>
    test <@ succPairs [1] = [] @>
    test <@ succPairs [1; 2; 3; 4] = [(1, 2); (2, 3); (3, 4)] @>
    test <@ succPairs [1; 2; 3; 4; 5] = [(1, 2); (2, 3); (3, 4); (4, 5)] @>


[<Fact>]
let ``Test Example 4.3: succPairs `` () =
    test <@ succPairs [1; 2; 3] = [(1, 2); (2, 3)] @>
    test <@ succPairs [] = [] @>
    test <@ succPairs [1] = [] @>
    test <@ succPairs [1; 2; 3; 4] = [(1, 2); (2, 3); (3, 4)] @>
    test <@ succPairs [1; 2; 3; 4; 5] = [(1, 2); (2, 3); (3, 4); (4, 5)] @>
    

[<Fact>]
let ``Test Example 4.3: sumProd`` () =
    test <@ sumProd [2; 5] = (7, 10) @>
    test <@ sumProd [] = (0, 1) @>
    test <@ sumProd [1; 1] = (2, 1) @>
    test <@ sumProd [1; 2; 3; 4] = (10, 24) @>
    test <@ sumProd [1; 1; 1; 1] = (4, 1) @>
    test <@ sumProd [2; 2; 2; 2] = (8, 16) @>
    test <@ sumProd [1; 2; 3; 4; 5] = (15, 120)  @>
    

[<Fact>]
let ``Test Example 4.3: unzip`` () =
    test <@ unzip [] = ([], []) @>
    test <@ unzip [(1, "a")] = ([1], ["a"]) @>
    test <@ unzip [(1, "a"); (2, "b")] = ([1; 2], ["a"; "b"]) @>

[<Fact>]
let ``Test Example 4.3: mix`` () =
    test <@ mix ([], []) = [] @>
    raises<exn> <@ mix ([1], []) @>
    raises<exn> <@ mix ([1], [2; 3]) @>
    test <@ mix ([1; 3], [2; 4]) = [1; 2; 3; 4] @>
    test <@ mix ([1; 2; 3],[4; 5; 6]) = [1; 4; 2; 5; 3; 6] @>

[<Fact>]
let ``Test Example 4.3: isMember`` () =
    test <@ isMember 1 [] = false  @>
    test <@ isMember 1 [0] = false @>
    test <@ isMember 1 [1] = true @>
    test <@ isMember 1 [2;4] = false @>
    test <@ isMember 1 [0;1;2] = true @>


[<Fact>]
let ``Test Example 4.3: append `` () =
    test <@ [] @ [] = []  @>
    test <@ [1] @ []      = [1] @>
    test <@ [] @ [1]      = [1] @>
    test <@ [1;2] @. [3;4]       = [1; 2; 3; 4]  @>
    test <@ [[1];[2;3]] @. [[4]] = [[1]; [2; 3]; [4]] @>
    test <@ [1] @. 2 :: [3]  = [1; 2; 3] @>
    test <@ 1 :: [2] @. [3]  = [1; 2; 3] @>


[<Fact>]
let ``Test Example 4.3: naiveRev `` () =
    test <@ naiveRev [] = []  @>
    test <@ naiveRev [1] = [1] @>
    test <@ naiveRev [1; 2] = [2; 1] @>
    test <@ naiveRev [1; 2; 3]  = [3; 2; 1] @>



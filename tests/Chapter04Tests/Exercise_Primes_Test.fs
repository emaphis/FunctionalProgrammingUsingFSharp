module Chapter04Tests.Exercise_Primes_Test


open Xunit
open Swensen.Unquote

open Chapter04.Exercise_Primes

[<Fact>]
let ``Test exercise_02_06 notDivisible function function`` () =
    test <@ notDivisible (2, 2) = false @>
    test <@ notDivisible (2,3) = true @>
    test <@ notDivisible (3,9) = false @>
    test <@ notDivisible (2,4) = false @>
    test <@ notDivisible (3, 7) = true @>


[<Fact>]
let ``Test exercise 2_7 testRange function``() =
    test <@ testRange (5, 7, 3) = true @>
    test <@ testRange (4, 5, 3) = true @>
    test <@ testRange (7, 12, 3) = true @>
    test <@ testRange (2, 11, 11) = false @>
    test <@ testRange (7, 9, 11) = true @>


[<Fact>]
let ``Test exercise 2_7 isPrime function``() =
    test <@ isPrime 1 = false @>
    test <@ isPrime 2 = true @>
    test <@ isPrime 3 = true @>
    test <@ isPrime 4 = false @>
    test <@ isPrime 5 = true @>
    test <@ isPrime 7 = true @>
    test <@ isPrime 11 = true @>

[<Fact>]
let ``Test exercise 2_7 nextPrime``() =
    test <@ nextPrime 1 = 2 @>
    test <@ nextPrime 2 = 3 @>
    test <@ nextPrime 3 = 5 @>
    test <@ nextPrime 5 = 7 @>
    test <@ nextPrime 11 = 13 @>
    test <@ nextPrime 18 = 19 @>
    test <@ nextPrime 35 = 37 @>


[<Fact>]
let ``Test pr function`` () =
    test <@ pr 1 = [2]  @>
    test <@ pr 2 = [2; 3] @>
    test <@ pr 5 = [2; 3; 5; 7; 11] @>


[<Fact>]
let ``Test pr' function`` () =
    test <@ pr' 1 1 = [] @>
    test <@ pr' 1 2 = [2] @>
    test <@ pr' 2 3 = [2;3] @>
    test <@ pr' 4 14 = [5; 7; 11; 13] @>
    test <@ pr' 7 23 = [7; 11; 13; 17; 19; 23] @>

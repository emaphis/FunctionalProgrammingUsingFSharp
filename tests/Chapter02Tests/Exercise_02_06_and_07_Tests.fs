module Chapter02.Exercise_02_06_and_07_Tests

// Exercises 6, 7

open System
open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_06_07

[<Fact>]
let ``Test exercise_02_06 notDivisible function function`` () =
    test <@ notDivisible (2, 2) = false @>
    test <@ notDivisible(2,3) = true @>
    test <@ notDivisible(3,9) = false @>
    test <@ notDivisible(2,4) = false @>
    test <@ notDivisible(3, 7) = true @>


[<Fact>]
let ``Test exercise 2_7 testRange function``() =
    test <@ testRange (5, 7, 3) = true @>
    test <@ testRange (4, 5, 3) = true @>
    test <@ testRange (7, 12, 3) = true @>
    test <@ testRange (2, 11, 11) = false @>
    test <@ testRange (7, 9, 11) = true @>


[<Fact>]
let ``Test exercise 2_7 prime function``() =
    test <@ prime 1 = true @>
    test <@ prime 2 = true @>
    test <@ prime 3 = true @>
    test <@ prime 4 = false @>
    test <@ prime 5 = true @>
    test <@ prime 6 = false @>
    test <@ prime 7 = true @>
    test <@ prime 11 = true @>
    test <@ prime 12 = false  @>
    test <@ prime 16 = false @>
    test <@ prime 17 = true @>
    test <@ prime 35 = false @>
    test <@ prime 37  = true @>

[<Fact>]
let ``Test exercise 2_7 nextPrime``() =
    test <@ nextPrime 1 = 2 @>
    test <@ nextPrime 2 = 3 @>
    test <@ nextPrime 3 = 5 @>
    test <@ nextPrime 5 = 7 @>
    test <@ nextPrime 11 = 13 @>
    test <@ nextPrime 18 = 19 @>
    test <@ nextPrime(35) = 37 @>


[<Fact>]
let ``Test nPrimes function`` () =
    test <@ nPrimes 5 = [1; 2; 3; 5; 7; 11] @>
